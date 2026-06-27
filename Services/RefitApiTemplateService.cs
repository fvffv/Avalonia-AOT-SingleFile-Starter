using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using avaloniaAotTemplate.Models;
using Refit;

namespace avaloniaAotTemplate.Services;

/// <summary>
/// Refit client factory and API service template for NativeAOT projects.
/// NativeAOT 项目可用的 Refit 客户端工厂与 API 服务模板。
/// </summary>
public class RefitApiTemplateService
{
    /// <summary>
    /// Strongly typed Refit API client.
    /// 强类型 Refit API 客户端。
    /// </summary>
    public ITemplateApi Api { get; }

    /// <summary>
    /// Create a Refit API service.
    /// 创建 Refit API 服务。
    /// </summary>
    /// <param name="baseAddress">
    /// Server base address, for example: https://api.example.com
    /// 服务端基础地址，例如：https://api.example.com
    /// </param>
    /// <param name="accessTokenProvider">
    /// Optional token provider for APIs marked with "Authorization: Bearer".
    /// 可选 Token 提供器，用于带有 "Authorization: Bearer" 的接口。
    /// </param>
    public RefitApiTemplateService(
        string baseAddress,
        Func<CancellationToken, Task<string>>? accessTokenProvider = null)
        : this(new Uri(baseAddress), accessTokenProvider)
    {
    }

    /// <summary>
    /// Create a Refit API service.
    /// 创建 Refit API 服务。
    /// </summary>
    public RefitApiTemplateService(
        Uri baseAddress,
        Func<CancellationToken, Task<string>>? accessTokenProvider = null)
    {
        var httpClient = new HttpClient(new ApiFallbackHandler(new HttpClientHandler()))
        {
            BaseAddress = baseAddress
        };

        Api = RestService.For<ITemplateApi>(httpClient, CreateRefitSettings(accessTokenProvider));
    }

    /// <summary>
    /// Create Refit settings with source-generated JSON serialization.
    /// 创建使用源生成 JSON 序列化的 Refit 配置。
    /// </summary>
    private static RefitSettings CreateRefitSettings(
        Func<CancellationToken, Task<string>>? accessTokenProvider)
    {
        var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            TypeInfoResolver = AppJsonSerializerContext.Default
        };

        return new RefitSettings(new SystemTextJsonContentSerializer(jsonOptions))
        {
            AuthorizationHeaderValueGetter = (_, cancellationToken) =>
            {
                return accessTokenProvider?.Invoke(cancellationToken)
                       ?? Task.FromResult(string.Empty);
            }
        };
    }
}

/// <summary>
/// Global HTTP fallback handler for template APIs.
/// 模板 API 的全局 HTTP 兜底处理器。
/// </summary>
public class ApiFallbackHandler : DelegatingHandler
{
    /// <summary>
    /// Create the fallback handler with an inner handler.
    /// 使用内部处理器创建兜底处理器。
    /// </summary>
    public ApiFallbackHandler(HttpMessageHandler innerHandler) : base(innerHandler)
    {
    }

    /// <summary>
    /// Convert network exceptions and non-success responses to a standard JSON response.
    /// 将网络异常和非成功响应转换成标准 JSON 响应。
    /// </summary>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
            Debug.WriteLine(errorContent);

            return CreateJsonResponse($"Request failed: {errorContent}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return CreateJsonResponse($"Network error: {ex.Message}");
        }
    }

    /// <summary>
    /// Create a standard AOT-safe JSON response.
    /// 创建标准的 AOT 安全 JSON 响应。
    /// </summary>
    private static HttpResponseMessage CreateJsonResponse(string message)
    {
        var payload = AotJsonSerializer.ToJson(new ApiResult
        {
            Code = -1,
            Status = "error",
            Message = message
        });

        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(payload, Encoding.UTF8, "application/json")
        };
    }
}
