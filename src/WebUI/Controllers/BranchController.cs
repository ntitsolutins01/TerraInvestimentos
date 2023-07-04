using Microsoft.AspNetCore.Mvc;
using TerraInvestimentos.Application.Branches.Queries.GetBranchsWithPagination;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.WebUI.Controllers;

namespace WebUI.Controllers;

public class BranchController : ApiControllerBase
{
    /// <summary>
    /// Busca lista de branchs da tabela branch, no caso de UseInMemoryDatabase = true, tabela populada por ApplicationDbContextInitialiser linha 75
    /// </summary>
    /// <param name="query">objeto com parametros da paginação</param>
    /// <returns>retorna lista de branchs da tabela de UseInMemoryDatabase = true</returns>
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TerraInvestimentos.Application.Branches.Queries.GetBranchsWithPagination.BranchDto>>> GetBranchsWithPagination([FromQuery] GetBranchsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}
