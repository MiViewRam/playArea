using FunctionAppHelper;
using IntegrationService.Data;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiView.Common.DateTime;
using MiView.Common.ServiceInfo;
using MiView.DataSubscription;
using MiView.Envelope;
using MiView.EventGrid;
using Serilog;
using System;
using System.IO;

[assembly: FunctionsStartup(typeof(IntegrationService.Functions.Startup))]
namespace IntegrationService.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var appConfiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .Build();

            var logger = new LoggerConfiguration().Enrich
                .FromLogContext()
                .WriteTo.ApplicationInsights(TelemetryConfiguration.CreateDefault(), TelemetryConverter.Traces)
                .WriteTo.Console()
                .CreateLogger();

            builder.Services.AddLogging(lb => lb.AddSerilog(logger));

            builder.Services.RegisterDbContext<IntegrationServiceContext>(appConfiguration["ConnectionString"]);
            builder.Services.RegisterAsOptions<AzureEventConfig>();

            builder.Services.AddScoped<IRequestProfile, RequestProfile>();
            builder.Services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            builder.Services.AddScoped<IServiceInfo, IntegrationServiceInfo>();
            builder.Services.AddScoped<IEnvelopeService, EnvelopeService>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IDataSubscriptionClient, DataSubscriptionClient>();

        }
    }
}
