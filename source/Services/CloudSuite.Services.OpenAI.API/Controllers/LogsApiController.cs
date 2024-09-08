using CloudSuite.Modules.Application.OpenAI.Services.Contracts;
using CloudSuite.Modules.Application.OpenAI.Services.Implementatiosn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CloudSuite.Services.OpenAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsApiController : ControllerBase
    {
        private readonly string? _logFilePath;
        private readonly IOpenAIAppService _openAIAppService;
        private readonly object logContent;

        public LogsApiController(IConfiguration configuration, IOpenAIAppService openAIAppService)
        {
            _logFilePath = configuration["Logging:FileLogging:Path"];
            _openAIAppService = openAIAppService;

        }

        // Endpoint to read logs
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/api/[controller]/read-logs")]
        public async Task<IActionResult> ReadLogs()
        {
            if (string.IsNullOrEmpty(_logFilePath))
            {
                // Return 500 Internal Server Error if the log file path is not configured
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Log file path is not configured." });
            }

            if (!System.IO.File.Exists(_logFilePath))
            {
                // Return 404 Not Found if the log file does not exist
                return NotFound(new { message = "Log file not found." });
            }

            try
            {
                var logContent = await System.IO.File.ReadAllTextAsync(_logFilePath);

                // Try parsing the log content as JSON
                var jsonLog = JsonDocument.Parse(logContent).RootElement;

                // Return 200 OK with parsed JSON content
                return Ok(jsonLog);
            }
            catch (JsonException)
            {
                // If the log content cannot be parsed, return 200 OK with raw log content
                return Ok(new { rawLog = logContent });
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error for any other unexpected exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while reading the log file.", details = ex.Message });
            }

        }
    }
}
