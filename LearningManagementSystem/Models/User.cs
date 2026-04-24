namespace LearningManagementSystem.Models
{
    public enum UserRole
    {
        Instructor = 1,
        Student = 2
    }

    public abstract class User : Entities
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }


    public class Student : User
    {
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
