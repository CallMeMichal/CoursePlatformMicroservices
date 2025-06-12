using CourseMicroservice.Repositories.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static MassTransit.Logging.OperationName;
using static MassTransit.ValidationResultExtensions;

namespace CourseMicroservice.Repositories
{
    public class CourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(int, string?)> CreateCourse(Course course)
        {
            try
            {
                await _context.Courses.AddAsync(course);
                int result = await _context.SaveChangesAsync();
                return (result, null);
            }
            catch (Exception ex)
            {
                return (0, ex.Message);
            }
        }


        public async Task<Course?> GetCourseById(int id)
        {

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
                return null;
            return course;
        }


        public async Task<(int, string?)> UpdateCourse(Course course)
        {
            try
            {
                _context.Courses.Update(course);
                var result = await _context.SaveChangesAsync();
                return (result, null);
            }
            catch (Exception ex)
            {
                return (0, ex.Message);
            }
        }

        public async Task<(int, string?)> UpdateLesson(Lesson lesson)
        {
            var existingLesson = await _context.Lessons.FindAsync(lesson.Id);
            if (existingLesson == null)
            {
                return (0, "Lesson not found.");
            }
            try
            {
                _context.Lessons.Update(lesson);
                var result = await _context.SaveChangesAsync();
                return (result, null);
            }
            catch (Exception ex)
            {
                return (0, ex.Message);
            }

        }

        public async Task<(int, string?)> CreateLesson(Lesson lesson)
        {
            try
            {
                await _context.Lessons.AddAsync(lesson);
                int result = await _context.SaveChangesAsync();
                return (result, null);
            }
            catch (Exception ex)
            {
                return (0, ex.Message);
            }
        }

        public async Task<(int, string?)> DeleteCourse(int id)
        {
            try
            {
                //dodać wszystkie lekcje i usunać te lekcje przed
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return (0, "Course not found.");
                }
                _context.Courses.Remove(course);
                int result = await _context.SaveChangesAsync();
                return (result, null);
            }
            catch (Exception ex)
            {
                return (0, ex.Message);
            }
        }

        public async Task<List<Lesson>> GetLessonsForCourse(int courseId)
        {
            List<Lesson> lessons = new List<Lesson>();
            lessons = await _context.Lessons.Where(x => x.CourseId == courseId).ToListAsync();
            return lessons;
        }
        public async Task<Lesson?> GetLessonById(int courseId, int lessonId)
        {
            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(l => l.Id == lessonId && l.CourseId == courseId);

            return lesson;
        }
        public async Task<(int, string?)> DeleteLesson(int lessonId, int courseId)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId && l.CourseId == courseId);
            if (lesson == null)
            {
                return (0, "Lesson not found.");
            }



            try
            {
                _context.Lessons.Remove(lesson);
                int result = await _context.SaveChangesAsync();
                return (result, null);
            }
            catch (Exception ex)
            {

                return (0, ex.Message);
            }

        }

        public async Task<(int, string?)> DeleteLessons(int courseId)
        {
            var lessons = await _context.Lessons.Where(l => l.CourseId == courseId).ToListAsync();
            if (lessons == null)
            {
                return (0, "Lessons not found.");
            }

            try
            {
                _context.Lessons.RemoveRange(lessons);
                int result = await _context.SaveChangesAsync();
                return (result, null);
            }
            catch (Exception ex)
            {
                return (0, ex.Message);
            }


        }

        public async Task<(int, string?)> DeleteUserProgressForCourse(int courseId)
        {
            var progresses = await _context.UserProgresses
                .Where(up => up.CourseId == courseId)
                .ToListAsync();

            if (progresses.Count == 0)
            {
                return (0, "No user progresses found for this course.");
            }

            try
            {
                _context.UserProgresses.RemoveRange(progresses);
                int result = await _context.SaveChangesAsync();
                return (result, null);
            }
            catch (Exception ex)
            {
                return (0, ex.Message);
            }
        }

        public async Task<(int, string?)> DeleteUserProgressForLesson(int courseId, int lessonId)
        {
            var progresses = await _context.UserProgresses
                .Where(up => up.CourseId == courseId && up.LessonId == lessonId)
                .ToListAsync();

            if (progresses.Count == 0)
                return (0, "No user progresses found for this lesson.");

            try
            {
                _context.UserProgresses.RemoveRange(progresses);
                int result = await _context.SaveChangesAsync();
                return (result, null);
            }
            catch (Exception ex)
            {
                return (0, ex.Message);
            }
        }
        public async Task<List<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
