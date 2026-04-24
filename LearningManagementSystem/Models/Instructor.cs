namespace LearningManagementSystem.Models
{
    public class Instructor : User
    {
        public ICollection<Course> Courses { get; set; }
    }

}
