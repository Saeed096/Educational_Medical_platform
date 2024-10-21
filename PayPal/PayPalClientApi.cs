using Educational_Medical_platform.DTO.PayPal;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.PayPal.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Newtonsoft.Json;
using PayPal.Configuration;
using PayPal.Models.Requests;
using PayPal.Models.Responses;
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

        public PayPalClientApi(
            IUserSubscribtionRipository userSubscribtionRipository,
            IPlatformRepository platformRepository)
        {
            _client = new HttpClient();
            InitializeHttpClient().Wait();
            _userSubscribtionRipository = userSubscribtionRipository;
            _platformRepository = platformRepository;
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
            if (_client.DefaultRequestHeaders.Authorization != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<AuthorizationResponseData?> GetAuthorizationRequest()
        {
            EnsureHttpClientCreated();

            var byteArray = Encoding.ASCII.GetBytes($"{ConfigHelper.ClientId}:{ConfigHelper.ClientSecret}");
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
                        total_cycles = 12,
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

        //public async Task<CreatePlanResponse> GetPlanDetails(string planId)
        //{
        //    EnsureHttpClientCreated();

        //    await EnsureValidAccessTokenAsync();

        //   var planId = await EnsurePlatformPlanCreatedAsync();

        //    var response = await _client.GetAsync($"{ConfigHelper.BaseUrl}/v1/billing/plans/{planId}");

        //    var responseAsString = await response.Content.ReadAsStringAsync();

        //    var result = JsonConvert.DeserializeObject<CreatePlanResponse>(responseAsString);

        //    return result;
        //}

        public async Task<CreateSubscriptionResponse?> CreateSubscriptionAsync(CreateSubscribtionDTO request)
        {
            EnsureHttpClientCreated();
            await EnsureValidAccessTokenAsync();

            // Ensure the platform product exists
            var platformProductResponse = await EnsurePlatformProductCreatedAsync();

            // Ensure the plan exists (you'd implement similar logic as for the product)
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

        //-----------------------------------------------------------------

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

    }
}