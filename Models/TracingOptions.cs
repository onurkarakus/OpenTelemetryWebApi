namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents the tracing options for the application.
/// </summary>
public class TracingOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether tracing is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the list of tracing sources.
    /// </summary>
    public List<string> Sources { get; set; } = new();
}
