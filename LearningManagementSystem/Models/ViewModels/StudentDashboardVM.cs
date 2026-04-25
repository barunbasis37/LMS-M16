namespace LearningManagementSystem.Models.ViewModels
{
    public class StudentDashboardVM
    {
        public int StudentId { get; set; }

        public int EnrolledCourses { get; set; }

        public int CompletedAssignments { get; set; }

        public decimal GradeProgress { get; set; }

        public List<StudentCourseVM> Courses { get; set; }
    }
}
