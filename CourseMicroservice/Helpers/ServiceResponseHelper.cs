using SharedModels.Models.Response;
using System.Net;

namespace CourseMicroservice.Helpers
{
    public static class ServiceResponseHelper
    {
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
    }
}
