using MassTransit;
using MasstransitTester.Messages;
using Microsoft.Extensions.Logging;

namespace MasstransitTester.Consumers;



public class DeliveryOrderCreatedConsumer : IConsumer<OrderFinishedMessage>
{
    private readonly ILogger<DeliveryOrderCreatedConsumer> _logger;

    public DeliveryOrderCreatedConsumer(ILogger<DeliveryOrderCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderFinishedMessage> context)
    {
        _logger.LogInformation($"DeliveryOrderCreatedConsumer: {context.Message.OrderNumber}");
        await Task.Delay(1);
    }
}

public class DeliveryOrderDefinition : ConsumerDefinition<DeliveryOrderCreatedConsumer>
{
    public DeliveryOrderDefinition()
    {
        EndpointName = "order-finished-2";
    }
}

public class SecondaryOrderCreatedConsumer : IConsumer<OrderFinishedMessage>
{
    private readonly ILogger<SecondaryOrderCreatedConsumer> _logger;

    public SecondaryOrderCreatedConsumer(ILogger<SecondaryOrderCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderFinishedMessage> context)
    {
        _logger.LogInformation($"SecondaryOrderCreatedConsumer: {context.Message.OrderNumber}");
        await Task.Delay(1);
    }
}

public class OrderCanceledConsumer : IConsumer<OrderCanceledMessage>
{
    private readonly ILogger<OrderCanceledConsumer> _logger;

    public OrderCanceledConsumer(ILogger<OrderCanceledConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderCanceledMessage> context)
    {
        _logger.LogInformation($"OrderCanceledConsumer: {context.Message.OrderNumber}");
        await Task.Delay(1);
    }
}
