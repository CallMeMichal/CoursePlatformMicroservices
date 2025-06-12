using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models.CourseModels.Request
{
    public class CreateLessonRequestModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? VideoPath { get; set; }
        [DefaultValue("2008-11-11 13:23:44")]
        public DateTime CreationDate { get; set; }
        public double Duration { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

    }
}
