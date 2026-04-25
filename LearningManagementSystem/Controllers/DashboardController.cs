using LearningManagementSystem.LMSDBContext;
using LearningManagementSystem.Models;
using LearningManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicatonDBContext _context;

        public DashboardController(ApplicatonDBContext context)
        {
            _context = context;
        }

        // ===============================
        // INSTRUCTOR DASHBOARD
        // ===============================
        public IActionResult InstructorDashboard(int instructorId)
        {
            var courses = _context.Courses
                .Where(c => c.InstructorId == instructorId)
                .Include(c => c.StudentCourses)
                .ToList();

            var totalStudents = _context.StudentCourses
                .Where(sc => sc.Course.InstructorId == instructorId)
                .Select(sc => sc.StudentId)
                .Distinct()
                .Count();

            var pendingAssignments = _context.StudentAssignments
                .Where(sa =>
                    sa.Assignment.Course.InstructorId == instructorId &&
                    sa.Status == AssignmentStatus.Pending)
                .Count();

            var vm = new InstructorDashboardVM
            {
                InstructorId = instructorId,
                CoursesCount = courses.Count,
                TotalStudents = totalStudents,
                PendingAssignments = pendingAssignments,

                Courses = courses.Select(c => new CourseSummaryVM
                {
                    CourseId = c.Id,
                    Title = c.Title,
                    StudentCount = c.StudentCourses.Count
                }).ToList()
            };

            return View(vm);
        }

        // ===============================
        // STUDENT DASHBOARD
        // ===============================
        public IActionResult StudentDashboard(int studentId)
        {
            var enrolledCourses = _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Include(sc => sc.Course)
                .ToList();

            var completedAssignments = _context.StudentAssignments
                .Where(sa => sa.StudentId == studentId &&
                             sa.Status == AssignmentStatus.Graded)
                .Count();

            var gradeProgress = _context.StudentAssignments
                .Where(sa => sa.StudentId == studentId &&
                             sa.PointsEarned != null)
                .Select(sa => sa.PointsEarned.Value)
                .DefaultIfEmpty(0)
                .Average();

            var vm = new StudentDashboardVM
            {
                StudentId = studentId,
                EnrolledCourses = enrolledCourses.Count,
                CompletedAssignments = completedAssignments,
                GradeProgress = gradeProgress,

                Courses = enrolledCourses.Select(ec => new StudentCourseVM
                {
                    CourseId = ec.CourseId,
                    Title = ec.Course.Title,
                    Grade = ec.Grade
                }).ToList()
            };

            return View(vm);
        }
    }
}
