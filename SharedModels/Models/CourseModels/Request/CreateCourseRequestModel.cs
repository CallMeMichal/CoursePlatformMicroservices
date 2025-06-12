using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models.CourseModels.Request
{
    public class CreateCourseRequestModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public double Price { get; set; }
        [Required]
        public int InstructorId { get; set; }
    }
}
