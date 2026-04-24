using LearningManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem
{
    public class ApplicatonDBContext : DbContext
    {
        public ApplicatonDBContext(DbContextOptions<ApplicatonDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator<UserRole>("Role")
                .HasValue<Instructor>(UserRole.Instructor)
                .HasValue<Student>(UserRole.Student);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentAssignment>()
                .HasKey(sa => new { sa.StudentId, sa.AssignmentId });

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Assignments)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    Id = 1,
                    Name = "Dr. Smith",
                    Email = "smith@test.com",
                    Role = UserRole.Instructor,
                    CreatedDate = new DateTime(2024, 1, 1)
                }
            );
        }
    }
}