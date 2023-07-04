using TerraInvestimentos.Domain.Entities;

namespace TerraInvestimentos.Application.Branches.Queries.GetBranchsWithPagination;

public class BranchDto
{
    public string Name { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Branch, BranchDto>();
        }
    }
}