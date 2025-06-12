using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models.CourseModels.Request
{
    public class UpdateLessonModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? VideoPath { get; set; }
        public DateTime CreationDate { get; set; }
        public double Duration { get; set; }
    }
}
