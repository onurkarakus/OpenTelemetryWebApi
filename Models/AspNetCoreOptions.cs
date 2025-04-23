namespace OpenTelemetryWebApi.Models;

/// <summary>
/// Represents the options for configuring ASP.NET Core features in the application.
/// </summary>
public class AspNetCoreOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether the ASP.NET Core features are enabled.
    /// </summary>
    public bool Enabled { get; set; } = false;
}
