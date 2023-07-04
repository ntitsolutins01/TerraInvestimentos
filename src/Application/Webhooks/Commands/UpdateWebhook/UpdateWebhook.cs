using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.Application.ExternalServices.Github.Request;
using TerraInvestimentos.Application.Webhooks.Queries.GetWebhooksFromGithub;

namespace TerraInvestimentos.Application.Webhooks.Commands.UpdateWebhook
{
    public class UpdateWebhookCommand : IRequestWrapper<Webhook>
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Repo { get; set; }
        public PatchObjectWebhookRequest PatchObjectWebhook { get; set; }
    }

    public class UpdateWebhookCommandHandler : IRequestHandlerWrapper<UpdateWebhookCommand, Webhook>
    {
        private readonly IGithubService _githubService;
        private readonly IMapper _mapper;

        public UpdateWebhookCommandHandler(IGithubService githubService, IMapper mapper)
        {
            _githubService = githubService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<Webhook>> Handle(UpdateWebhookCommand request, CancellationToken cancellationToken)
        {
            var branchRequest = _mapper.Map<WebhookRequest>(request);

            var result = await _githubService.PatchWebhook(branchRequest, cancellationToken);

            return result.Succeeded
                ? ServiceResult.Success(_mapper.Map<Webhook>(result.Data))
                : ServiceResult.Failed<Webhook>(ServiceError.ServiceProvider);
        }
    }
}
