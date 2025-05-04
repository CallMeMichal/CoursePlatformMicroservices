using LoginRegisterMicroservice.Services;
using MassTransit;
using SharedModels.Models.LoginRegisterModels.Request;

namespace LoginRegisterMicroservice.Events
{
    public class RegisterUserEvent : IConsumer<RegisterRequestModel>
    {
        public readonly RegisterService _registerService;

        public RegisterUserEvent(RegisterService registerService)
        {
            _registerService = registerService;
        }

        public async Task Consume(ConsumeContext<RegisterRequestModel> context)
        {
            var response = await _registerService.RegisterUser(context.Message);
            await context.RespondAsync(response);
        }
    }
}