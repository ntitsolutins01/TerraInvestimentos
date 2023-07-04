namespace TerraInvestimentos.Application.Branches.Queries.GetBranchesFromGithub
{
    public class GetBranchesFromGithubQueryValidator : AbstractValidator<GetBranchesFromGithubQuery>
    {
        public GetBranchesFromGithubQueryValidator()
        {
            RuleFor(x=>x.Owner)
                .NotNull()
                .NotEmpty().WithMessage("Usuário do repositório é obrigatório.");
            
            RuleFor(x=>x.Repo)
                .NotNull()
                .NotEmpty().WithMessage("Nome do repositório é obrigatório.");
        }
    }
}