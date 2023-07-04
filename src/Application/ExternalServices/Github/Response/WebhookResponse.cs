using TerraInvestimentos.Application.Webhooks.Queries.GetWebhooksFromGithub;

namespace TerraInvestimentos.Application.ExternalServices.Github.Response
{
    public  class WebhookResponse
    {
        public List<Webhook> Data { get; set; }
    }
}
