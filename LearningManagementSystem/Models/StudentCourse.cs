using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models
{   
    public class StudentCourse : Entities
    {
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public decimal? Grade { get; set; }
    }
}