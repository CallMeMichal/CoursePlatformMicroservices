namespace SharedModels.Models.CourseModels.Request
{
    public class UpdateCourseRequestModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
