using LoginRegisterMicroservice.Repositories;
using SharedModels.Models.LoginRegisterModels.Request;
using SharedModels.Models.Response;

namespace LoginRegisterMicroservice.Services
{
    public class LoginService
    {
        public readonly LoginRepository _loginRepository;

        public LoginService(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }


        public async Task<ApiResponse> LoginUser(LoginRequestModel request)
        {
            if (request == null)
            {
                return Helpers.Error("Invalid request data");
            }
            if (string.IsNullOrEmpty(request.Email))
            {
                return Helpers.Error("Email is required.");
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                return Helpers.Error("Password is required.");
            }

            try
            {
                var user = await _loginRepository.GetUserByEmail(request.Email);
                if (user == null)
                {
                    return Helpers.NotFound("User with this email does not exist.");
                }

                if (!Helpers.VerifyPassword(request.Password, user.Password))
                {
                    return Helpers.Error("Invalid password.");
                }

                JwtTokenGenerator jwtTokenGenerator = new JwtTokenGenerator();

                var token = jwtTokenGenerator.GenerateToken(user);

                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    isSuccess = true,
                    Message = "Login successful",
                    Token = token,
                };
            }
            catch (Exception ex)
            {
                return Helpers.Exception(ex, "Login failed");
            }
        }
    }
}

