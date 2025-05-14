using System.ComponentModel.DataAnnotations;

namespace CourseMicroservice.Repositories.DatabaseModels
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        //public string? Category { get; set; }
        public DateTime CreationDate { get; set; }
        public double Duration { get; set; }
        public double Price { get; set; } 
        public int InstructorId { get; set; }


        public List<Lesson>? Lesson { get; set; }
    }

}
