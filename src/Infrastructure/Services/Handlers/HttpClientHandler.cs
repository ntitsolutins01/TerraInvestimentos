﻿using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Application.Common.Models;
using TerraInvestimentos.Domain.Enums;

namespace TerraInvestimentos.Infrastructure.Services.Handlers
{
    public class HttpClientHandler : IHttpClientHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HttpClientHandler> _logger;

        public HttpClientHandler(IHttpClientFactory httpClientFactory, ILogger<HttpClientHandler> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url, CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class
        {
            var httpClient = _httpClientFactory.CreateClient(clientApi);

            var requestName = typeof(TRequest).Name;

            try
            {
                _logger.LogInformation("HttpClient Request: {RequestName} {@Request}", requestName, requestEntity);

                var response = method switch
                {
                    MethodType.Get => await httpClient.GetAsync(url, cancellationToken),
                    MethodType.Post => await httpClient.PostAsJsonAsync(url, requestEntity, cancellationToken),
                    MethodType.Patch => await httpClient.PatchAsJsonAsync(url, requestEntity, cancellationToken),
                    _ => null
                };

                if (response != null && response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
                    return ServiceResult.Success(data);
                }

                if (response == null)
                    return ServiceResult.Failed<TResult>(ServiceError.ServiceProvider);

                var message = await response.Content.ReadAsStringAsync(cancellationToken);

                var error = new ServiceError(message, (int)response.StatusCode);

                return ServiceResult.Failed<TResult>(error);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HttpClient Request: Exception não tratada para este request {RequestName} {@Request}", requestName, requestEntity);
                return ServiceResult.Failed<TResult>(ServiceError.CustomMessage(ex.ToString()));
            }
        }
    }
}
