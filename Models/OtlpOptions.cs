namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents the options for configuring OpenTelemetry Protocol (OTLP).
/// </summary>
public class OtlpOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether OTLP is enabled.
    /// </summary>
    public bool Enabled { get; set; } = false;

    /// <summary>
    /// Gets or sets the OTLP endpoint.
    /// </summary>
    public string Endpoint { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the OTLP protocol.
    /// </summary>
    public string Protocol { get; set; } = string.Empty;
}
