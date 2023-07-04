using Microsoft.Extensions.Logging;
using TerraInvestimentos.Domain.Events;

namespace TerraInvestimentos.Application.Branches.EventHandlers;

public class BranchCreatedEventHandler : INotificationHandler<BranchCreatedEvent>
{
    private readonly ILogger<BranchCreatedEventHandler> _logger;

    public BranchCreatedEventHandler(ILogger<BranchCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(BranchCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("TerraInvestimentos Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
