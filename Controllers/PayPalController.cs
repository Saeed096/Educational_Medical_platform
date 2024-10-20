﻿using Educational_Medical_platform.DTO.PayPal;
using Educational_Medical_platform.PayPal;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayPal.Models;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;
using System.Text.Json;

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
            UserManager<ApplicationUser> userManager)
        {
            _client = new PayPalClientApi(userSubscribtionRipository, platformRepository, userManager);

            _userSubscribtionRipository = userSubscribtionRipository;

        }

        [HttpGet("/GetAccessToken")]
        public async Task<ActionResult<GeneralResponse>> GetAccessToken()
        {
            var response = await _client.GetAuthorizationRequest();

            return new GeneralResponse
            {
                IsSuccess = response != null ? true : false,
                Data = response
            };
        }

        [HttpGet("/GetCurrentAccessTokenDetails")]
        public ActionResult<GeneralResponse> GetCurrentAccessTokenDetails()
        {
            var response = _client.GetCurrentAccessTokenDetails();

            return new GeneralResponse
            {
                IsSuccess = response != null ? true : false,
                Data = response != null ? response : "Access token is not initialized. Please ensure you have retrieved it"
            };
        }

        [HttpPost("/CreateProduct")]
        public async Task<ActionResult<GeneralResponse>> CreateProduct(CreateProductRequestDTO productRequestDTO)
        {
            var response = await _client.CreateProduct(productRequestDTO);

            return new GeneralResponse
            {
                IsSuccess = response != null ? true : false,
                Data = response
            };
        }

        [HttpPost("/CreateMonthlyPlanForProduct")]
        public async Task<ActionResult<GeneralResponse>> CreateMonthlyPlanForProduct(CreatePlanRequestDTO createPlanRequestDTO)
        {
            var response = await _client.CreateMonthlyPlan(createPlanRequestDTO);

            return new GeneralResponse
            {
                IsSuccess = response?.status != null ? true : false,
                Data = response
            };
        }

        [HttpPost("/CreateSubscribtion")]
        public async Task<ActionResult<GeneralResponse>> CreateSubscribtion(CreateSubscribtionDTO createSubscribtionDTO)
        {
            var response = await _client.CreateSubscriptionAsync(createSubscribtionDTO);

            return new GeneralResponse
            {
                IsSuccess = response == null ? false : true,
                Data = response
            };
        }

        // Webhook endpoint to receive PayPal notifications
        [HttpPost("/HandlePayPalWebhook")]
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

    }
}