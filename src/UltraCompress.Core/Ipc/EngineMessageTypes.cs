namespace UltraCompress.Core.Ipc;

public static class EngineMessageTypes
{
    public const string Ping = "ping";
    public const string Pong = "pong";
    public const string GetStatus = "getStatus";
    public const string Status = "status";
    public const string PauseAll = "pauseAll";
    public const string Ack = "ack";
    public const string Error = "error";
}