using LoginRegisterMicroservice.Repositories.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace LoginRegisterMicroservice.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Instructor" },
                new Role { Id = 3, Name = "Student" },
                new Role { Id = 4, Name = "Student_Subscriber" }

            );
        }


    }
}
