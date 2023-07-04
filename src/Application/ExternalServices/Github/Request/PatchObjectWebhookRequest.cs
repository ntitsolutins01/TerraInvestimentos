namespace TerraInvestimentos.Application.ExternalServices.Github.Request
{
    public class PatchObjectWebhookRequest
    {
        public bool active { get; set; }
        public string[] add_events { get; set; }
    }
}
