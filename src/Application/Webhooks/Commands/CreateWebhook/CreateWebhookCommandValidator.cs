using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraInvestimentos.Application.Webhooks.Commands.CreateWebhook
{
    public class CreateWebhookCommandValidator : AbstractValidator<CreateWebhookCommand>
    {
        public CreateWebhookCommandValidator()
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
