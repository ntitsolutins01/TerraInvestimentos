namespace TerraInvestimentos.Application.Webhooks.Queries.GetWebhooksFromGithub
{
    public class Webhook
    {
        public string name { get; set; }
        public int type { get; set; }
        public int id  { get; set; }
        public bool active { get; set; }
        public List<Events> events { get; set; }
        public Config config { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }
        public string url { get; set; }
        public string test_url { get; set; }
        public string ping_url { get; set; }
        public string deliveries_url { get; set; }
        public LastResponse last_response { get; set; }
    }
}
