// See https://aka.ms/new-console-template for more information
using MassTransit;
using MasstransitTester;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            // elided ...
            x.UsingAzureServiceBus((context, cfg) =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                var connString = hostContext.Configuration.GetValue<string>("azure-connection-string");
                cfg.Host(connString);

                cfg.ConfigureEndpoints(context);
            });
            x.AddConsumers(typeof(Producer).Assembly);
        });

        services.AddHostedService<Producer>();

    })
    .RunConsoleAsync();