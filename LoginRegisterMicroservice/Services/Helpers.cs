using BCrypt.Net;
using SharedModels.Models.LoginRegisterModels.Response;
using System.Net;

namespace LoginRegisterMicroservice.Services
{
    public static class Helpers
    {

        private const int WorkFactor = 12;

        public static ApiResponse Success(string message)
        {
            return new ApiResponse
            {
                StatusCode = HttpStatusCode.OK,
                isSuccess = true,
                Message = message
            };
        }

        public static ApiResponse Error(string message)
        {
            return new ApiResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                isSuccess = false,
                Message = message,
            };
        }

        public static ApiResponse Exception(Exception ex, string message = "An error occurred")
        {
            return new ApiResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                isSuccess = false,
                Message = $"{message}: {ex.Message}",
            };
        }


        public static ApiResponse Conflict(string message)
        {
            return new ApiResponse
            {
                StatusCode = System.Net.HttpStatusCode.Conflict,
                isSuccess = false,
                Message = message
            };
        }

        public static ApiResponse NotFound(string message)
        {
            return new ApiResponse
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                isSuccess = false,
                Message = message,
            };
        }




        
        

        /// <summary>
        /// Haszuje hasło używając BCrypt
        /// </summary>
        /// <param name="password">Hasło w czystej postaci</param>
        /// <returns>Bezpieczny hasz hasła</returns>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }

        /// <summary>
        /// Weryfikuje hasło względem przechowywanego hasza
        /// </summary>
        /// <param name="password">Hasło w czystej postaci</param>
        /// <param name="hashedPassword">Zahaszowane hasło z bazy danych</param>
        /// <returns>True jeśli hasło jest poprawne, false w przeciwnym wypadku</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

    }
}

