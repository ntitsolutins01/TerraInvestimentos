using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.Application.ExternalServices.Github.Request;
using TerraInvestimentos.Application.ExternalServices.Github.Response;
using TerraInvestimentos.Domain.Enums;

namespace TerraInvestimentos.Infrastructure.Services
{
    public class GithubService : IGithubService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "github-api";

        public GithubService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResult<RepositoryResponse>> PostRepository(RepositoryRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<RepositoryRequest, RepositoryResponse>(ClientApi,
                string.Concat("/user/repos"), cancellationToken, MethodType.Post);
        }
        public async Task<ServiceResult<BranchResponse>> GetBranches(BranchRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<BranchRequest, BranchResponse>(ClientApi,
                string.Concat($"repos/{request.Owner}/{request.Repo}/branches"), cancellationToken, MethodType.Get, request);
        }
        public async Task<ServiceResult<WebhookResponse>> GetWebhooks(WebhookRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<WebhookRequest, WebhookResponse>(ClientApi,
                string.Concat($"repos/{request.Owner}/{request.Repo}/hooks"), cancellationToken, MethodType.Get, request);
        }
        public async Task<ServiceResult<WebhookResponse>> PostWebhook(WebhookRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest< PostObjectWebhookRequest, WebhookResponse>(ClientApi,
                string.Concat($"/repos/{request.Owner}/{request.Repo}/hooks"), cancellationToken, MethodType.Post, request.PostObjectWebhook);
        }
        public async Task<ServiceResult<WebhookResponse>> PatchWebhook(WebhookRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<PatchObjectWebhookRequest, WebhookResponse>(ClientApi,
                string.Concat($"/repos/{request.Owner}/{request.Repo}/hooks/{request.HookId}"), cancellationToken, MethodType.Patch, request.PatchObjectWebhook);
        }
    }
}
