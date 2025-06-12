using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models.CourseModels.Response.GetLessonById
{
    public class LessonApiResponse
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
