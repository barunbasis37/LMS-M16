using LearningManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.LMSDBContext
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
        .HasOne(sc => sc.Student)
        .WithMany(s => s.StudentCourses)
        .HasForeignKey(sc => sc.StudentId)
        .OnDelete(DeleteBehavior.NoAction); // or Restrict

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.NoAction); // or Restrict

            modelBuilder.Entity<StudentAssignment>()
        .HasOne(sa => sa.Student)
        .WithMany(s => s.StudentAssignments)
        .HasForeignKey(sa => sa.StudentId)
        .OnDelete(DeleteBehavior.NoAction); // critical

            modelBuilder.Entity<StudentAssignment>()
                .HasOne(sa => sa.Assignment)
                .WithMany(a => a.StudentAssignments)
                .HasForeignKey(sa => sa.AssignmentId)
                .OnDelete(DeleteBehavior.NoAction); // critical

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Assignments)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            // ✅ Composite Keys
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentAssignment>()
                .HasKey(sa => new { sa.StudentId, sa.AssignmentId });

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    Id = 1,
                    UserId = "INS001",
                    CreatedDate = new DateTime(2024, 1, 1),
                    Name = "Dr. Smith",
                    Email = "smith@test.com",
                    Role = UserRole.Instructor,

                }
            );
        }
    }
}