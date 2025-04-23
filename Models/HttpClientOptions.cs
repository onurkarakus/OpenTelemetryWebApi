namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents the configuration options for an HTTP client.
/// </summary>
public class HttpClientOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether the HTTP client is enabled.
    /// </summary>
    public bool Enabled { get; set; } = false;
}
