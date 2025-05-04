namespace SharedModels.Models.LoginRegisterModels.Response
{
    public class ApiResponse
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public bool isSuccess { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}
