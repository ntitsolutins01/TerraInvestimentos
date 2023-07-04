using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.Application.ExternalServices.Github.Request;

namespace TerraInvestimentos.Application.Webhooks.Queries.GetWebhooksFromGithub
{
    public class GetWebhooksFromGithubQuery : IRequestWrapper<Webhook>
    {
        public string Owner { get; set; }
        public string Repo { get; set; }
    }

    public class GetWebhooksQueryHandler : IRequestHandlerWrapper<GetWebhooksFromGithubQuery, Webhook>
    {
        private readonly IGithubService _githubService;
        private readonly IMapper _mapper;

        public GetWebhooksQueryHandler(IGithubService githubService, IMapper mapper)
        {
            _githubService = githubService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<Webhook>> Handle(GetWebhooksFromGithubQuery request, CancellationToken cancellationToken)
        {
            var branchRequest = _mapper.Map<WebhookRequest>(request);

            var result = await _githubService.GetWebhooks(branchRequest, cancellationToken);

            return result.Succeeded
                ? ServiceResult.Success(_mapper.Map<Webhook>(result.Data))
                : ServiceResult.Failed<Webhook>(ServiceError.ServiceProvider);
        }
    }
}