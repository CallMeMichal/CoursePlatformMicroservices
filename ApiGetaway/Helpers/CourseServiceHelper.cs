using MassTransit;
using SharedModels.Models.CourseModels.Request;
using SharedModels.Models.CourseModels.Response;
using SharedModels.Models.CourseModels.Response.GetAllCourses;
using SharedModels.Models.CourseModels.Response.GetLessonById;
using SharedModels.Models.Response;

namespace ApiGetaway.Services
{
    public class CourseServiceHelper
    {
        private readonly IRequestClient<CreateCourseRequestModel> _createCourseClient;
        private readonly IRequestClient<GetCourseRequestModel> _getCourseClient;
        private readonly IRequestClient<UpdateCourseRequestModel> _updateCourseClient;
        private readonly IRequestClient<DeleteCourseRequestModel> _deleteCourseClient;
        private readonly IRequestClient<GetAllCoursesRequestModel> _getAllCoursesClient;
        private readonly IRequestClient<GetLessonsForCourseRequestModel> _getLessonsForCourseClient;
        private readonly IRequestClient<GetLessonRequestModel> _getLessonClient;
        private readonly IRequestClient<CreateLessonRequestModel> _createLessonClient;
        private readonly IRequestClient<UpdateLessonRequestModel> _updateLessonClient;
        private readonly IRequestClient<DeleteLessonRequestModel> _deleteLessonClient;

        public CourseServiceHelper(
            IRequestClient<CreateCourseRequestModel> createCourseClient,
            IRequestClient<GetCourseRequestModel> getCourseClient,
            IRequestClient<UpdateCourseRequestModel> updateCourseClient,
            IRequestClient<DeleteCourseRequestModel> deleteCourseClient,
            IRequestClient<GetAllCoursesRequestModel> getAllCoursesClient,
            IRequestClient<GetLessonsForCourseRequestModel> getLessonsForCourseClient,
            IRequestClient<GetLessonRequestModel> getLessonClient,
            IRequestClient<CreateLessonRequestModel> createLessonClient,
            IRequestClient<UpdateLessonRequestModel> updateLessonClient,
            IRequestClient<DeleteLessonRequestModel> deleteLessonClient)
        {
            _createCourseClient = createCourseClient;
            _getCourseClient = getCourseClient;
            _updateCourseClient = updateCourseClient;
            _deleteCourseClient = deleteCourseClient;
            _getAllCoursesClient = getAllCoursesClient;
            _getLessonsForCourseClient = getLessonsForCourseClient;
            _getLessonClient = getLessonClient;
            _createLessonClient = createLessonClient;
            _updateLessonClient = updateLessonClient;
            _deleteLessonClient = deleteLessonClient;
        }

        public async Task<ApiResponse> CreateCourseAsync(CreateCourseRequestModel request)
        {
            var response = await _createCourseClient.GetResponse<ApiResponse>(request);
            return response.Message;
        }

        public async Task<GetCourseByIdApiResponse> GetCourseAsync(int id)
        {
            var request = new GetCourseRequestModel { Id = id };
            var response = await _getCourseClient.GetResponse<GetCourseByIdApiResponse>(request);
            return response.Message;
        }

        public async Task<ApiResponse> UpdateCourseAsync(int courseId, UpdateCourseModel model)
        {
            UpdateCourseRequestModel request = new UpdateCourseRequestModel
            {
                Id = courseId,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };

            var response = await _updateCourseClient.GetResponse<ApiResponse>(request);
            return response.Message;
        }

        public async Task<ApiResponse> DeleteCourseAsync(int id)
        {
            var request = new DeleteCourseRequestModel { Id = id };
            var response = await _deleteCourseClient.GetResponse<ApiResponse>(request);
            return response.Message;
        }

        public async Task<GetAllCoursesApiResponse> GetAllCoursesAsync()
        {
            var response = await _getAllCoursesClient.GetResponse<GetAllCoursesApiResponse>(new GetAllCoursesRequestModel());
            return response.Message;
        }

        public async Task<GetLessonsForCourseApiResponse> GetLessonsForCourseAsync(int courseId)
        {
            var response = await _getLessonsForCourseClient.GetResponse<GetLessonsForCourseApiResponse>(
                new GetLessonsForCourseRequestModel { CourseId = courseId });
            return response.Message;
        }

        public async Task<GetLessonApiResponse> GetLessonAsync(int courseId, int lessonId)
        {
            var response = await _getLessonClient.GetResponse<GetLessonApiResponse>(
                new GetLessonRequestModel { CourseId = courseId, LessonId = lessonId });
            return response.Message;
        }

        public async Task<ApiResponse> CreateLessonAsync(CreateLessonModel model, int courseId)
        {
            CreateLessonRequestModel request = new CreateLessonRequestModel
            {
                CourseId = courseId,
                CreationDate = model.CreationDate,
                Description = model.Description,
                Duration = model.Duration,
                Title = model.Title,
                UserId = model.UserId,
                VideoPath = model.VideoPath
            };

            var response = await _createLessonClient.GetResponse<ApiResponse>(request);
            return response.Message;
        }

        public async Task<ApiResponse> UpdateLessonAsync(int courseId, int lessonId, UpdateLessonModel model)
        {

            UpdateLessonRequestModel request = new UpdateLessonRequestModel()
            {
                CourseId = courseId,
                CreationDate = model.CreationDate,
                Description = model.Description,
                Duration = model.Duration,
                Id = lessonId,
                Title = model.Title,
                VideoPath = model.VideoPath
            };

            request.CourseId = courseId;
            request.Id = lessonId;
            var response = await _updateLessonClient.GetResponse<ApiResponse>(request);
            return response.Message;
        }

        public async Task<ApiResponse> DeleteLessonAsync(int courseId, int lessonId)
        {
            var request = new DeleteLessonRequestModel { CourseId = courseId, LessonId = lessonId };
            var response = await _deleteLessonClient.GetResponse<ApiResponse>(request);
            return response.Message;
        }
    }
}
