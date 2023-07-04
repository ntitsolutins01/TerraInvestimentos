using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraInvestimentos.Application.Webhooks.Commands.CreateWebhook;

namespace TerraInvestimentos.Application.Repositories.Commands.CreateRepository
{
    public class CreateRepositoryCommandValidator : AbstractValidator<CreateWebhookCommand>
    {
        public CreateRepositoryCommandValidator()
        {
            RuleFor(x => x.Owner)
                .NotNull()
                .NotEmpty().WithMessage("Usuário do repositório é obrigatório.");

            RuleFor(x => x.Repo)
                .NotNull()
                .NotEmpty().WithMessage("Nome do repositório é obrigatório.");
        }
    }
}
