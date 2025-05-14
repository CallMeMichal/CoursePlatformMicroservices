using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.LoginRegisterModels.Request.Course;
using SharedModels.Models.LoginRegisterModels.Response;

namespace ApiGetaway.Controllers
{
    [Route("api/v1/")]
    public class CourseController : Controller
    {
        private readonly IRequestClient<CreateCourseRequestModel> _createCourseClient;

        public CourseController(IRequestClient<CreateCourseRequestModel> createCourseClient)
        {
            _createCourseClient = createCourseClient;
        }

        [HttpPost]
        [Route("course")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequestModel request)
        {
            int instructorId = 1;

            CreateCourseRequestModel courseModel = new CreateCourseRequestModel()
            {
                CreationDate = DateTime.Now,
                Description = request.Description,
                Duration = 200,
                ImageUrl = null,
                InstructorId = instructorId,
                Name = "Kurs Pływania",
                Price = 200
            };

            var response = await _createCourseClient.GetResponse<ApiResponse>(courseModel);

            return Ok(response);
        }

        [HttpGet]
        [Route("course/{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            // Simulate some processing
            await Task.Delay(1000);
            // Return a success response
            return Ok(new { message = "Course retrieved successfully", courseId = id });
        }

        [HttpPut]
        [Route("course/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] object course)
        {
            // Simulate some processing
            await Task.Delay(1000);
            // Return a success response
            return Ok(new { message = "Course updated successfully", courseId = id, course });
        }

        [HttpDelete]
        [Route("course/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            // Simulate some processing
            await Task.Delay(1000);
            // Return a success response
            return Ok(new { message = "Course deleted successfully", courseId = id });
        }

        [HttpGet]
        [Route("courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            // Simulate some processing
            await Task.Delay(1000);
            // Return a success response
            return Ok(new { message = "All courses retrieved successfully" });
        }

        // GET: api/v1/course/{courseId}/lessons
        [HttpGet("course/{courseId}/lessons")]
        public async Task<IActionResult> GetLessonsForCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        // GET: api/v1/course/{courseId}/lesson/{lessonId}
        [HttpGet("course/{courseId}/lesson/{lessonId}")]
        public async Task<IActionResult> GetLesson(int courseId, int lessonId)
        {
            throw new NotImplementedException();
        }

        // POST: api/v1/course/{courseId}/lesson
        [HttpPost("course/{courseId}/lesson")]
        public async Task<IActionResult> CreateLesson(int courseId, [FromBody] object lesson)
        {
            throw new NotImplementedException();
        }
        // PUT: api/v1/course/{courseId}/lesson/{lessonId}
        [HttpPut("course/{courseId}/lesson/{lessonId}")]
        public async Task<IActionResult> UpdateLesson(int courseId, int lessonId, [FromBody] object lesson)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/v1/course/{courseId}/lesson/{lessonId}
        [HttpDelete("course/{courseId}/lesson/{lessonId}")]
        public async Task<IActionResult> DeleteLesson(int courseId, int lessonId)
        {
            throw new NotImplementedException();
        }
    }
}
