using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectReviewFormApp.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Range(1, 5, ErrorMessage = "Satisfaction must be between 1 and 5.")]
        public int Satisfaction { get; set; }

        [Range(1, 5, ErrorMessage = "Helpfulness must be between 1 and 5.")]
        public int Helpfulness { get; set; }

        public string KeyTakeaways { get; set; }

        [Range(1, 5, ErrorMessage = "Logistics Satisfaction must be between 1 and 5.")]
        public int LogisticsSatisfaction { get; set; }

        public bool WouldRecommend { get; set; }

        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ProjectName { get; set; }

        // New properties added
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        public DateTime ReviewDate { get; set; }

        // Constructor
        public Feedback()
        {
            KeyTakeaways = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            ProjectName = string.Empty;
            ReviewDate = DateTime.Now; // Default to current date/time
        }
    }
}
