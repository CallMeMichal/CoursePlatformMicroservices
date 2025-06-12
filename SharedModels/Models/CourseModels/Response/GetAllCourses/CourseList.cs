using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models.CourseModels.Response.GetAllCourses
{
    public class CourseList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
        public int InstructorId { get; set; }
    }
}
