using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.LoginRegisterModels.Request.LoginRegister;
using SharedModels.Models.LoginRegisterModels.Response;

namespace ApiGetaway.Controllers
{
    [Route("api/v1/")]
    public class LoginRegisterController : Controller
    {
        private readonly IRequestClient<RegisterRequestModel> _registerClient;
        private readonly IRequestClient<LoginRequestModel> _loginClient;

        public LoginRegisterController(IRequestClient<RegisterRequestModel> registerClient, IRequestClient<LoginRequestModel> loginClient)
        {
            _registerClient = registerClient;
            _loginClient = loginClient;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse>> LoginUser([FromBody] LoginRequestModel request)
        {
            var loginModel = new LoginRequestModel
            {
                Email = request.Email,
                Password = request.Password
            };
            var response = await _loginClient.GetResponse<ApiResponse>(loginModel);

            return Ok(response);
        }

        //todo
        /*[HttpGet("google_login")]
        public async Task<IActionResult> LoginGoogleUser()
        {
            var loginModel = new LoginRequestModel
            {
                Email = "test@example.com",
                Password = "testPassword"
            };

            *//*await _loginClient.GetResponse(loginModel);*//*

            return Ok("Message published successfully");
        }*/

        //todo
/*        [HttpGet("facebook_login")]
        public async Task<IActionResult> LoginUser()
        {
            var loginModel = new LoginRequestModel
            {
                Email = "test@example.com",
                Password = "testPassword"
            };

            *//*await _loginClient.GetResponse(loginModel);*//*

            return Ok("Message published successfully");
        }*/

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> RegisterUser([FromBody] RegisterRequestModel registerModel)
        {
            var response = await _registerClient.GetResponse<ApiResponse>(registerModel);
            return Ok(response);
        }
    }
}
