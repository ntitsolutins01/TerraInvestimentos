namespace TerraInvestimentos.Application.ExternalServices.Github.Request
{
    public class PostObjectWebhookRequest
    {
        public string name { get; set; }
        public bool active { get; set; }
        public string[] events { get; set; }
    }
}
