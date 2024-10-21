// Services/FeedbackService.cs
using Microsoft.EntityFrameworkCore;
using ProjectReviewFormApp.Data;
using ProjectReviewFormApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectReviewFormApp.Services
{
    public class FeedbackService
    {
        private readonly FeedbackContext _context;

        public FeedbackService(FeedbackContext context)
        {
            _context = context;
        }

        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task SaveFeedbackAsync(Feedback feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentNullException(nameof(feedback));
            }

            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }
    }
}
