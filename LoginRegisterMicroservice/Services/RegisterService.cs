using LoginRegisterMicroservice.Repositories;
using LoginRegisterMicroservice.Repositories.DatabaseModels;
using SharedModels.Models.LoginRegisterModels.Request;
using SharedModels.Models.Response;

namespace LoginRegisterMicroservice.Services
{
    public class RegisterService
    {
        public readonly RegisterRepository _registerRepository;
        public readonly LoginRepository _loginRepository;

        public RegisterService(RegisterRepository registerRepository, LoginRepository loginRepository)
        {
            _registerRepository = registerRepository;
            _loginRepository = loginRepository;
        }

        public async Task<ApiResponse> RegisterUser(RegisterRequestModel request)
        {
            try
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

                var emailToCheck = request.Email.ToLower();
                var existingUser = await _loginRepository.GetUserByEmail(emailToCheck);

                if (existingUser != null)
                {
                    return Helpers.Conflict("Email already exists in database");
                }

                
                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = Helpers.HashPassword(request.Password),
                    RoleId = 1 // Domyślna rola
                };

                await _registerRepository.CreateUser(user);

                return Helpers.Success("User registered successfully");
            }
            catch (Exception ex)
            {
                return Helpers.Exception(ex, "An error occurred while registering the user");
            }
        }
    }
}

