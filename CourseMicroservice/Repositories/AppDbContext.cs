using CourseMicroservice.Repositories.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace CourseMicroservice.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.Course)
                .WithMany()
                .HasForeignKey(up => up.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.Lesson)
                .WithMany()
                .HasForeignKey(up => up.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserProgress>()
                .HasIndex(up => new { up.UserId, up.CourseId, up.LessonId })
                .IsUnique();
            // Kursy
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "Kurs C# dla początkujących",
                    Description = "Podstawy języka C# i programowania obiektowego",
                    ImageUrl = "https://example.com/csharp.jpg",
                    //Category = "Programowanie",
                    CreationDate = new DateTime(2024, 1, 1),
                    Duration = 10.5,
                    Price = 199.99,
                    InstructorId = 1001
                },
                new Course
                {
                    Id = 2,
                    Name = "ASP.NET Core Web API",
                    Description = "Tworzenie API w technologii ASP.NET Core",
                    ImageUrl = "https://example.com/aspnet.jpg",
                    //Category = "Backend",
                    CreationDate = new DateTime(2024, 2, 1),
                    Duration = 8,
                    Price = 249.99,
                    InstructorId = 1002
                }
            );

            // Lekcje do Kursu 1
            modelBuilder.Entity<Lesson>().HasData(
                new Lesson
                {
                    Id = 1,
                    Title = "Wprowadzenie do C#",
                    Description = "Instalacja Visual Studio i pierwszy projekt",
                    VideoPath = "https://example.com/video1.mp4",
                    CreationDate = new DateTime(2024, 1, 2),
                    Duration = 1.5,
                    UserId = 2001,
                    CourseId = 1
                },
                new Lesson
                {
                    Id = 2,
                    Title = "Zmienne i typy danych",
                    Description = "Podstawowe typy danych w C#",
                    VideoPath = "https://example.com/video2.mp4",
                    CreationDate = new DateTime(2024, 1, 3),
                    Duration = 1.0,
                    UserId = 2001,
                    CourseId = 1
                },
                new Lesson
                {
                    Id = 3,
                    Title = "Instrukcje warunkowe",
                    Description = "if, else, switch",
                    VideoPath = "https://example.com/video3.mp4",
                    CreationDate = new DateTime(2024, 1, 4),
                    Duration = 1.2,
                    UserId = 2001,
                    CourseId = 1
                }
            );

            // Lekcje do Kursu 2
            modelBuilder.Entity<Lesson>().HasData(
                new Lesson
                {
                    Id = 4,
                    Title = "Wprowadzenie do Web API",
                    Description = "Struktura projektu ASP.NET Core",
                    VideoPath = "https://example.com/video4.mp4",
                    CreationDate = new DateTime(2024, 2, 2),
                    Duration = 1.4,
                    UserId = 2002,
                    CourseId = 2
                },
                new Lesson
                {
                    Id = 5,
                    Title = "Kontrolery i routing",
                    Description = "Tworzenie kontrolerów i mapowanie routingu",
                    VideoPath = "https://example.com/video5.mp4",
                    CreationDate = new DateTime(2024, 2, 3),
                    Duration = 1.6,
                    UserId = 2002,
                    CourseId = 2
                },
                new Lesson
                {
                    Id = 6,
                    Title = "Połączenie z bazą danych",
                    Description = "Entity Framework Core i migracje",
                    VideoPath = "https://example.com/video6.mp4",
                    CreationDate = new DateTime(2024, 2, 4),
                    Duration = 1.7,
                    UserId = 2002,
                    CourseId = 2
                }
            );
            modelBuilder.Entity<UserProgress>().HasData(
                // Global progress for Course 1
                new UserProgress
                {
                    Id = 1,
                    UserId = 2001,
                    CourseId = 1,
                    LessonId = null,
                    Progress = 30, // 50% ukończony
                    LastAccessed = new DateTime(2024, 3, 1)
                },

                // Per-lesson progress for Course 1
                new UserProgress
                {
                    Id = 2,
                    UserId = 2001,
                    CourseId = 1,
                    LessonId = 1,
                    Progress = 100,
                    LastAccessed = new DateTime(2024, 1, 10)
                },
                new UserProgress
                {
                    Id = 3,
                    UserId = 2001,
                    CourseId = 1,
                    LessonId = 2,
                    Progress = 50,
                    LastAccessed = new DateTime(2024, 1, 11)
                },
                new UserProgress
                {
                    Id = 4,
                    UserId = 2001,
                    CourseId = 1,
                    LessonId = 3,
                    Progress = 30.3,
                    LastAccessed = new DateTime(2024, 1, 12)
                },

                // Global progress for Course 2
                new UserProgress
                {
                    Id = 5,
                    UserId = 2002,
                    CourseId = 2,
                    LessonId = null,
                    Progress = 30,
                    LastAccessed = new DateTime(2024, 4, 1)
                },

                // Per-lesson progress for Course 2
                new UserProgress
                {
                    Id = 6,
                    UserId = 2002,
                    CourseId = 2,
                    LessonId = 4,
                    Progress = 100,
                    LastAccessed = new DateTime(2024, 2, 10)
                },
                new UserProgress
                {
                    Id = 7,
                    UserId = 2002,
                    CourseId = 2,
                    LessonId = 5,
                    Progress = 10,
                    LastAccessed = new DateTime(2024, 2, 11)
                },
                new UserProgress
                {
                    Id = 8,
                    UserId = 2002,
                    CourseId = 2,
                    LessonId = 6,
                    Progress = 20,
                    LastAccessed = new DateTime(2024, 2, 12)
                }
            );
        }
    }
}