using System.ComponentModel.DataAnnotations;

namespace CourseMicroservice.Repositories.DatabaseModels
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; } 
        public int InstructorId { get; set; }
    }
}
