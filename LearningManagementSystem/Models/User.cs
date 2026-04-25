using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public enum UserRole
    {
        Instructor = 1,
        Student = 2
    }

    public abstract class User : Entities
    {
        [StringLength(50)]
        public string? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
       
    }


    
}
