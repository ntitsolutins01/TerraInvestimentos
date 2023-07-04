namespace TerraInvestimentos.Application.Webhooks.Queries.GetWebhooksFromGithub
{
    public class GetWebhooksFromGithubQueryValidator : AbstractValidator<GetWebhooksFromGithubQuery>
    {
        public GetWebhooksFromGithubQueryValidator()
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