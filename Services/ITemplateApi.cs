using System.IO;
using System.Threading.Tasks;
using avaloniaAotTemplate.Models;
using Refit;

namespace avaloniaAotTemplate.Services;

/// <summary>
/// Example Refit API contract.
/// Refit API 接口示例。
/// </summary>
public interface ITemplateApi
{
    /// <summary>
    /// Login example. Replace the route with your real API path.
    /// 登录示例。请替换为你的真实 API 路径。
    /// </summary>
    [Post("/api/auth/login")]
    Task<ApiResult<LoginResult>> LoginAsync([Body] LoginRequest request);

    /// <summary>
    /// Query current user profile with Bearer authorization.
    /// 使用 Bearer 授权查询当前用户资料。
    /// </summary>
    [Headers("Authorization: Bearer")]
    [Get("/api/user/profile")]
    Task<ApiResult<UserProfileDto>> GetProfileAsync();

    /// <summary>
    /// Simple GET request example with query parameters.
    /// 带查询参数的 GET 请求示例。
    /// </summary>
    [Get("/api/ping")]
    Task<ApiResult<string>> PingAsync([Query] string message);

    /// <summary>
    /// Multipart file upload example with Bearer authorization.
    /// 使用 Bearer 授权的 multipart 文件上传示例。
    /// </summary>
    [Multipart]
    [Headers("Authorization: Bearer")]
    [Post("/api/files/upload")]
    Task<ApiResult> UploadFileAsync([AliasAs("file")] StreamPart file);

    /// <summary>
    /// File download example.
    /// 文件下载示例。
    /// </summary>
    [Get("/api/files/download/{fileId}")]
    Task<Stream> DownloadFileAsync(string fileId);
}
