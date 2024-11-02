using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.PayPal;
using Educational_Medical_platform.PayPal;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayPal.Models;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayPalController : ControllerBase
    {
        private readonly PayPalClientApi _client;
        private readonly IUserSubscribtionRipository _userSubscribtionRipository;

        public PayPalController(
            IUserSubscribtionRipository userSubscribtionRipository,
            IPlatformRepository platformRepository,
            UserManager<ApplicationUser> userManager,
            ICourseRepository courseRepository)
        {
            _client = new PayPalClientApi(userSubscribtionRipository, platformRepository, userManager, courseRepository);

            _userSubscribtionRipository = userSubscribtionRipository;
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
            var response = await _client.CreateSubscriptionAsync(createSubscribtionDTO);

            return new GeneralResponse
            {
                IsSuccess = response != null,
                Data = response
            };
        }

        // Webhook endpoint to receive PayPal notifications
        [HttpPost("HandlePayPalWebhook")]
        public async Task<IActionResult> HandlePayPalWebhook([FromBody] WebHookEvent webhookEvent)
        {
            if (webhookEvent.event_type == "BILLING.SUBSCRIPTION.ACTIVATED")
            {
                await HandleSubscriptionActivated(webhookEvent);
            }

            return Ok();
        }

        private async Task HandleSubscriptionActivated(WebHookEvent webhookEvent)
        {
            var subscriptionId = webhookEvent.resource.id;  // Subscription ID is in resource.id
            var userSubscription = _userSubscribtionRipository
                                   .Find(us => us.SubscriptionPlanId == subscriptionId);

            if (userSubscription != null)
            {
                userSubscription.Status = Helpers.SubscriptionStatus.ACTIVE;
                userSubscription.StartDate = DateTime.Now;
                userSubscription.EndDate = DateTime.Now.AddMonths(12);

                _userSubscribtionRipository.Update(userSubscription);
                await _userSubscribtionRipository.SaveAsync();
            }
        }

        [HttpPost("HandleSubscriptionWebhook")]
        public async Task<IActionResult> HandleSubscriptionWebhook()
        {
            return Ok();
        }

        [HttpPost("BuyCourse")]
        public async Task<ActionResult<GeneralResponse>> BuyCourse(BuyCourseDTO buyCourseDTO)
        {
            var response = await _client.BuyCourse(buyCourseDTO);

            return response;
        }

        // webhook on approve subscription 
        // => get the application user and do this : 1/ IsSubscribed = true ,,,, 2/subscripedmethod = paypal

        // webhook approve order
        // => capture order 
        // => then notification(mail) to instructor that he should transfere platform part of money 20% to admin Dr Ehab
        // then the instructor will use the existed end point in course controller called :(RequestEnrollStudentInCourse)

        //=================================================================

        //[HttpPost("api/checkout/webhook")]
        //[AllowAnonymous]
        //public async Task<IActionResult> HandleWebhook()
        //{
        //    var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        //    var headers = HttpContext.Request.Headers;

        //    var isValidEvent = await VerifyEvent(json, headers);

        //    if (isValidEvent)
        //    {
        //        var webhookEvent = JsonConvert.DeserializeObject<WebHookEvent>(json);

        //        switch (webhookEvent.event_type)
        //        {
        //            case "BILLING.SUBSCRIPTION.ACTIVATED":
        //                // Activate the subscription -- Use webhookEvent.resource to get event data
        //                break;
        //            case "BILLING.SUBSCRIPTION.CANCELLED":
        //                // Cancel the subscription -- Use webhookEvent.resource to get event data
        //                break;
        //            case "PAYMENT.SALE.COMPLETED":
        //                // Add Recurring Payment -- Use webhookEvent.resource to get event data
        //                break;
        //        }
        //        //https://api.sandbox.paypal.com/v1/payments/sale/94B86548SC282320N/refund
        //        //I-TBHAH1F8HLEM
        //        return Ok("Success");
        //    }
        //    return BadRequest();
        //}

        // should be ther is web hook when user approves => Go capture payment => then create enroll request to admin and update database

        /*   [HttpPost("api/checkout/webhook")]
        [AllowAnonymous]
        public async Task<IActionResult> HandleWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var headers = HttpContext.Request.Headers;

            var isValidEvent = await VerifyEvent(json, headers);

            if (isValidEvent)
            {
                var webhookEvent = JsonConvert.DeserializeObject<WebHookEvent>(json);

                switch (webhookEvent.event_type)
                {
                    case "BILLING.SUBSCRIPTION.ACTIVATED":
                        // Activate the subscription -- Use webhookEvent.resource to get event data
                        break;
                    case "BILLING.SUBSCRIPTION.CANCELLED":
                        // Cancel the subscription -- Use webhookEvent.resource to get event data
                        break;
                    case "PAYMENT.SALE.COMPLETED":
                        // Add Recurring Payment -- Use webhookEvent.resource to get event data
                        break;
                }
                //https://api.sandbox.paypal.com/v1/payments/sale/94B86548SC282320N/refund
                //I-TBHAH1F8HLEM
                return Ok("Success");
            }
            return BadRequest();
        }

        private async Task<bool> VerifyEvent(string json, IHeaderDictionary headerDictionary)
        {
            var paypalHelper = new PayPalClientApi();
            var response = await paypalHelper.GetAuthorizationRequest();
            paypalHelper.SetToken(response.access_token);

            var isValidEvent = await paypalHelper.VerifyEvent(json, headerDictionary);

            return isValidEvent;

        }

         */
    }
}