using TerraInvestimentos.Application.Branches.Queries.GetBranchesFromGithub;

namespace TerraInvestimentos.Application.ExternalServices.Github.Response
{
    public class BranchResponse
    {
        public List<Branch> Data { get; set; }
    }
}
