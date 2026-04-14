using Microsoft.AspNetCore.Mvc;
using Task3_API.Models;

namespace Task3_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(IConfiguration configuration, ILogger<FeedbackController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SubmitFeedback([FromQuery] int Rate, [FromBody] FeedbackRequest feedback)
        {
           
            string systemName = _configuration["SystemSettings:SystemName"];

         
            _logger.LogInformation("Feedback received from user: {UserName}", feedback.UserName);

            
            if (Rate < 3)
            {
                _logger.LogWarning("User {UserName} gave a low rating: {Rate}", feedback.UserName, Rate);
            }

            string message = $"Thank you {feedback.UserName}, {systemName} has received your Feedback!";

            return Ok(message);
        }
    }
}
