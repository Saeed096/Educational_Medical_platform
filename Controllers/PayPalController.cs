using Azure;
using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.PayPal;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.PayPal;
using Educational_Medical_platform.PayPal.Models;
using Educational_Medical_platform.PayPal.Models.Responses;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPal.Models;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PayPalController : ControllerBase
    {
        private readonly PayPalClientApi _client;
        private readonly IUserSubscribtionRipository _userSubscribtionRipository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ValidWebhookEventIds _validWebhookEventIds;
        private readonly IUserEnrolledCoursesRepository _userEnrolledCoursesRepository;
        private readonly IEmailService _emailService;

        public PayPalController(
            IUserSubscribtionRipository userSubscribtionRipository,
            IPlatformRepository platformRepository,
            UserManager<ApplicationUser> userManager,
            ICourseRepository courseRepository, IOptions<ValidWebhookEventIds> ValidWebhookEventIds,
            IUserEnrolledCoursesRepository userEnrolledCoursesRepository, IEmailService emailService)
        {
            _client = new PayPalClientApi(userSubscribtionRipository, platformRepository, userManager, courseRepository,
                userEnrolledCoursesRepository, ValidWebhookEventIds);

            _userSubscribtionRipository = userSubscribtionRipository;
            _userManager = userManager;
            _validWebhookEventIds = ValidWebhookEventIds.Value;
            _userEnrolledCoursesRepository = userEnrolledCoursesRepository;

            _emailService = emailService;   
        }

        [HttpGet("GetAccessToken")]
        public async Task<ActionResult<GeneralResponse>> GetAccessToken()
        {
            var response = await _client.GetAuthorizationRequest();

            return new GeneralResponse
            {
                IsSuccess = response != null,
                Data = response
            };
        }

        [HttpGet("GetCurrentAccessTokenDetails")]
        public ActionResult<GeneralResponse> GetCurrentAccessTokenDetails()
        {
            var response = _client.GetCurrentAccessTokenDetails();

            return new GeneralResponse
            {
                IsSuccess = response != null,
                Data = response != null ? response : "Access token is not initialized. Please ensure you have retrieved it"
            };
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<GeneralResponse>> CreateProduct(CreateProductRequestDTO productRequestDTO)
        {
            var response = await _client.CreateProduct(productRequestDTO);

            return new GeneralResponse
            {
                IsSuccess = response != null,
                Data = response
            };
        }

        [HttpPost("CreateMonthlyPlanForProduct")]
        public async Task<ActionResult<GeneralResponse>> CreateMonthlyPlanForProduct(CreatePlanRequestDTO createPlanRequestDTO)
        {
            var response = await _client.CreateMonthlyPlan(createPlanRequestDTO);

            return new GeneralResponse
            {
                IsSuccess = response?.status != null ? true : false,
                Data = response
            };
        }

        [HttpPost("CreateSubscribtion")]
        public async Task<ActionResult<GeneralResponse>> CreateSubscribtion(CreateSubscribtionDTO createSubscribtionDTO)
        {
            ApplicationUser? userFromDb = await _userManager.FindByIdAsync(createSubscribtionDTO.UserId);
            if (userFromDb is not null && userFromDb.IsSubscribedToPlatform)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "This user has already subscribed"
                };
            }
            var response = await _client.CreateSubscriptionAsync(createSubscribtionDTO);

            return new GeneralResponse
            {
                IsSuccess = response != null,
                Data = response
            };
        }

        // Webhook endpoint to receive PayPal notifications
        [HttpPost("ActivateSubscription")]
        public async Task<ActionResult<GeneralResponse>> ActivateSubscription()  
         
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var headers = HttpContext.Request.Headers;
            bool result = false;

            if (json is not null)
            {
                // verify req first 
                bool isValid = await VerifyEvent(json , headers , _validWebhookEventIds.SubscribtionActivated);
                if(isValid)
                {
                    var webHookEvent = JsonConvert.DeserializeObject<webhookEvent>(json);

                    if (webHookEvent?.Summary == "Subscription activated")
                    {
                        result = await HandleSubscriptionActivated(webHookEvent);
                    }
                }
                else
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "unverified event"
                    };
                }
            }
            else
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "empty request payload"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = result != null? result : false,
            };
        }


        [HttpPost("ApproveOrderCheckout")]
        public async Task <ActionResult<GeneralResponse>> ApproveOrderCheckout()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var headers = HttpContext.Request.Headers;

            if (json is not null)
            {
                // verify req first 
                bool isValid = await VerifyEvent(json, headers, _validWebhookEventIds.CheckoutOrderApproved);
                if (isValid)
                {
                    var response = JsonConvert.DeserializeObject<webhookEvent>(json);

                    if (response?.Resource?.Status == "APPROVED")
                    {

                        // send money to instructor , notify ins to send money to ehab
                        var result = await _client.captureOrderAsync(response.Resource.Id);

                        if(result.IsSuccess)
                        {
                            string subject = "New Course Purchase Notification - Action Required"; // {courseFromDB.Title}

                            string htmlBody = $@"
<html>
<head>
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css"" rel=""stylesheet"">
</head>
<body>
    <div class=""container mt-4 p-4 border rounded shadow-sm"">
        <h2 class=""text-center text-primary mb-4"">Congratulations! Action Required: Platform Fee Payment</h2>
        <p>Dear <strong>Instructor</strong>,</p>
        <p>We are excited to inform you that <strong>{response.Resource.PaymentSource.Paypal.Name.GivenName} {response.Resource.PaymentSource.Paypal.Name.Surname}</strong> has purchased your course <strong>{response.Resource.PurchaseUnits[0].items[0].name}</strong> on our platform.</p>
        <div class=""alert alert-warning"" role=""alert"">
            <p><strong>Important:</strong> As per our terms and conditions, you are required to send the platform’s fee of <strong>20%</strong> from the transaction amount. Please note that the student will not be officially enrolled in your course until the platform fee has been received.</p>
        </div>
        <div class=""alert alert-danger"" role=""alert"">
            <p><strong>Urgent Notice:</strong> If the platform fee is not sent within <strong>3 days</strong>, all courses associated with your account will be deleted from the platform.</p>
        </div>
        <p class=""text-success"">To avoid any disruption, please ensure the fee is sent promptly.</p>
        <p>If you have already completed this transaction, please disregard this notice.</p>
        <hr>
        <p>Best Regards,</p>
        <p class=""text-muted"">The Platform Team</p>
    </div>
</body>
</html>

";



                            await _emailService.SendEmailAsync(response.Resource.PurchaseUnits[0].Payee.EmailAddress
                                , subject , htmlBody);

                            return new GeneralResponse()
                            {
                                IsSuccess = true,
                                Message = "Money has been transferred successfully",
                                Data = result
                            };
                        }
                        else
                        {
                            return new GeneralResponse()
                            {
                                IsSuccess = false,
                                Message = "Error happened through transferring money"
                            };
                        }
                    }
                    else
                    {
                        return new GeneralResponse()
                        {
                            IsSuccess = false,
                            Data = "Order checkout has not been approved yet"
                        };
                    }
                }
                else
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "unverified event"
                    };
                }
            }
            else
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "empty request payload"
                };
            }
        }
        // test all cycle of subscription
        private async Task<bool> HandleSubscriptionActivated(webhookEvent webhookEvent)
        {
            var subscriptionId = webhookEvent.Resource.Id;  // Subscription ID is in resource.id
            var userSubscription = _userSubscribtionRipository
                                   .Find(us => us.SubscriptionPlanId == subscriptionId);  // subscriptionPlanId represents subscriptionId

            if(userSubscription is null)
            {
                return false;
            }
         

                // get user update its prop
                var subscribedUser = await _userManager.FindByIdAsync(userSubscription.UserId);

            if(subscribedUser is null)
            { return false; }

                subscribedUser.IsSubscribedToPlatform = true;
                subscribedUser.SubscriptionMethod = SubscriptionMethod.Paypal;
                await _userManager.UpdateAsync(subscribedUser);

                userSubscription.Status = Helpers.SubscriptionStatus.ACTIVE;
                userSubscription.StartDate = DateTime.Now;
                userSubscription.EndDate = DateTime.Now.AddMonths(12);

                _userSubscribtionRipository.Update(userSubscription);
                await _userSubscribtionRipository.SaveAsync();
            return true;
            
        }


        [HttpPost("cancelSubscription")]
        public async Task <ActionResult<GeneralResponse>> cancelSubscription(webhookEvent webhookEvent)
        {

            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var headers = HttpContext.Request.Headers;
            bool isValid = await VerifyEvent(json, headers, _validWebhookEventIds.SubscriptionCancelled);

            if (true) // replace it with isvalid 
            {

                if (webhookEvent.Summary == "Subscription cancelled")
                {
                    UserSubscription? userSubscription = _userSubscribtionRipository
                                               .Find(us => us.SubscriptionPlanId == webhookEvent.Resource.Id);
                    if (userSubscription is not null)
                    {
                        if (userSubscription?.EndDate.Day > DateTime.Today.Day)
                        {
                            // use isdayfoundinmonth before build date

                            if (isDayFoundInMonth(userSubscription.EndDate.Day, DateTime.Today.Month))
                            {
                                userSubscription.EndDate = new DateTime(DateTime.Today.Year
                                , DateTime.Today.Month, userSubscription.EndDate.Day);
                            }
                            else
                            {
                                userSubscription.EndDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1);
                            }

                        }
                        else
                        {
                            if (DateTime.Today.Month != 12)
                            {
                                if (isDayFoundInMonth(userSubscription.EndDate.Day, DateTime.Today.Month + 1))
                                {
                                    userSubscription.EndDate = new DateTime(DateTime.Today.Year,
                                        DateTime.Today.Month + 1, userSubscription.EndDate.Day);
                                }
                                else
                                {
                                    userSubscription.EndDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 2, 1);
                                }

                            }
                            else
                            {
                                if (isDayFoundInMonth(userSubscription.EndDate.Day, 1))
                                {
                                    userSubscription.EndDate = new DateTime(DateTime.Today.Year + 1,
                                  1, userSubscription.EndDate.Day);
                                }
                                else
                                {
                                    userSubscription.EndDate = new DateTime(DateTime.Today.Year + 1, 2, 1);
                                }

                            }
                        }
                        userSubscription.UpdatedAt = DateTime.Now;  // to use it on job, as filter to minimize number of records to be affected every day for better performance
                        _userSubscribtionRipository.Update(userSubscription);
                        await _userSubscribtionRipository.SaveAsync();
                        // job to check end dates then make issubscribed false or cehecking subscribtion using enddates regardless flag

                        // send mail to notify user

                        ApplicationUser? user = await _userManager.FindByIdAsync("59e7780d-e3fc-4017-ac92-9411a3da168b");
                        if (user == null)
                        {
                            return new GeneralResponse()
                            {
                                IsSuccess = false,
                                Message = "No user was found for this id"
                            };
                        }

                        string subject = "Subscription Cancellation Confirmation";

                        string htmlBody = $@"
<html>
<head>
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css"" rel=""stylesheet"">
</head>
<body>
    <div class=""container mt-4 p-4 border rounded shadow-sm"">
        <h2 class=""text-center text-primary mb-4"">Subscription Cancellation Confirmation</h2>
        <p>Dear <strong>User</strong>,</p>
        <p>We would like to confirm that your premium subscription has been successfully canceled.</p>
        <div class=""alert alert-info"" role=""alert"">
            <p>Your subscription will remain active until the end of your billing period. The last day of your premium plan will be <strong>{userSubscription.EndDate}</strong>.</p>
        </div>
        <p class=""text-success"">We’re sad to see you go, but we hope to serve you again in the future!</p>
        <p>If you wish to reactivate your subscription or explore other plans, feel free to visit our platform at any time.</p>
        <hr>
        <p>Thank you for being a valued part of our community.</p>
        <p>Best Regards,</p>
        <p class=""text-muted"">The Platform Team</p>
    </div>
</body>
</html>
";


                        await _emailService.SendEmailAsync(user.Email, subject, htmlBody);

                        return new GeneralResponse()
                        {
                            IsSuccess = true,
                            Message = "Subscription has been cancelled successfully"
                        };

                    }
                    else
                    {
                        return new GeneralResponse()
                        {
                            IsSuccess = false,
                            Message = "No user was found for this subscription id"
                        };
                    }


                }
                else
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "event summary is not cancelled"
                    };
                }


            }
            else
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Unverified event"
                };
            }

        }


        private bool isDayFoundInMonth(int day , int month)
        {
            int[] largeMonths = { 1, 3, 5, 7, 8, 10, 12 }; // months that contain 31 day
            int[] smallMonths = { 4, 6, 9, 11};  // months that contain 30 day

            if (largeMonths.Contains(month))
            {
                return true;    
            }
            else if(smallMonths.Contains(month))
            {
                if(day > 30)
                {
                    return false;
                }
                return true;
            }
            else // handle februaury case
            {
                if(DateTime.IsLeapYear(DateTime.Today.Year))
                {
                    if(day <= 29)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (day <= 28)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private async Task<bool> VerifyEvent(string json, IHeaderDictionary headerDictionary, string WebhookId)
        {
            var isValidEvent = await _client.VerifyEvent(json, headerDictionary, WebhookId);
            return isValidEvent;
        }

     

        [HttpPost("BuyCourse")]
        public async Task<ActionResult<GeneralResponse>> BuyCourse(BuyCourseDTO buyCourseDTO)
        {
            var response = await _client.BuyCourse(buyCourseDTO);

            return response;
        }

    }
}