﻿using Educational_Medical_platform.DTO.PayPal;
using Educational_Medical_platform.PayPal.Models;
using Newtonsoft.Json;
using PayPal.Configuration;
using PayPal.Models.Requests;
using PayPal.Models.Responses;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Educational_Medical_platform.PayPal
{
    public class PayPalClientApi
    {
        private HttpClient? _client;

        private string? _accessToken;

        private DateTime _tokenExpiration;

        public PayPalClientApi()
        {
            _client = new HttpClient();
            InitializeHttpClient().Wait();
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

        public async Task<CreatePlanResponse> GetPlanDetails(string planId)
        {
            EnsureHttpClientCreated();

            var response = await _client.GetAsync($"{ConfigHelper.BaseUrl}/v1/billing/plans/{planId}");

            var responseAsString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CreatePlanResponse>(responseAsString);

            return result;
        }

        public async Task<CreateSubscriptionResponse> CreateSubscription(CreateSubscriptionRequest request)
        {
            EnsureHttpClientCreated();

            var requestContent = JsonConvert.SerializeObject(request);

            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/billing/subscriptions", httpRequestMessage.Content);

            var responseAsString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CreateSubscriptionResponse>(responseAsString);

            return result;
        }

        public async Task<bool> ActiveSubscription(string id, SubscriptionStatusChangeRequest request)
        {
            EnsureHttpClientCreated();


            var requestContent = JsonConvert.SerializeObject(request);

            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/billing/subscriptions/{id}/activate", httpRequestMessage.Content);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> SuspendSubscription(string id, SubscriptionStatusChangeRequest request)
        {
            EnsureHttpClientCreated();

            var requestContent = JsonConvert.SerializeObject(request);

            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/billing/subscriptions/{id}/suspend", httpRequestMessage.Content);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> CancelSubscription(string id, SubscriptionStatusChangeRequest request)
        {
            EnsureHttpClientCreated();

            var requestContent = JsonConvert.SerializeObject(request);

            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _client.PostAsync($"{ConfigHelper.BaseUrl}/v1/billing/subscriptions/{id}/cancel", httpRequestMessage.Content);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> RefundSubscriptionAmount(string refundUrl, RefundRequest request)
        {
            EnsureHttpClientCreated();

            var requestContent = JsonConvert.SerializeObject(request);

            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _client.PostAsync(refundUrl, httpRequestMessage.Content);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

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
				""webhook_id"": ""6WC685942N447610S"",
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
    }
}