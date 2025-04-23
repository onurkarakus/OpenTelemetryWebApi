namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents the options for configuring instrumentation in the application.
/// </summary>
public class InstrumentationOptions
{
    /// <summary>
    /// Gets or sets the options for configuring HTTP client instrumentation.
    /// </summary>
    public HttpClientOptions HttpClient { get; set; } = new();

    /// <summary>
    /// Gets or sets the options for configuring SQL client instrumentation.
    /// </summary>
    public SqlClientOptions SqlClient { get; set; } = new();

    /// <summary>
    /// Gets or sets the options for configuring ASP.NET Core instrumentation.
    /// </summary>
    public AspNetCoreOptions AspNetCore { get; set; } = new();
}
