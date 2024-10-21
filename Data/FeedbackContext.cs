// File: Data/FeedbackContext.cs
// Project: ProjectReviewFormApp

using Microsoft.EntityFrameworkCore;
using ProjectReviewFormApp.Models;

namespace ProjectReviewFormApp.Data
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
