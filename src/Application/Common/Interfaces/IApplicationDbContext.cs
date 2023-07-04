using TerraInvestimentos.Domain.Entities;

namespace TerraInvestimentos.Application.Common.Interfaces;

public interface IApplicationDbContext
{

    DbSet<Branch> Branchs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
