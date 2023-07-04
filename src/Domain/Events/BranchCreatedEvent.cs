namespace TerraInvestimentos.Domain.Events;

public class BranchCreatedEvent : BaseEvent
{
    public BranchCreatedEvent(Entities.Branch item)
    {
        Item = item;
    }

    public Entities.Branch Item { get; }
}
