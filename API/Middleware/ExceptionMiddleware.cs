using API.Errors;
using System.Net;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        /*
         * to check if we are in development mode  IHostEnvironment env
         */
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env) 
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        /*
         * Middleware method
         * RequestDelegate: function proccess in http request to move next into the next piece of middleware
         */
        public async Task InvokeAsync (HttpContext context)
        {
            try
            {
                await _next(context); // if no exception it will move to the next stage
            }
            catch (Exception ex) 
            { 
                _logger.LogError(ex, ex.Message);
                //write our own response to send to client
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //500 server error

                var response = _env.IsDevelopment()
                   ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) 
                   : new ApiException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);

            }
        }
    }
}
