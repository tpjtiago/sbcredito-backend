using Newtonsoft.Json;
using System.Net;

namespace SBcredito.API.Configuration
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Log the exception if desired

            // Set the response status code
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Set the response content type to JSON
            context.Response.ContentType = "application/json";

            // Create a response object with the error message
            var response = new
            {
                error = ex.Message
            };

            // Serialize the response object to JSON
            var jsonResponse = JsonConvert.SerializeObject(response);

            // Write the JSON response to the response body
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
