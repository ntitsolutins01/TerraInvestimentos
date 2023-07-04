using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Domain.Entities;
using TerraInvestimentos.Domain.Events;

namespace TerraInvestimentos.Application.Branches.Commands.CreateBranch;

public record CreateBranchCommand : IRequest<int>
{
    public string Name { get; init; }
}

public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBranchCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var entity = new Branch
        {
            Name = request.Name,
        };

        entity.AddDomainEvent(new BranchCreatedEvent(entity));

        _context.Branchs.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
