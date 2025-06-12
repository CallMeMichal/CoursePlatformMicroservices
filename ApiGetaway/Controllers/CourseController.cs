using ApiGetaway.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.CourseModels.Request;
using SharedModels.Models.CourseModels.Response;
using SharedModels.Models.Response;

namespace ApiGetaway.Controllers
{
    [Route("api/v1/")]
    public class CourseController : Controller
    {
        private readonly CourseServiceHelper _courseService;

        public CourseController(CourseServiceHelper courseService)
        {
            _courseService = courseService;
        }
        //
        [HttpPost]
        [Route("course")]
        public async Task<IActionResult> CreateCourse(CreateCourseRequestModel request)
        {
            var response = await _courseService.CreateCourseAsync(request);
            return Ok(response);
        }
        //
        [HttpGet]
        [Route("course/{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var response = await _courseService.GetCourseAsync(id);
            return Ok(response);
        }

        [HttpPut]
        [Route("course/{id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] int id, UpdateCourseModel request)
        {
            var response = await _courseService.UpdateCourseAsync(id, request);
            return Ok(response);
        }
        //
        [HttpDelete]
        [Route("course/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var response = await _courseService.DeleteCourseAsync(id);
            return Ok(response);
        }
        //
        [HttpGet]
        [Route("courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var response = await _courseService.GetAllCoursesAsync();
            return Ok(response);
        }

        //
        [HttpGet("course/{courseId}/lessons")]
        public async Task<IActionResult> GetLessonsForCourse(int courseId)
        {
            var response = await _courseService.GetLessonsForCourseAsync(courseId);
            return Ok(response);
        }

        //
        [HttpGet("course/{courseId}/lesson/{lessonId}")]
        public async Task<IActionResult> GetLesson(int courseId, int lessonId)
        {
            var response = await _courseService.GetLessonAsync(courseId,lessonId);
            return Ok(response);
        }

        //
        [HttpPost("course/{courseId}/lesson")]
        public async Task<IActionResult> CreateLesson([FromRoute] int courseId, CreateLessonModel request)
        {

            var response = await _courseService.CreateLessonAsync(request, courseId);
            return Ok(response);
        }
       
        [HttpPut("course/{courseId}/lesson/{lessonId}")]
        public async Task<IActionResult> UpdateLesson([FromRoute]  int courseId, [FromRoute] int lessonId, UpdateLessonModel request)
        {
            var response = await _courseService.UpdateLessonAsync(courseId,lessonId,request);
            return Ok(response);
        }

        //
        [HttpDelete("course/{courseId}/lesson/{lessonId}")]
        public async Task<IActionResult> DeleteLesson(int courseId, int lessonId)
        {
            var response = await _courseService.DeleteLessonAsync(courseId, lessonId);
            return Ok(response);
        }
    }
}
