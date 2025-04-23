using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace OpenTelemetryWebApi.Controllers;

/// <summary>
/// Controller for handling OpenTelemetry-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OpenTelemetryController : ControllerBase
{
    /// <summary>
    /// ActivitySource for manual logging and telemetry operations.
    /// </summary>
    private static readonly ActivitySource ActivitySource = new ActivitySource("OpenTelemetryWebApi");

    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenTelemetryController"/> class.
    /// </summary>
    /// <param name="httpClientFactory">Factory for creating HTTP clients.</param>
    public OpenTelemetryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Makes an API call to an external service and returns the response.
    /// </summary>
    /// <returns>Response from the external API or an error message.</returns>
    [HttpGet("ApiCall")]
    public IActionResult ApiCall()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = httpClient.GetAsync("https://jsonplaceholder.typicode.com/users/1").Result;

        if (response.IsSuccessStatusCode)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return Ok(data);
        }
        else
        {
            return StatusCode((int)response.StatusCode, "Error fetching data");
        }
    }

    /// <summary>
    /// Logs custom metrics and events manually using OpenTelemetry.
    /// </summary>
    /// <param name="customerValue">Custom value to log as a tag.</param>
    /// <returns>A message indicating the logging operation was successful.</returns>
    [HttpGet("ManuelLog")]
    public IActionResult ManueLog(string customerValue)
    {
        using (var activity = ActivitySource.StartActivity("ManualLogOperation"))
        {
            activity?.SetTag("customerValue", customerValue);
            activity?.SetTag("operation", "manual_logging");
            activity?.SetTag("timestamp", DateTime.UtcNow);

            activity?.AddEvent(new ActivityEvent("Start processing"));
            Thread.Sleep(500);
            activity?.AddEvent(new ActivityEvent("End processing"));
        }

        return Ok("Metrics data with manual logging");
    }
}
