using Microsoft.AspNetCore.Mvc;
using ProjectReviewFormApp.Data;
using ProjectReviewFormApp.Models;


namespace ProjectReviewFormApp.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        private readonly FeedbackContext _context;

        public FeedbackController(FeedbackContext context)
        {
            _context = context;
        }

        // Route: GET /feedback
        [HttpGet] // This should remain the same for listing feedbacks
        public IActionResult Index()
        {
            var feedbacks = _context.Feedbacks.ToList();
            return View(feedbacks);
        }

        // Route: GET /feedback/{id:int}
        [HttpGet("{id:int}")]
        public IActionResult Show(int id)
        {
            var feedback = _context.Feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // Route: GET /feedback/create
        [HttpGet("create")] // Specify the route for creating feedback
        public IActionResult Create()
        {
            return View();
        }

        // Route: POST /feedback/create
        [HttpPost("create")] // Ensure the POST route matches the GET
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.CreatedAt = DateTime.Now; // Set the creation date
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedback);
        }
    }
}
