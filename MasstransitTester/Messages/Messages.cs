using MassTransit;

namespace MasstransitTester.Messages;

public record OrderCanceledMessage(string OrderNumber);

[EntityName("order-finished")]
public record OrderFinishedMessage(string OrderNumber);
