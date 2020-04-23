using System;
namespace APBDcw4.Middlewares
{


    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var file = File.AppendText("requestsLog.txt"))
            using (StreamReader readStream = new StreamReader(context.Request.Body))
            {
                string logBody = await readStream.ReadToEndAsync();
                await file.WriteLineAsync(
                    $"Method:{context.Request.Method}," +
                    $" Path:{context.Request.Path}," +
                    $" Query:{context.Request.QueryString}\n"
                    + $"Body: {logBody}\n");
            }

            await _next(context);
        }
    }
}