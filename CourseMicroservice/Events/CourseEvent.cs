using MassTransit;
using SharedModels.Models.LoginRegisterModels.Request.Course;

namespace CourseMicroservice.Events
{
    public class CourseEvent : IConsumer<CreateCourseRequestModel>
    {
        public Task Consume(ConsumeContext<CreateCourseRequestModel> context)
        {
            throw new NotImplementedException();
        }

    }

    public class CreateLessonEvent : IConsumer<CreateLessonRequestModel>
    {
        public Task Consume(ConsumeContext<CreateLessonRequestModel> context)
        {
            throw new NotImplementedException();
        }

    }

    public class DeleteCourseEvent : IConsumer<DeleteCourseRequestModel>
    {
        public Task Consume(ConsumeContext<DeleteCourseRequestModel> context)
        {
            throw new NotImplementedException();
        }
    }

    public class GetAllCoursesEvent : IConsumer<GetAllCoursesRequestModel>
    {
        public Task Consume(ConsumeContext<GetAllCoursesRequestModel> context)
        {
            throw new NotImplementedException();
        }
    }

    public class GetCourseEvent : IConsumer<GetCourseRequestModel>
    {
        public Task Consume(ConsumeContext<GetCourseRequestModel> context)
        {
            throw new NotImplementedException();
        }
    }

    public class GetLessonEvent : IConsumer<GetLessonRequestModel>
    {
        public Task Consume(ConsumeContext<GetLessonRequestModel> context)
        {
            throw new NotImplementedException();
        }
    }

    public class GetLessonsForCourseEvent : IConsumer<GetLessonsForCourseRequestModel>
    {
        public Task Consume(ConsumeContext<GetLessonsForCourseRequestModel> context)
        {
            throw new NotImplementedException();
        }
    }


    public class UpdateCourseEvent : IConsumer<UpdateCourseRequestModel>
    {
        public Task Consume(ConsumeContext<UpdateCourseRequestModel> context)
        {
            throw new NotImplementedException();
        }
    }

    public class UpdateLessonEvent : IConsumer<UpdateLessonRequestModel>
    {
        public Task Consume(ConsumeContext<UpdateLessonRequestModel> context)
        {
            throw new NotImplementedException();
        }
    }


}
