namespace TerraInvestimentos.Application.ExternalServices.Github.Response
{
    public  class RepositoryResponse
    {
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public bool fork { get; set; }
        public string url { get; set; }
    }
}
