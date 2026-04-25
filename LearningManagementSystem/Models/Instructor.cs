using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public class Instructor : User
    {
        ////[StringLength(50)]
        ////public string InstructorId { get; set; }= "INS" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        public ICollection<Course> Courses { get; set; }
    }

}
