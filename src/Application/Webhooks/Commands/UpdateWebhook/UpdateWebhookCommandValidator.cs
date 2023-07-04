using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraInvestimentos.Application.Webhooks.Commands.UpdateWebhook
{
    public class UpdateWebhookCommandValidator : AbstractValidator<UpdateWebhookCommand>
    {
        public UpdateWebhookCommandValidator()
        {
            RuleFor(x => x.Owner)
                .NotNull()
                .NotEmpty().WithMessage("Usuário do repositório é obrigatório.");

            RuleFor(x => x.Repo)
                .NotNull()
                .NotEmpty().WithMessage("Nome do repositório é obrigatório.");

            RuleFor(x => x.PatchObjectWebhook.add_events)
                .NotNull()
                .NotEmpty().WithMessage("Array de eventos é obrigatório.");
        }
    }
}
