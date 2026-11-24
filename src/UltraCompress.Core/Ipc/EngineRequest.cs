using System.Text.Json.Serialization;

namespace UltraCompress.Core.Ipc;

public sealed class EngineRequest
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }
}