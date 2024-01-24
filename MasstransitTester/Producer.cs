using MassTransit;
using MasstransitTester.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MasstransitTester;

public class Producer(IServiceScopeFactory scopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(1000);
        var publisher = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IPublishEndpoint>();

        await publisher.Publish(new OrderFinishedMessage("1"));

        await Task.Delay(1000);

        await publisher.Publish(new OrderFinishedMessage("2"));


        await Task.Delay(1000);

        await publisher.Publish(new OrderCanceledMessage("2"));

        Console.WriteLine("Enter to exit");
        Console.ReadLine();
    }
}
