namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents the configuration options for SQL Client.
/// </summary>
public class SqlClientOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether the SQL Client is enabled.
    /// </summary>
    public bool Enabled { get; set; } = false;
}
