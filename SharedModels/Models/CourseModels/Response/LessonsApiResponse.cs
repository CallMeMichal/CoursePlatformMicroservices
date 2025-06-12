namespace SharedModels.Models.CourseModels.Response
{
    public class LessonsApiResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? VideoPath { get; set; }
        public DateTime CreationDate { get; set; }
        public double Duration { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
