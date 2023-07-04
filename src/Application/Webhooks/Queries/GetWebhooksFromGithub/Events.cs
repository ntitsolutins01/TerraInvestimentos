namespace TerraInvestimentos.Application.Webhooks.Queries.GetWebhooksFromGithub;

public class Events
{
    public int push { get; set; }
    public int pull_request { get; set; }
}
