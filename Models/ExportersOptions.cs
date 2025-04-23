namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents the configuration options for exporters.
/// </summary>
public class ExportersOptions
{
    /// <summary>
    /// Gets or sets the configuration options for console output.
    /// </summary>
    public ConsoleOptions Console { get; set; } = new();

    /// <summary>
    /// Gets or sets the configuration options for OTLP (OpenTelemetry Protocol) output.
    /// </summary>
    public OtlpOptions Otlp { get; set; } = new();
}
