namespace UltraCompress.Core.Ipc;

public interface IEnginePipeClient
{
    Task<bool> PingAsync(CancellationToken cancellationToken = default);

    Task<EngineResponse?> GetStatusAsync(CancellationToken cancellationToken = default);

    Task<bool> PauseAllAsync(CancellationToken cancellationToken = default);
}