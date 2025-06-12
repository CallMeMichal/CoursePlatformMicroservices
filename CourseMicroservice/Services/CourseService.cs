using AutoMapper;
using CourseMicroservice.Helpers;
using CourseMicroservice.Repositories;
using CourseMicroservice.Repositories.DatabaseModels;
using MassTransit;
using SharedModels.Models.CourseModels.Request;
using SharedModels.Models.CourseModels.Response;
using SharedModels.Models.CourseModels.Response.GetAllCourses;
using SharedModels.Models.CourseModels.Response.GetLessonById;
using SharedModels.Models.Response;
using static MassTransit.Logging.OperationName;

namespace CourseMicroservice.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(CourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateCourse(CreateCourseRequestModel request)
        {
            var mappedModel = _mapper.Map<Course>(request);
            var result = await _courseRepository.CreateCourse(mappedModel);

            if (result.Item1 > 0)
            {
                return ServiceResponseHelper.Success("Successfully course added.");
            }
            else
            {
                var errorMessage = result.Item2 ?? "An unknown error occurred.";
                return ServiceResponseHelper.Error(errorMessage);
            }

        }

        public async Task<GetCourseByIdApiResponse> GetCourseById(int id)
        {
            var result = await _courseRepository.GetCourseById(id);

            if (result == null)
            {
                return new GetCourseByIdApiResponse
                {
                    ApiResponse = ServiceResponseHelper.Error("Course not found."),
                };
            }

            var mappedModel = _mapper.Map<GetCourseByIdApiResponse>(result);
            return mappedModel;
        }


        //poprawic
        public async Task<ApiResponse> UpdateCourse(UpdateCourseRequestModel request)
        {
            if (request.Id > 0)
            {
                if (!string.IsNullOrWhiteSpace(request.Name))
                    request.Name = request.Name;

                if (!string.IsNullOrWhiteSpace(request.Description))
                    request.Description = request.Description;

                if (request.Price.HasValue)
                    request.Price = request.Price.Value;

            }
            else
            {
                return ServiceResponseHelper.Error("An error occured.");
            }

            var mappedModel = _mapper.Map<Course>(request);

            var result = await _courseRepository.UpdateCourse(mappedModel);
            if (result.Item1 > 0)
            {
                return ServiceResponseHelper.Success("Successfully course updated.");
            }
            else
            {
                var errorMessage = result.Item2 ?? "An unknown error occurred.";
                return ServiceResponseHelper.Error(errorMessage);
            }
        }
        // todo
        public async Task<ApiResponse> UpdateLesson(UpdateLessonRequestModel request)
        {
            var mappedModel = _mapper.Map<Lesson>(request);
            var result = await _courseRepository.UpdateLesson(mappedModel);
            if (result.Item1 > 0)
            {
                return ServiceResponseHelper.Success("Successfully lesson updated.");
            }
            else
            {
                var errorMessage = result.Item2 ?? "An unknown error occurred.";
                return ServiceResponseHelper.Error(errorMessage);
            }
        }

        public async Task<ApiResponse> CreateLesson(CreateLessonRequestModel request)
        {
            var mappedModel = _mapper.Map<Lesson>(request);

            var course = await _courseRepository.GetCourseById(request.CourseId);

            if (course == null)
            {
                return ServiceResponseHelper.NotFound("Course Not Found");
            }

            var result = await _courseRepository.CreateLesson(mappedModel);
            if (result.Item1 > 0)
            {
                return ServiceResponseHelper.Success("Successfully lesson added.");
            }
            else
            {
                var errorMessage = result.Item2 ?? "An unknown error occurred.";
                return ServiceResponseHelper.Error(errorMessage);
            }
        }

        //dodac usuwanie lekcji
        public async Task<ApiResponse> DeleteCourse(int courseId)
        {
            var course = await _courseRepository.GetCourseById(courseId);
            if (course == null)
            {
                return ServiceResponseHelper.NotFound("Course not found.");
            }

            var deleteUserProgress = await _courseRepository.DeleteUserProgressForCourse(courseId);
            var deleteResult = await _courseRepository.DeleteLessons(courseId);
            if(deleteResult.Item1 == 0)
            {
                var errorMessage = deleteResult.Item2 ?? "An unknown error occurred.";
                return ServiceResponseHelper.Error(errorMessage);

            }
            var result = await _courseRepository.DeleteCourse(courseId);
            
            if (result.Item1 > 0)
            {
                return ServiceResponseHelper.Success("Successfully course deleted.");
            }
            else
            {
                var errorMessage = result.Item2 ?? "An unknown error occurred.";
                return ServiceResponseHelper.Error(errorMessage);
            }
        }

        public async Task<GetLessonsForCourseApiResponse> GetLessonsForCourse(int id)
        {
            var result = await _courseRepository.GetLessonsForCourse(id);

            if (result == null || result.Count == 0)
            {
                return new GetLessonsForCourseApiResponse
                {
                    LessonsApiResponse = new List<LessonsApiResponse>(),
                    ApiResponse = ServiceResponseHelper.NotFound("No lessons found for the course.")
                };
            }

            var mappedLessons = _mapper.Map<List<LessonsApiResponse>>(result);

            return new GetLessonsForCourseApiResponse
            {
                LessonsApiResponse = mappedLessons,
                ApiResponse = ServiceResponseHelper.Success("Successfully retrieved lessons for course.")
            };
        }
        public async Task<GetLessonApiResponse> GetLessonById(int courseId, int lessonId)
        {
            var result = await _courseRepository.GetLessonById(courseId, lessonId);

            if (result == null)
            {
                return new GetLessonApiResponse
                {
                    ApiResponse = ServiceResponseHelper.NotFound("Lesson not found.")
                };
            }

            var mappedLesson = _mapper.Map<LessonApiResponse>(result);

            return new GetLessonApiResponse
            {
                Lesson = mappedLesson,
                ApiResponse = ServiceResponseHelper.Success("Successfully retrieved lesson.")
            };
        }

        public async Task<ApiResponse> DeleteLesson(int lessonId, int courseId)
        {
            var lesson = await _courseRepository.GetLessonById(courseId, lessonId);
            if(lesson == null)
            {
                return ServiceResponseHelper.NotFound("Lesson not found.");
            }
            var progress = await _courseRepository.DeleteUserProgressForLesson(courseId, lessonId);

            var result = await _courseRepository.DeleteLesson(lessonId, courseId);
            if (result.Item1 > 0)
            {
                return ServiceResponseHelper.Success("Successfully lesson deleted.");
            }
            else
            {
                var errorMessage = result.Item2 ?? "An unknown error occurred.";
                return ServiceResponseHelper.Error(errorMessage);
            }
        }

        public async Task<GetAllCoursesApiResponse> GetAllCourses()
        {
            var result = await _courseRepository.GetAllCourses();

            

            if (result == null || result.Count == 0)
            {
                return new GetAllCoursesApiResponse
                {
                    Courses = new List<CourseList>(),
                    ApiResponse = ServiceResponseHelper.NotFound("No courses found.")
                };
            }

            var mappedCourses = _mapper.Map<List<CourseList>>(result);

            return new GetAllCoursesApiResponse
            {
                Courses = mappedCourses,
                ApiResponse = ServiceResponseHelper.Success("Successfully retrieved all courses.")
            };
        }
    }
}
