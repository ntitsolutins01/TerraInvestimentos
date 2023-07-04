namespace TerraInvestimentos.Application.Branches.Queries.GetBranchesFromGithub;

public class Protection
{
    public bool enabled { get; set; }
    public RequiredStatusChecks required_status_checks { get; set; }
}
