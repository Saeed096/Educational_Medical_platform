using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.PayPal;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.PayPal.Models;
using Educational_Medical_platform.PayPal.Models.Responses;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PayPal.Configuration;
using PayPal.Models.Requests;
using PayPal.Models.Responses;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;
using System.Net.Http.Headers;
using System.Text;

namespace Educational_Medical_platform.PayPal
{
    public class PayPalClientApi
    {
        private HttpClient? _client;
        private string? _accessToken;
        private DateTime _tokenExpiration;
        private readonly IUserSubscribtionRipository _userSubscribtionRipository;
        private readonly IPlatformRepository _platformRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserEnrolledCoursesRepository _userEnrolledCoursesRepository;
        private readonly ValidWebhookEventIds _validWebhookEventIds;

        public PayPalClientApi(
            IUserSubscribtionRipository userSubscribtionRipository,
            IPlatformRepository platformRepository,
            UserManager<ApplicationUser> userManager,
            ICourseRepository courseRepository,
            IUserEnrolledCoursesRepository userEnrolledCoursesRepository,
             IOptions<ValidWebhookEventIds> ValidWebhookEventIds
            )
        {
            _client = new HttpClient();
            InitializeHttpClient().Wait();
            _userSubscribtionRipository = userSubscribtionRipository;
            _platformRepository = platformRepository;
            _userManager = userManager;
            _courseRepository = courseRepository;
            _userEnrolledCoursesRepository = userEnrolledCoursesRepository;
            _validWebhookEventIds = ValidWebhookEventIds.Value;
        }

        private async Task InitializeHttpClient()
        {
            await EnsureValidAccessTokenAsync();
        }

        public async Task EnsureValidAccessTokenAsync()
        {
            if (_accessToken == null || DateTime.UtcNow >= _tokenExpiration)
            {
                var tokenResponse = await GetAuthorizationRequest();
                if (tokenResponse != null)
                {
                    _accessToken = tokenResponse.access_token;
                    _tokenExpiration = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in);
                }
                else
                {
                    throw new InvalidOperationException("Failed to retrieve access token.");
                }
            }

            SetAuthorizationHeader(_accessToken);
        }

