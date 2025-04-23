namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents options for resource attributes in the application.
/// </summary>
public class ResourceAttributesOptions
{
    /// <summary>
    /// Gets or sets the environment name where the application is running.
    /// </summary>
    public string Environment { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the version of the application.
    /// </summary>
    public string Version { get; set; } = string.Empty;
}
