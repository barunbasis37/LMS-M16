using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models
{
    public class Course : Entities
    {
        

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        [ValidateNever]
        public Instructor Instructor { get; set; }

        public int Credits { get; set; }
        public int MaxEnrollment { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ValidateNever]
        public ICollection<StudentCourse> StudentCourses { get; set; }
        [ValidateNever]
        public ICollection<Assignment> Assignments { get; set; }
    }
}
