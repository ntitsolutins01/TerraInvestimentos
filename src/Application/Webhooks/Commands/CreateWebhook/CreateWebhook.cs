using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.Application.ExternalServices.Github.Request;
using TerraInvestimentos.Application.Webhooks.Queries.GetWebhooksFromGithub;

namespace TerraInvestimentos.Application.Webhooks.Commands.CreateWebhook
{
    public class CreateWebhookCommand : IRequestWrapper<Webhook>
    {
        public string Owner { get; set; }
        public string Repo { get; set; }
        public PostObjectWebhookRequest PostObjectWebhook { get; set; }

    }

    public class CreateWebhookCommandHandler : IRequestHandlerWrapper<CreateWebhookCommand, Webhook>
    {
        private readonly IGithubService _githubService;
        private readonly IMapper _mapper;

        public CreateWebhookCommandHandler(IGithubService githubService, IMapper mapper)
        {
            _githubService = githubService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<Webhook>> Handle(CreateWebhookCommand request, CancellationToken cancellationToken)
        {
            var branchRequest = _mapper.Map<WebhookRequest>(request);

            var result = await _githubService.PostWebhook(branchRequest, cancellationToken);

            return result.Succeeded
                ? ServiceResult.Success(_mapper.Map<Webhook>(result.Data))
                : ServiceResult.Failed<Webhook>(ServiceError.ServiceProvider);
        }
    }
}
