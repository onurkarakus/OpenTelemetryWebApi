namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents the configuration options for OpenTelemetry in the application.
/// </summary>
public class OpenTelemetryOptions
{
    /// <summary>
    /// Gets or sets the name of the service.
    /// </summary>
    public string ServiceName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the resource attributes options.
    /// </summary>
    public ResourceAttributesOptions ResourceAttributes { get; set; } = new();

    /// <summary>
    /// Gets or sets the tracing options.
    /// </summary>
    public TracingOptions Tracing { get; set; } = new();

    /// <summary>
    /// Gets or sets the instrumentation options.
    /// </summary>
    public InstrumentationOptions Instrumentation { get; set; } = new();

    /// <summary>
    /// Gets or sets the exporters options.
    /// </summary>
    public ExportersOptions Exporters { get; set; } = new();
}
