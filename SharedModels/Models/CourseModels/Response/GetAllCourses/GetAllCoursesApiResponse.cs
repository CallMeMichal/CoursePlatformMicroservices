using SharedModels.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models.CourseModels.Response.GetAllCourses
{
    public class GetAllCoursesApiResponse
    {
        public List<CourseList> Courses { get; set; } = new List<CourseList>();
        public ApiResponse? ApiResponse { get; set; }
    }
}