        private void SetAuthorizationHeader(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);   // to be studied
        }

        public async Task<AuthorizationResponseData?> GetAuthorizationRequest()
        {
            EnsureHttpClientCreated();

            var byteArray = Encoding.ASCII.GetBytes($"{ConfigHelper.ClientId}:{ConfigHelper.ClientSecret}");  // to be studied
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));   

            var keyValuePairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            };

            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/oauth2/token", new FormUrlEncodedContent(keyValuePairs));
            response.EnsureSuccessStatusCode(); // Throw if not a success code.

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthorizationResponseData>(responseAsString);
        }

        private void EnsureHttpClientCreated()
        {
            if (_client == null)
            {
                _client = new HttpClient();
                InitializeHttpClient().Wait();
            }
        }

        public AccessTokenDetails? GetCurrentAccessTokenDetails()
        {
            if (_accessToken == null)
            {
                return null;
            }

            return new AccessTokenDetails
            {
                AccessToken = _accessToken,
                Expiration = _tokenExpiration
            };
        }

        public async Task<CreateProductResponse?> CreateProduct(CreateProductRequestDTO productRequestDTO)
        {
            await EnsureValidAccessTokenAsync();

            var newProduct = new CreateProductRequest
            {
                name = productRequestDTO.Name,
                description = productRequestDTO.Description,
                type = "DIGITAL",
                category = "ACADEMIC_SOFTWARE",
                //image_url = "https://example.com/streaming.jpg",
                //home_url = "https://example.com/home",
            };

            var jsonContent = JsonConvert.SerializeObject(newProduct);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/catalogs/products", httpContent);

            var responseAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CreateProductResponse>(responseAsString);

            return result;
        }

        public async Task<CreatePlanResponse?> CreateMonthlyPlan(CreatePlanRequestDTO request)
        {
            EnsureHttpClientCreated();

            await EnsureValidAccessTokenAsync();

            var newPlanRequestBody = new CreatePlanRequest
            {
                product_id = request.ProductId,
                name = request.Name,
                description = request.Description,
                status = "ACTIVE",
                billing_cycles = new List<BillingCycle>
                {
                    new BillingCycle
                    {
                        frequency =  new Frequency
                        {
                            interval_unit = "MONTH",
                            interval_count = 1
                        },
                        tenure_type = "REGULAR",
                        sequence = 1,
                        total_cycles = 0,
                        pricing_scheme = new PricingScheme
                        {
                            fixed_price = new FixedPrice
                            {
                                value = request.FixedPrice.ToString(),
                                currency_code = "USD"
                            }
                        }
                    }
                },
                payment_preferences = new PaymentPreferences
                {
                    auto_bill_outstanding = true,
                    setup_fee = new SetupFee
                    {
                        value = (request.FixedPrice / 10).ToString(),
                        currency_code = "USD"
                    },
                    setup_fee_failure_action = "CONTINUE",
                    payment_failure_threshold = 3
                },
                taxes = new Taxes
                {
                    percentage = request.TaxesPercentage.ToString(),
                    inclusive = false
                }
            };

            var requestContent = JsonConvert.SerializeObject(newPlanRequestBody);
            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/billing/plans", httpRequestMessage.Content);
            var responseAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CreatePlanResponse>(responseAsString);

            return result;
        }

        // ===================================== Create Subscription ====================================

        public async Task<CreateSubscriptionResponse?> CreateSubscriptionAsync(CreateSubscribtionDTO request)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return null;
            }

            EnsureHttpClientCreated();
            await EnsureValidAccessTokenAsync();

            // Ensure the platform product exists and valid => unless Create new one
            var platformProductResponse = await EnsurePlatformProductCreatedAsync();

            // Ensure the plan exists and valid => unless Create new one
            var planResponse = await EnsurePlatformPlanCreatedAsync(platformProductResponse.id);

            // Create the subscription
            var newSubscriptionRequestBody = new CreateSubscriptionRequest
            {
                plan_id = planResponse.id,
                subscriber = new Subscriber
                {
                    name = new Name
                    {
                        given_name = request.SubscriberFirstName,
                        surname = request.SubscriberLastName
                    },
                    email_address = request.SubscriberEmail
                },
                application_context = new ApplicationContext
                {
                    brand_name = "MedicalHub Platform",
                    shipping_preference = "NO_SHIPPING",
                    locale = "en-US",
                    user_action = "SUBSCRIBE_NOW",
                    payment_method = new PaymentMethod
                    {
                        payer_selected = "PAYPAL",
                        payee_preferred = "IMMEDIATE_PAYMENT_REQUIRED"
                    },
                    return_url = "https://example.com/return",
                    cancel_url = "https://example.com/cancel"
                }
            };

            var requestContent = JsonConvert.SerializeObject(newSubscriptionRequestBody);
            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/billing/subscriptions", new StringContent(requestContent, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                CreateSubscriptionResponse subscriptionResponse = JsonConvert.DeserializeObject<CreateSubscriptionResponse>(responseAsString);

                // Save the subscription in the database
                var userSubscription = new UserSubscription
                {
                    CreatedAt = DateTime.Now,
                    StartDate = subscriptionResponse.start_time,
                    EndDate = DateTime.Now.AddMonths(12),

                    UserId = request.UserId,
                    Status = SubscriptionStatus.APPROVAL_PENDING,
                    SubscriptionPlanId = subscriptionResponse.id
                };

                await _userSubscribtionRipository.AddAsync(userSubscription);
                await _userSubscribtionRipository.SaveAsync();

                return subscriptionResponse;
            }
            else
            {
                // Handle failure case here
                return null;
            }
        }

        private async Task<CreateProductResponse?> EnsurePlatformProductCreatedAsync()
        {
            // Retrieve platform data from the local database
            PlatformData? platformData = _platformRepository.Find();

            if (platformData == null)
            {
                platformData = new PlatformData();

                _platformRepository.Add(platformData);
                await _platformRepository.SaveAsync();
            }

            // If ProductId is not found locally, create a new product
            if (string.IsNullOrEmpty(platformData?.ProductId))
            {
                var createdProduct = await CreatePlatformProductAsync();

                // Store the newly created product ID in your database
                platformData.ProductId = createdProduct.id;
                platformData.ProductName = createdProduct.name;
                platformData.ProductDescribtion = createdProduct.description;

                _platformRepository.Update(platformData);
                await _platformRepository.SaveAsync();

                return createdProduct;
            }

            // Call PayPal API to check if the product exists
            var response = await _client.GetAsync($"{ConfigHelper.BaseUrl}/v1/catalogs/products/{platformData.ProductId}");
            if (response.IsSuccessStatusCode)
            {
                // Product exists, return response as no new product creation is required
                return new CreateProductResponse()
                {
                    id = platformData.ProductId,
                    name = platformData?.ProductName ?? string.Empty,
                    description = platformData?.ProductDescribtion ?? string.Empty,
                };
            }

            // If PayPal product check fails, create a new product
            return await CreatePlatformProductAsync();
        }

        private async Task<CreateProductResponse> CreatePlatformProductAsync()
        {
            var newProduct = new CreateProductRequest
            {
                name = "MedicalHub Platform",
                description = "MedicalHub Platform Subscription",
                type = "DIGITAL",
                category = "ACADEMIC_SOFTWARE"
            };

            var jsonContent = JsonConvert.SerializeObject(newProduct);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/catalogs/products", httpContent);

            var responseAsString = await response.Content.ReadAsStringAsync();
            CreateProductResponse? result = JsonConvert.DeserializeObject<CreateProductResponse>(responseAsString);

            return result;
        }

        private async Task<CreatePlanResponse> EnsurePlatformPlanCreatedAsync(string productId)
        {
            // Check your database for the existing plan ID
            var platformData = _platformRepository.Find();

            if (platformData == null)
            {
                platformData = new PlatformData();

                platformData.ProductId = productId;

                _platformRepository.Add(platformData);
                await _platformRepository.SaveAsync();
            }

            if (string.IsNullOrEmpty(platformData.PlanId))
            {
                CreatePlanResponse createPlanResponse = await CreatePlatformPlanAsync(productId);

                return createPlanResponse;
            }

            // Call PayPal API to check the plan
            var response = await _client.GetAsync($"{ConfigHelper.BaseUrl}/v1/billing/plans/{platformData.PlanId}");
            if (response.IsSuccessStatusCode)
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                CreatePlanResponse? planResponse = JsonConvert.DeserializeObject<CreatePlanResponse>(responseAsString);

                platformData.PlanId = planResponse.id;
                platformData.PlanName = planResponse.name;
                platformData.PlanDescription = planResponse.description;
                platformData.PlanFixedPricePerMonth = decimal.Parse(planResponse.billing_cycles.FirstOrDefault().pricing_scheme.fixed_price.value);

                await _platformRepository.SaveAsync();

                // Plan exists on PayPal, return it
                return planResponse;
            }
            else
            {
                var newPlanResponse = await CreatePlatformPlanAsync(productId);

                var responseAsString = await response.Content.ReadAsStringAsync();
                CreatePlanResponse? planResponse = JsonConvert.DeserializeObject<CreatePlanResponse>(responseAsString);

                platformData.PlanId = planResponse.id;
                platformData.PlanName = planResponse.name;
                platformData.PlanDescription = planResponse.description;
                platformData.PlanFixedPricePerMonth = decimal.Parse(planResponse.billing_cycles.FirstOrDefault().pricing_scheme.fixed_price.value);

                await _platformRepository.SaveAsync();

                return newPlanResponse;
            }
        }

        private async Task<CreatePlanResponse> CreatePlatformPlanAsync(string productId)
        {
            PlatformData? platformData = _platformRepository.Find();

            var newPlan = new CreatePlanRequest
            {
                product_id = productId,
                name = "MedicalHub Platform Monthly Plan",
                description = "Monthly subscription to MedicalHub",
                billing_cycles = new List<BillingCycle>
                {
                    new BillingCycle
                    {
                        frequency = new Frequency
                        {
                            interval_unit = "MONTH",
                            interval_count = 1
                        },
                        tenure_type = "REGULAR",
                        sequence = 1,
                        total_cycles = 12,
                        pricing_scheme = new PricingScheme
                        {
                            fixed_price = new FixedPrice
                            {
                                currency_code = "USD",
                                value = platformData?.PlanFixedPricePerMonth?.ToString() ?? "20"
                            }
                        }
                    }
                },
                payment_preferences = new PaymentPreferences
                {
                    auto_bill_outstanding = true,
                    setup_fee = new SetupFee
                    {
                        currency_code = "USD",
                        value = platformData?.PlanSetupFee?.ToString() ?? "2"
                    },
                    setup_fee_failure_action = "CONTINUE",
                    payment_failure_threshold = 3
                },
                taxes = new Taxes
                {
                    percentage = platformData?.PlanTaxesPercentage?.ToString() ?? "10",
                    inclusive = false
                }
            };

            var jsonContent = JsonConvert.SerializeObject(newPlan);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/billing/plans", httpContent);

            var responseAsString = await response.Content.ReadAsStringAsync();
            var planResponse = JsonConvert.DeserializeObject<CreatePlanResponse>(responseAsString);

            if (response.IsSuccessStatusCode)
            {
                return planResponse;

            }
            else
            {
                return null;
            }
        }

        // ----------------------------------- Handle Subscription Web Hook ------------------------------

        public async Task<bool> VerifyEvent(string json, IHeaderDictionary headerDictionary)
        {
            // !!IMPORTANT!!
            // Without this direct JSON serialization, PayPal WILL ALWAYS return verification_status = "FAILURE".
            // This is probably because the order of the fields are different and PayPal does not sort them. 
            var paypalVerifyRequestJsonString = $@"{{
				""transmission_id"": ""{headerDictionary["PAYPAL-TRANSMISSION-ID"][0]}"",
				""transmission_time"": ""{headerDictionary["PAYPAL-TRANSMISSION-TIME"][0]}"",
				""cert_url"": ""{headerDictionary["PAYPAL-CERT-URL"][0]}"",
				""auth_algo"": ""{headerDictionary["PAYPAL-AUTH-ALGO"][0]}"",
				""transmission_sig"": ""{headerDictionary["PAYPAL-TRANSMISSION-SIG"][0]}"",
				""webhook_id"": ""3KB13201FY811394L"",
				""webhook_event"": {json}
				}}";

            var content = new StringContent(paypalVerifyRequestJsonString, Encoding.UTF8, "application/json");

            var resultResponse = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/notifications/verify-webhook-signature", content);

            var responseBody = await resultResponse.Content.ReadAsStringAsync();

            var verifyWebhookResponse = JsonConvert.DeserializeObject<WebHookVerificationResponse>(responseBody);

            if (verifyWebhookResponse.verification_status != "SUCCESS")
            {
                return false;
            }

            return true;
        }

        // ======================================== Buy Course ============================================

        public async Task<GeneralResponse> BuyCourse(BuyCourseDTO buyCourseDTO)
        {
            EnsureHttpClientCreated();

            await EnsureValidAccessTokenAsync();

            var courseFromDB = _courseRepository.Find(c => c.Id == buyCourseDTO.CourseId);

            if (courseFromDB == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "No course found with this ID"
                };
            }

            var buyerUser = await _userManager.FindByIdAsync(buyCourseDTO.UserId);
            if (buyerUser == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No Buyer User found with this ID : {buyCourseDTO.UserId}"
                };
            }

            var instructorUser = await _userManager.FindByIdAsync(courseFromDB.InstructorId);
            if (instructorUser == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No Instructor User found with this ID : {courseFromDB.InstructorId}"
                };
            }

            if (buyerUser == instructorUser)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"The instructor can't buy his own course !"
                };
            }

           var userEnrolledCourseFromDb = _userEnrolledCoursesRepository
                                          .Find(u => u.CourseId == buyCourseDTO.CourseId && u.StudentId == buyCourseDTO.UserId);

            if (userEnrolledCourseFromDb != null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "This user has already bought this course before"
                };
            }
            //---------------------------------------------------------------

            var createCourseProductResponse = await EnsureCourseProductCreated(courseFromDB);

            if (!createCourseProductResponse.IsSuccess)
            {
                return createCourseProductResponse;
            }

            var createOrderResponse = await EnsureCourseOrderCreatedAsync(courseFromDB, instructorUser);


            return createOrderResponse;

            // capture payment I will do it in web hook after the customer approves
            //   CapturePaymentForOrderResponse capturePaymentForOrderResponse = await CapturePaymentForOrderAsync(createOrderResponse.id);

        }

        private async Task<GeneralResponse> EnsureCourseProductCreated(Course courseFromDB)
        {
            if (string.IsNullOrEmpty(courseFromDB.PaypalProductId))
            {
                var createProductResponse = await CreateCourseProductAsync(courseFromDB);

                return createProductResponse;
            }

            // ensure prod is valid => call show prod details api => if success OK => else creare paypal prod and update your SQL

            // Call PayPal API to check if the product exists
            var response = await _client.GetAsync($"{ConfigHelper.BaseUrl}/v1/catalogs/products/{courseFromDB.PaypalProductId}");
            if (response.IsSuccessStatusCode)
            {
                // Product exists, return response as no new product creation is required
                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Product Details Retrieved successfully",
                    Data = new CreateProductResponse()
                    {
                        id = courseFromDB.PaypalProductId,
                        name = courseFromDB.Title,
                        description = courseFromDB.Preview
                    }
                };
            }
            else
            {
                // If PayPal product check fails, create a new product
                var newProdRespose = await CreateCourseProductAsync(courseFromDB); // could be null

                return newProdRespose;
            }
        }

        private async Task<GeneralResponse> CreateCourseProductAsync(Course courseFromDB)
        {
            // create paypal prod then update your SQL
            //if(!string.IsNullOrEmpty(courseFromDB.Preview))
            //{
                var newProduct = new CreateProductRequest
                {
                    name = $"{courseFromDB.Title}",
                    description = $"{courseFromDB.Preview?? "NA"}",
                    type = "DIGITAL",
                    category = "ACADEMIC_SOFTWARE"
                };
            //}
            //else
            //{
            //    var newProduct = new CreateProductRequest
            //    {
            //        name = $"{courseFromDB.Title}",
            //        type = "DIGITAL",
            //        category = "ACADEMIC_SOFTWARE"
            //    };
            //}
            

            var jsonContent = JsonConvert.SerializeObject(newProduct);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/catalogs/products", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CreateProductResponse>(responseAsString);

                courseFromDB.PaypalProductId = result.id;
                await _courseRepository.SaveAsync();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Course Product Created Susccessfully",
                    Data = result
                };
            }
            else
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Error happened during creating Course Product",
                    Data = response
                };
            }
        }

        private async Task<GeneralResponse> EnsureCourseOrderCreatedAsync(Course courseFromDB, ApplicationUser instructor)
        {
            // create order put the value and the instructor paypal mail
            CreateOrderRequest createOrderRequest = new CreateOrderRequest
            {
                intent = "CAPTURE",
                purchase_units = new List<Models.Responses.PurchaseUnit>
                {
                    new Models.Responses.PurchaseUnit
                    {
                        amount = new Models.Responses.Amount
                        {
                            // I found that paypal takes 5-6 % fees
                            // TODO : The front end should display this note to user + aslo the same for taxes and Fees at the subscription
                            value = (courseFromDB.Price + (0.06m * courseFromDB.Price)).ToString("F2") ,
                            currency_code = "USD",
                            breakdown = new Breakdown()
                            {
                                item_total = new ItemTotal()
                                {
                                    currency_code = "USD",
                                    value = (courseFromDB.Price + (0.06m * courseFromDB.Price)).ToString("F2")
                                }
                            }
                        },
                        
                         payee = new Models.Responses.Payee
                        {
                            // should validate here that this mail is valid for payal????
                            email_address = instructor.Email  // "sb-zlsua33259933@business.example.com"
                        },
                         items = new List<Item>()
                         {
                             new Item()
                             {
                                 name = courseFromDB.Title,
                                 quantity = "1" ,
                                 unit_amount = new UnitAmount()
                                 {
                                   currency_code = "USD",
                                   value = (courseFromDB.Price + (0.06m * courseFromDB.Price)).ToString("F2")
                                 }
                             }
                         }
                    }
                },
               
            };

            var jsonContent = JsonConvert.SerializeObject(createOrderRequest);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v2/checkout/orders", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                CreateOrderResponse? result = JsonConvert.DeserializeObject<CreateOrderResponse>(responseAsString);

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Course Order Created Successfully , Redirect the buyer to approve link",
                    Data = result
                };
            }
            else
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Error happened in Course Order Creating",
                    Data = response
                };
            }
        }

        // ================================================================================================

        public async Task<bool> VerifyEvent(string json, IHeaderDictionary headerDictionary , string WebhookId)
        {
            // !!IMPORTANT!!
            // Without this direct JSON serialization, PayPal WILL ALWAYS return verification_status = "FAILURE".
            // This is probably because the order of the fields are different and PayPal does not sort them. 
            var paypalVerifyRequestJsonString = $@"{{
				""transmission_id"": ""{headerDictionary["PAYPAL-TRANSMISSION-ID"][0]}"",
				""transmission_time"": ""{headerDictionary["PAYPAL-TRANSMISSION-TIME"][0]}"",
				""cert_url"": ""{headerDictionary["PAYPAL-CERT-URL"][0]}"",
				""auth_algo"": ""{headerDictionary["PAYPAL-AUTH-ALGO"][0]}"",
				""transmission_sig"": ""{headerDictionary["PAYPAL-TRANSMISSION-SIG"][0]}"",
				""webhook_id"": ""{WebhookId}"",  
				""webhook_event"": {json}
				}}"; // to be changed to omar webhook id

            var content = new StringContent(paypalVerifyRequestJsonString, Encoding.UTF8, "application/json");

            var resultResponse = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/notifications/verify-webhook-signature", content);

            var responseBody = await resultResponse.Content.ReadAsStringAsync();

            var verifyWebhookResponse = JsonConvert.DeserializeObject<WebHookVerificationResponse>(responseBody);

            if (verifyWebhookResponse.verification_status != "SUCCESS")
            {
                return false;
            }

            return true;
        }

        public async Task<GeneralResponse> captureOrderAsync(string orderId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post , $"{ConfigHelper.BaseUrl}/v2/checkout/orders/{orderId}/capture");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {_accessToken}");
            request.Content = new StringContent("", Encoding.UTF8, "application/json"); // Empty JSON body with correct Content-Type
            var response = await _client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Message = "Money has been transferred successfully"
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

    }
}