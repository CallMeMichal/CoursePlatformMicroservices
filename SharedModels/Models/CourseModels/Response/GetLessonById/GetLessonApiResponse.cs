using SharedModels.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedModels.Models.CourseModels.Response.GetLessonById
{
    public class GetLessonApiResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public LessonApiResponse? Lesson { get; set; }
        public ApiResponse? ApiResponse { get; set; }
    }
}
