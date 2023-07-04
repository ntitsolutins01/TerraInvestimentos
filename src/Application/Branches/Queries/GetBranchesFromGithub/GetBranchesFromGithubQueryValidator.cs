namespace TerraInvestimentos.Application.Branches.Queries.GetBranchesFromGithub
{
    public class GetBranchesFromGithubQueryValidator : AbstractValidator<GetBranchesFromGithubQuery>
    {
        public GetBranchesFromGithubQueryValidator()
        {
            RuleFor(x=>x.Owner)
                .NotNull()
                .NotEmpty().WithMessage("Usu�rio do reposit�rio � obrigat�rio.");
            
            RuleFor(x=>x.Repo)
                .NotNull()
                .NotEmpty().WithMessage("Nome do reposit�rio � obrigat�rio.");
        }
    }
}