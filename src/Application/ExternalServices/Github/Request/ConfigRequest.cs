namespace TerraInvestimentos.Application.ExternalServices.Github.Request
{
    public class ConfigRequest
    {
        public string url { get; set; }
        public string content_type { get; set; }
        public string insecure_ssl { get; set; }
    }
}
