using Educational_Medical_platform.DTO.PayPal;
using Educational_Medical_platform.PayPal;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayPalController : ControllerBase
    {
        private readonly PayPalClientApi _client;
        private readonly IUserSubscribtionRipository _userSubscribtionRipository;
        private readonly IPlatformRepository _platformRepository;

        public PayPalController(IUserSubscribtionRipository userSubscribtionRipository , IPlatformRepository platformRepository)
        {
            _client = new PayPalClientApi(userSubscribtionRipository , platformRepository);

            _userSubscribtionRipository = userSubscribtionRipository;
            this._platformRepository = platformRepository;
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
    }
}