using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using avaloniaAotTemplate.Models;

namespace avaloniaAotTemplate.Services;

/// <summary>
/// JSON source generation context for NativeAOT-safe serialization.
/// When serialization or deserialization is required, register the related type here.
/// NativeAOT 安全 JSON 序列化所需的源生成上下文。
/// 需要序列化或反序列化时，请在这里注册对应类型。
/// </summary>
[JsonSerializable(typeof(UserRegInfoModel))]
[JsonSerializable(typeof(ApiResult))]
[JsonSerializable(typeof(ApiResult<string>))]
[JsonSerializable(typeof(ApiResult<LoginResult>))]
[JsonSerializable(typeof(ApiResult<UserProfileDto>))]
[JsonSerializable(typeof(LoginRequest))]
[JsonSerializable(typeof(LoginResult))]
[JsonSerializable(typeof(UserProfileDto))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}

/// <summary>
/// NativeAOT-safe JSON serialization helper.
/// NativeAOT 安全的 JSON 序列化工具。
/// </summary>
public static class AotJsonSerializer
{
    /// <summary>
    /// Shared JSON serializer options using the source-generated type resolver.
    /// 使用源生成类型解析器的全局共享 JSON 序列化配置。
    /// </summary>
    private static readonly JsonSerializerOptions AotOptions = new()
    {
        TypeInfoResolver = AppJsonSerializerContext.Default,
    };

    /// <summary>
    /// Serialize an object to a JSON string in a NativeAOT-safe way.
    /// 以 NativeAOT 安全的方式将对象序列化为 JSON 字符串。
    /// </summary>
    public static string ToJson<T>(T data)
    {
        var jsonTypeInfo = GetJsonTypeInfo(typeof(T));
        return JsonSerializer.Serialize(data, jsonTypeInfo);
    }

    /// <summary>
    /// Deserialize a JSON string to an object in a NativeAOT-safe way.
    /// 以 NativeAOT 安全的方式将 JSON 字符串反序列化为对象。
    /// </summary>
    public static T? FromJson<T>(string json)
    {
        var jsonTypeInfo = GetJsonTypeInfo(typeof(T));
        return (T?)JsonSerializer.Deserialize(json, jsonTypeInfo);
    }

    /// <summary>
    /// Get source-generated JSON metadata for the target type.
    /// 获取目标类型的源生成 JSON 元数据。
    /// </summary>
    private static JsonTypeInfo GetJsonTypeInfo(Type type)
    {
        return AppJsonSerializerContext.Default.GetTypeInfo(type)
               ?? throw new NotSupportedException(
                   $"Type '{type.FullName}' is not registered in {nameof(AppJsonSerializerContext)}.");
    }
}
