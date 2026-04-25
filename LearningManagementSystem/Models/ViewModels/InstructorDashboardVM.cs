namespace LearningManagementSystem.Models.ViewModels
{
    public class InstructorDashboardVM
    {
        public int InstructorId { get; set; }

        public int CoursesCount { get; set; }

        public int TotalStudents { get; set; }

        public int PendingAssignments { get; set; }

        public List<CourseSummaryVM> Courses { get; set; }
    }

    
}
