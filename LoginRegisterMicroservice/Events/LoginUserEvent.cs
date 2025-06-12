using LoginRegisterMicroservice.Services;
using MassTransit;
using SharedModels.Models.LoginRegisterModels.Request;

namespace LoginRegisterMicroservice.Events
{
    public class LoginUserEvent : IConsumer<LoginRequestModel>
    {
        public readonly LoginService _loginService;

        public LoginUserEvent(LoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task Consume(ConsumeContext<LoginRequestModel> context)
        {

            var response = await _loginService.LoginUser(context.Message);
            await context.RespondAsync(response);
        }
    }
}
