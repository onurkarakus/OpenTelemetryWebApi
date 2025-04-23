namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents the configuration options for the console output.
/// </summary>
public class ConsoleOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether the console output is enabled.
    /// Default value is true.
    /// </summary>
    public bool Enabled { get; set; } = true;
}
