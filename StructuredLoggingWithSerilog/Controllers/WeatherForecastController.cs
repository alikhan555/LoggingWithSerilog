using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StructuredLoggingWithSerilog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/Trace")]
        public async Task<ActionResult> LogTrace()
        {
            _logger.LogTrace("Trace logged.");
            return Ok();
        }

        [HttpGet("/Debug")]
        public async Task<ActionResult> LogDebug()
        {
            _logger.LogDebug("Debug logged.");
            return Ok();
        }

        [HttpGet("/Info")]
        public async Task<ActionResult> LogInfo()
        {
            _logger.LogInformation("Information logged.");
            return Ok();
        }

        [HttpGet("/Warning")]
        public async Task<ActionResult> LogWarning()
        {
            _logger.LogWarning("Warning logged.");
            return Ok();
        }

        [HttpGet("/Error")]
        public async Task<ActionResult> LogError()
        {
            _logger.LogError("Error logged.");
            return Ok();
        }

        [HttpGet("/Critical")]
        public async Task<ActionResult> LogCritical()
        {
            _logger.LogCritical("Critical logged.");
            return Ok();
        }

        [HttpGet("/EmplyeeDetail")]
        public async Task<ActionResult> LogDetailed()
        {
            var empBasicInfo = new
            {
                Name = "Muhammad Ali",
                FatherName = "Muhammad Afzal",
                Education = "Bachelor in Software Engineering"
            };

            var empOfficialInfo = new
            {
                Designation = "Software Engineer",
                BasicSalary = "10,000 USD",
                Experience = "5 years exp",
                Attendance = new[]
                {
                    new { date="01/01", status="P" },
                    new { date = "01/02", status = "P" },
                    new { date = "01/03", status = "P" },
                    new { date = "01/04", status = "A" }
                },
            };

            _logger.LogInformation("Employee personal info:{@EmployeePersonalInfo} and official info:{@EmployeeOfficialInfo}.", empBasicInfo, empOfficialInfo);
            return Ok();
        }

        [HttpGet("/Exception")]
        public async Task<ActionResult> LogException()
        {
            try
            {
                throw new Exception("This exception is thrown manually.");
            }
            catch(Exception ex)
            {
                _logger.LogCritical("Exception is thrown, Message: {@Message}, StackTrace: {@StackTrace}.", ex.Message, ex.StackTrace);
            }

            return Ok();
        }
    }
}