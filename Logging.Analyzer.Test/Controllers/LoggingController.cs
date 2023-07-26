using Microsoft.AspNetCore.Mvc;

namespace Logging.Analyzer.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILogger<LoggingController> _logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
            _logger.LogInformation("Test message: {Value}", Guid.NewGuid());
            _logger.LogInformation("Test message: {Value}", string.Empty);

            _logger.LogTestGuidWithoutGeneration(Guid.NewGuid());
            _logger.LogTestStringWithoutGeneration(string.Empty);

            _logger.LogTestGuid(Guid.NewGuid());
            _logger.LogTestString(string.Empty);
        }
    }
}
