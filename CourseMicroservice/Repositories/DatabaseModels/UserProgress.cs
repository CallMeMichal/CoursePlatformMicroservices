namespace CourseMicroservice.Repositories.DatabaseModels
{
    public class UserProgress
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int? LessonId { get; set; }

        public double Progress { get; set; } 
        public DateTime LastAccessed { get; set; }

        public Course? Course { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
