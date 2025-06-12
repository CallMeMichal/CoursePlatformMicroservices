using SharedModels.Models.Response;

namespace SharedModels.Models.CourseModels.Response
{
    public class GetLessonsForCourseApiResponse
    {
        public List<LessonsApiResponse> LessonsApiResponse { get; set; } = new List<LessonsApiResponse>();
        public ApiResponse? ApiResponse { get; set; }
    }
}
