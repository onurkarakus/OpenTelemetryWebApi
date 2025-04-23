
using Microsoft.Extensions.Options;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetryWebApi.Models;

namespace OpenTelemetryWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure OpenTelemetryOptions  
            builder.Services.Configure<OpenTelemetryOptions>(builder.Configuration.GetSection("OpenTelemetry"));

            var options = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<OpenTelemetryOptions>>().Value;

            builder.Services.AddOpenTelemetry()
                .ConfigureResource(resource =>
                {
                    resource.AddService(options.ServiceName).AddAttributes(new Dictionary<string, object>
                    {
                        { "environment", options.ResourceAttributes.Environment },
                        { "version", options.ResourceAttributes.Version }
                    });
                })
                .WithTracing(tracing =>
                {
                    if (!options.Tracing.Enabled)
                    {
                        return;
                    }

                    if (options.Instrumentation.AspNetCore.Enabled)
                    {
                        tracing.AddAspNetCoreInstrumentation(tracing => tracing.RecordException = true);
                    }

                    if (options.Instrumentation.HttpClient.Enabled)
                    {
                        tracing.AddHttpClientInstrumentation(tracing => { tracing.RecordException = true; });
                    }

                    if (options.Instrumentation.SqlClient.Enabled)
                    {
                        tracing.AddSqlClientInstrumentation(tracing => { tracing.RecordException = true; });
                    }

                    foreach (var source in options.Tracing.Sources)
                    {
                        tracing.AddSource(source);
                    }

                    if (options.Exporters.Console.Enabled)
                    {
                        tracing.AddConsoleExporter();
                    }

                    if (options.Exporters.Otlp.Enabled)
                    {
                        tracing.AddOtlpExporter(otlpOptions =>
                        {
                            otlpOptions.Endpoint = new Uri(options.Exporters.Otlp.Endpoint);
                            otlpOptions.Protocol = options.Exporters.Otlp.Protocol switch
                            {
                                "Grpc" => OpenTelemetry.Exporter.OtlpExportProtocol.Grpc,
                                "HttpProtobuf" => OpenTelemetry.Exporter.OtlpExportProtocol.HttpProtobuf,
                                _ => OpenTelemetry.Exporter.OtlpExportProtocol.Grpc
                            };
                        });
                    }
                });


            // Add services to the container.  
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();



            // Configure the HTTP request pipeline.  
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
