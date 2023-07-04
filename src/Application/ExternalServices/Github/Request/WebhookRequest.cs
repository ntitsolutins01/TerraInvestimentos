namespace TerraInvestimentos.Application.ExternalServices.Github.Request
{
    public class WebhookRequest
    {
        public int HookId { get; set; }
        public string Owner { get; set; }
        public string Repo { get; set; }
        public PostObjectWebhookRequest PostObjectWebhook { get; set; }
        public PatchObjectWebhookRequest PatchObjectWebhook { get; set; }
    }
}
