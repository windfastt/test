namespace UltraCompress.Engine;

/// <summary>Volatile engine state surfaced to the tray via named pipes.</summary>
public sealed class EngineRuntimeState
{
    private int _activeJobs;
    private int _queuedJobs;
    private volatile bool _paused;

    public string ServiceState { get; } = "running";

    public string EngineVersion { get; } = "0.2.0-tray";

    public int ActiveJobs => Volatile.Read(ref _activeJobs);

    public int QueuedJobs => Volatile.Read(ref _queuedJobs);

    public bool Paused => _paused;

    public void SetPaused(bool paused) => _paused = paused;

    public void SetQueueDepth(int active, int queued)
    {
        Volatile.Write(ref _activeJobs, active);
        Volatile.Write(ref _queuedJobs, queued);
    }
}