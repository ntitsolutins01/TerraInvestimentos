using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.Application.ExternalServices.Github.Request;

namespace TerraInvestimentos.Application.Branches.Queries.GetBranchesFromGithub
{
    public class GetBranchesFromGithubQuery : IRequestWrapper<Branch>
    {
        public string Owner { get; set; }
        public string Repo { get; set; }
    }

    public class GetBranchesQueryHandler : IRequestHandlerWrapper<GetBranchesFromGithubQuery, Branch>
    {
        private readonly IGithubService _githubService;
        private readonly IMapper _mapper;

        public GetBranchesQueryHandler(IGithubService githubService, IMapper mapper)
        {
            _githubService = githubService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<Branch>> Handle(GetBranchesFromGithubQuery request, CancellationToken cancellationToken)
        {
            var branchRequest = _mapper.Map<BranchRequest>(request);

            var result = await _githubService.GetBranches(branchRequest, cancellationToken);

            return result.Succeeded
                ? ServiceResult.Success(_mapper.Map<Branch>(result.Data))
                : ServiceResult.Failed<Branch>(ServiceError.ServiceProvider);
        }
    }
}