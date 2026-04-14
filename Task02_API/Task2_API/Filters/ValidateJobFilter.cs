using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Task2_API.Models;

namespace Task2_API.Filters
{
    public class ValidateJobFilter : IActionFilter
    {
        // OnActionExecuting runs BEFORE the controller action method runs
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Try to get the JobListing object from the request body
            var job = context.ActionArguments.Values
                             .OfType<JobListing>()
                             .FirstOrDefault();

            if (job == null)
            {
                context.Result = new BadRequestObjectResult("Request body is missing.");
                return;
            }

            // Validate: Title must not be empty
            bool titleEmpty = string.IsNullOrEmpty(job.Title);

            // Validate: Company must not be empty
            bool companyEmpty = string.IsNullOrEmpty(job.Company);

            // Validate: Salary must be greater than 0
            bool salaryInvalid = job.Salary <= 0;

            if (titleEmpty || companyEmpty || salaryInvalid)
            {
                // Block the request and return 400 before the action runs
                context.Result = new BadRequestObjectResult(
                    "Title and Company are required. Salary must be positive."
                );
            }
        }

        // OnActionExecuted runs AFTER the action — we don't need it here
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
