using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.Application.ExternalServices.Github.Request;
using TerraInvestimentos.Application.ExternalServices.Github.Response;

namespace TerraInvestimentos.Application.Common.Interfaces
{
    public interface IGithubService
    {
        Task<ServiceResult<RepositoryResponse>> PostRepository(RepositoryRequest request,
            CancellationToken cancellationToken);
        Task<ServiceResult<BranchResponse>> GetBranches(BranchRequest request,
            CancellationToken cancellationToken);
        Task<ServiceResult<WebhookResponse>> GetWebhooks(WebhookRequest request,
            CancellationToken cancellationToken);
        Task<ServiceResult<WebhookResponse>> PostWebhook(WebhookRequest request,
            CancellationToken cancellationToken);
        Task<ServiceResult<WebhookResponse>> PatchWebhook(WebhookRequest request,
            CancellationToken cancellationToken);
    }
}
