using AutoMapper;
using CourseMicroservice.Repositories.DatabaseModels;
using SharedModels.Models.CourseModels.Request;
using SharedModels.Models.CourseModels.Response;
using SharedModels.Models.CourseModels.Response.GetAllCourses;
using SharedModels.Models.CourseModels.Response.GetLessonById;

namespace CourseMicroservice.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCourseRequestModel, Course>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CreateLessonRequestModel, Lesson>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Course, GetCourseByIdApiResponse>();
            CreateMap<UpdateCourseRequestModel, Course>();
            CreateMap<UpdateLessonRequestModel, Lesson>();


            CreateMap<Lesson, LessonsApiResponse>();
            CreateMap<Lesson, LessonApiResponse>();

            CreateMap<Course, CourseList>();

        }
    }
}
