using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models.CourseModels.Request
{
    public class GetLessonRequestModel
    {
        public int CourseId { get; set; }
        public int LessonId { get; set; }
    }
}
