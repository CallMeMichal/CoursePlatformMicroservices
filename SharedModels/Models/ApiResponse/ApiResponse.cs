using System.Text.Json.Serialization;

namespace SharedModels.Models.Response
{
    public class ApiResponse
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public bool isSuccess { get; set; }
        public string? Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Token { get; set; }
    }
}
