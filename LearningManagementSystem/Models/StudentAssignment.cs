using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models
{
    
    public enum AssignmentStatus
    {
        Pending,
        Submitted,
        Graded
    }

    public class StudentAssignment : Entities
    {
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public int AssignmentId { get; set; }
        [ForeignKey("AssignmentId")]
        public Assignment Assignment { get; set; }

        public DateTime? SubmissionDate { get; set; }

        public decimal? PointsEarned { get; set; }

        public AssignmentStatus Status { get; set; }

        public string Feedback { get; set; }
    }
}