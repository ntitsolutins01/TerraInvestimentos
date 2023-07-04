namespace TerraInvestimentos.Application.Webhooks.Queries.GetWebhooksFromGithub
{
    public class GetWebhooksFromGithubQueryValidator : AbstractValidator<GetWebhooksFromGithubQuery>
    {
        public GetWebhooksFromGithubQueryValidator()
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