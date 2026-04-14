namespace Task2_API.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Save the start time before the request runs
            var startTime = DateTime.Now;
            var method = context.Request.Method;
            var path = context.Request.Path;

            // Pass the request to the next middleware in the pipeline
            await _next(context);

            // After the response is done, calculate how long it took
            var duration = (DateTime.Now - startTime).TotalMilliseconds;
            var statusCode = context.Response.StatusCode;

            // Log format: [2024-01-15 10:32:45] GET /api/jobs → 200 OK (took 12ms)
            Console.WriteLine($"[{startTime:yyyy-MM-dd HH:mm:ss}] {method} {path} → {statusCode} (took {duration:F0}ms)");
        }
    }
}
