namespace avaloniaAotTemplate.Models;

/// <summary>
/// Standard API response without business data.
/// 不带业务数据的标准 API 响应。
/// </summary>
public class ApiResult
{
    /// <summary>
    /// Business status code. Usually 0 means success.
    /// 业务状态码。通常 0 表示成功。
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Short status text returned by the server.
    /// 服务端返回的简短状态文本。
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Human-readable message returned by the server.
    /// 服务端返回的可读提示信息。
    /// </summary>
    public string Message { get; set; } = string.Empty;
}

/// <summary>
/// Standard API response with business data.
/// 带业务数据的标准 API 响应。
/// </summary>
public class ApiResult<T> : ApiResult
{
    /// <summary>
    /// Response data payload.
    /// 响应数据内容。
    /// </summary>
    public T? Data { get; set; }
}

/// <summary>
/// Example login request body.
/// 示例登录请求体。
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// User name, email, or phone number.
    /// 用户名、邮箱或手机号。
    /// </summary>
    public string Account { get; set; } = string.Empty;

    /// <summary>
    /// Plain request password. Hash it first if your server requires that.
    /// 请求密码。如果服务端要求，请先完成加密或哈希。
    /// </summary>
    public string Password { get; set; } = string.Empty;
}

/// <summary>
/// Example login response.
/// 示例登录响应。
/// </summary>
public class LoginResult
{
    /// <summary>
    /// Bearer token returned by the server.
    /// 服务端返回的 Bearer Token。
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Display name of the current user.
    /// 当前用户显示名称。
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;
}

/// <summary>
/// Example user profile DTO.
/// 示例用户资料 DTO。
/// </summary>
public class UserProfileDto
{
    /// <summary>
    /// User id.
    /// 用户 ID。
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Display name.
    /// 显示名称。
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Email address.
    /// 邮箱地址。
    /// </summary>
    public string Email { get; set; } = string.Empty;
}
