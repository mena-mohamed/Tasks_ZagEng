using Microsoft.AspNetCore.Mvc;
using Task2_API.Filters;
using Task2_API.Models;
using Task2_API.Services;

namespace Task2_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        // Inject IJobService (not AppDbContext directly)
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET /api/jobs → return only active listings
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobs = _jobService.GetAllActive();
            return Ok(jobs);
        }

        // GET /api/jobs/{id} → return one listing by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var job = _jobService.GetById(id);

            if (job == null)
                return NotFound($"Job with ID {id} was not found.");

            return Ok(job);
        }

        // POST /api/jobs → create a new listing
        // ValidateJobFilter runs before this action to validate the body
        [HttpPost]
        [ServiceFilter(typeof(ValidateJobFilter))]
        public IActionResult Create([FromBody] JobListing job)
        {
            _jobService.Create(job);
            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        // PUT /api/jobs/{id} → update an existing listing
        // ValidateJobFilter runs before this action to validate the body
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateJobFilter))]
        public IActionResult Update(int id, [FromBody] JobListing job)
        {
            var existing = _jobService.GetById(id);

            if (existing == null)
                return NotFound($"Job with ID {id} was not found.");

            _jobService.Update(id, job);
            return Ok("Job updated successfully.");
        }

        // DELETE /api/jobs/{id} → soft delete (set IsActive = false)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _jobService.GetById(id);

            if (existing == null)
                return NotFound($"Job with ID {id} was not found.");

            _jobService.SoftDelete(id);
            return NoContent(); // 204
        }
    }
}
