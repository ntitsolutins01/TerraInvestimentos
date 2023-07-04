using Microsoft.AspNetCore.Mvc;
using TerraInvestimentos.Application.Branches.Queries.GetBranchesFromGithub;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.Application.ExternalServices.Github.Response;
using TerraInvestimentos.Application.Repositories.Commands.CreateRepository;
using TerraInvestimentos.Application.Webhooks.Commands.CreateWebhook;
using TerraInvestimentos.Application.Webhooks.Commands.UpdateWebhook;
using TerraInvestimentos.Application.Webhooks.Queries.GetWebhooksFromGithub;
using TerraInvestimentos.WebUI.Controllers;

namespace WebUI.Controllers;

public class AntiCorrupcaoController : ApiControllerBase
{
    /// <summary>
    /// Cria um novo repositório para o usuário autenticado.
    /// </summary>
    /// <param name="command">Parâmetros para "Cria um novo repositório para o usuário autenticado."</param>
    /// <returns>retorna informaçoes do repositório criado</returns>
    [HttpPost("repos")]
    public async Task<ActionResult<ServiceResult<RepositoryResponse>>> CreateRepository([FromQuery] CreateRepositoryCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Busca a lista de branchs do através do repositório e do usuário informado
    /// </summary>
    /// <param name="query">Parâmetros para "List branches"</param>
    /// <returns>retorna lista de branches do github</returns>
    [HttpGet("branches")]
    public async Task<ActionResult<ServiceResult<Branch>>> GetBranchesFromGithub([FromQuery] GetBranchesFromGithubQuery query)
    {
        return await Mediator.Send(query);
    }

    /// <summary>
    /// Busca a Lista webhooks para um repositório. a última resposta pode retornar nulo se não houver entregas em 30 dias.
    /// </summary>
    /// <param name="query">Parâmetros para "List repository webhooks"</param>
    /// <returns>retorna lista de webhooks do github</returns>
    [HttpGet("hooks")]
    public async Task<ActionResult<ServiceResult<Webhook>>> GetWebhooksFromGithub([FromQuery] GetWebhooksFromGithubQuery query)
    {
        return await Mediator.Send(query);
    }

    /// <summary>
    /// Cria um webhook
    /// </summary>
    /// <param name="command">Parâmetros para "Create a webhook"</param>
    /// <returns>retorna informaçoes do webhook criado</returns>
    [HttpPost("hooks-create")]
    public async Task<ActionResult<ServiceResult<Webhook>>> CreateWebhook([FromQuery] CreateWebhookCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Atualiza webhook a partir do id do webhook
    /// </summary>
    /// <param name="id">id do webhook</param>
    /// <param name="command">objeti com dados a serem atualizados no webhook</param>
    /// <returns>retorna informaçoes do webhook atualizado</returns>
    [HttpPatch("hooks-update/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateWebhook(int id, UpdateWebhookCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}
