using UltraCompress.Core.Ipc;

namespace UltraCompress.Tray.Services;

public sealed class EngineConnectionService : IDisposable
{
    private readonly NamedPipeEngineClient _client = new();

    public Task<bool> PingAsync(CancellationToken cancellationToken = default) =>
        _client.PingAsync(cancellationToken);

    public Task<EngineResponse?> GetStatusAsync(CancellationToken cancellationToken = default) =>
        _client.GetStatusAsync(cancellationToken);

    public Task<bool> PauseAllAsync(CancellationToken cancellationToken = default) =>
        _client.PauseAllAsync(cancellationToken);

    public void Dispose() => _client.Dispose();
}