using System.Threading.Tasks;
using CategoryJobsEF.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class IDMiddleware
{
      private readonly RequestDelegate _next;
      private readonly IHelloWorldService _helloWorldService;
      private readonly ILogger<IDMiddleware> _logger;

      public IDMiddleware(RequestDelegate nextRequest, IHelloWorldService helloWorldService, ILogger<IDMiddleware> logger)
      {
            _next = nextRequest;
            _helloWorldService = helloWorldService;
            _logger = logger;
      }

      public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
      {
            await _next(context);
            var logMessage = $"Middleware: {_helloWorldService.GetHelloWorld()}";
            _logger.LogInformation(logMessage);
      }
}


public static class IDMiddlewareExtension
{
      public static IApplicationBuilder UseIDMiddleware(this IApplicationBuilder builder)
      {
            return builder.UseMiddleware<IDMiddleware>();
      }
}
