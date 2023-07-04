using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.Application.ExternalServices.Github.Request;
using TerraInvestimentos.Application.ExternalServices.Github.Response;

namespace TerraInvestimentos.Application.Repositories.Commands.CreateRepository
{
    public class CreateRepositoryCommand : IRequestWrapper<RepositoryResponse>
    {
        public string name { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
        public bool @private { get; set; }
        public bool is_template { get; set; }

    }

    public class CreateRepositoryCommandHandler : IRequestHandlerWrapper<CreateRepositoryCommand, RepositoryResponse>
    {
        private readonly IGithubService _githubService;
        private readonly IMapper _mapper;

        public CreateRepositoryCommandHandler(IGithubService githubService, IMapper mapper)
        {
            _githubService = githubService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<RepositoryResponse>> Handle(CreateRepositoryCommand request, CancellationToken cancellationToken)
        {
            var branchRequest = _mapper.Map<RepositoryRequest>(request);

            var result = await _githubService.PostRepository(branchRequest, cancellationToken);

            return result.Succeeded
                ? ServiceResult.Success(_mapper.Map<RepositoryResponse>(result.Data))
                : ServiceResult.Failed<RepositoryResponse>(ServiceError.ServiceProvider);
        }
    }
}
