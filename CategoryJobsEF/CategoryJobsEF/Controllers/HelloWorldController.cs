using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryJobsEF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CategoryJobsEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldService _helloWorldService;
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
        {
            _helloWorldService = helloWorld;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var logMessage = $"Controller:{_helloWorldService.GetHelloWorld()}";
            _logger.LogInformation(logMessage);
            return Ok();
        }
    }
}
