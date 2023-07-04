namespace TerraInvestimentos.Application.Branches.Queries.GetBranchesFromGithub;

public class Branch
{
    public string name { get; set; }
    public Commit commit { get; set; }
    public bool @protected { get; set; }
    public Protection protection { get; set; }
    public string protection_url { get; set; }
}
