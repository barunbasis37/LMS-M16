using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models
{
    public class Assignment : Entities
    {
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public int MaxPoints { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool Deleted { get; set; }

        public ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}