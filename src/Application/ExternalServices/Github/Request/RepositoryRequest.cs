namespace TerraInvestimentos.Application.ExternalServices.Github.Request
{
    public class RepositoryRequest
    {
        public string name { get; set; } 
        public string description { get; set; }
        public string homepage { get; set; }
        public bool @private { get; set; }
        public bool is_template { get; set; }
    }
}
