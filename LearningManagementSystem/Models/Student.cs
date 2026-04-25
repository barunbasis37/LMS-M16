using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LearningManagementSystem.Models
{
    public class Student : User
    {
        ////public int StudentId { get; set; }
        [ValidateNever]
        public ICollection<StudentCourse> StudentCourses { get; set; }
        [ValidateNever]
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
