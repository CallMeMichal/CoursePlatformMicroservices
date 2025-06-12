using CourseMicroservice.Services;
using MassTransit;
using SharedModels.Models.CourseModels.Request;

namespace CourseMicroservice.Events
{
    public class CourseEvent : IConsumer<CreateCourseRequestModel>
    {
        private readonly CourseService _courseService;

        public CourseEvent(CourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task Consume(ConsumeContext<CreateCourseRequestModel> context)
        {
            var result = await _courseService.CreateCourse(context.Message);

            await context.RespondAsync(result);
        }

    }

    public class CreateLessonEvent : IConsumer<CreateLessonRequestModel>
    {
        private readonly CourseService _courseService;

        public CreateLessonEvent(CourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task Consume(ConsumeContext<CreateLessonRequestModel> context)
        {
            var result = await _courseService.CreateLesson(context.Message);
            await context.RespondAsync(result);
        }

    }

    public class DeleteCourseEvent : IConsumer<DeleteCourseRequestModel>
    {
        private readonly CourseService _courseService;

        public DeleteCourseEvent(CourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task Consume(ConsumeContext<DeleteCourseRequestModel> context)
        {
            var result = await _courseService.DeleteCourse(context.Message.Id);
            await context.RespondAsync(result);
        }
    }

    public class DeleteLessonEvent : IConsumer<DeleteLessonRequestModel>
    {
        private readonly CourseService _courseService;

        public DeleteLessonEvent(CourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task Consume(ConsumeContext<DeleteLessonRequestModel> context)
        {
            var result = await _courseService.DeleteLesson(context.Message.LessonId,context.Message.CourseId);
            await context.RespondAsync(result);
        }
    }

    public class GetAllCoursesEvent : IConsumer<GetAllCoursesRequestModel>
    {
        private readonly CourseService _courseService;

        public GetAllCoursesEvent(CourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task Consume(ConsumeContext<GetAllCoursesRequestModel> context)
        {
            var result = await _courseService.GetAllCourses();
            await context.RespondAsync(result);
        }
    }

    public class GetCourseEvent : IConsumer<GetCourseRequestModel>
    {
        private readonly CourseService _courseService;

        public GetCourseEvent(CourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task Consume(ConsumeContext<GetCourseRequestModel> context)
        {
            var result = await _courseService.GetCourseById(context.Message.Id);
            await context.RespondAsync(result);
        }
    }

    public class GetLessonEvent : IConsumer<GetLessonRequestModel>
    {
        private readonly CourseService _courseService;

        public GetLessonEvent(CourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task Consume(ConsumeContext<GetLessonRequestModel> context)
        {
            var result = await _courseService.GetLessonById(context.Message.CourseId,context.Message.LessonId);
            await context.RespondAsync(result);
        }
    }

    public class GetLessonsForCourseEvent : IConsumer<GetLessonsForCourseRequestModel>
    {
        private readonly CourseService _courseService;

        public GetLessonsForCourseEvent(CourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task Consume(ConsumeContext<GetLessonsForCourseRequestModel> context)
        {
            var result = await _courseService.GetLessonsForCourse(context.Message.CourseId);
            await context.RespondAsync(result);
        }
    }


    public class UpdateCourseEvent : IConsumer<UpdateCourseRequestModel>
    {
        private readonly CourseService _courseService;

        public UpdateCourseEvent(CourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task Consume(ConsumeContext<UpdateCourseRequestModel> context)
        {
            var result = await _courseService.UpdateCourse(context.Message);
            await context.RespondAsync(result);
        }
    }

    public class UpdateLessonEvent : IConsumer<UpdateLessonRequestModel>
    {
        private readonly CourseService _courseService;

        public UpdateLessonEvent(CourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task Consume(ConsumeContext<UpdateLessonRequestModel> context)
        {
            var result = await _courseService.UpdateLesson(context.Message);
            await context.RespondAsync(result);
        }
    }


}
