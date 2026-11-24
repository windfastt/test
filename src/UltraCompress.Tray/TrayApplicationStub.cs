namespace UltraCompress.Tray;

/// <summary>
/// Placeholder for WinUI 3 system tray host (single-instance mutex, engine IPC).
/// </summary>
public static class TrayApplicationStub
{
    public const string ProductName = "UltraCompress";

    public static string Describe() =>
        $"{ProductName} tray shell — WinUI 3 implementation planned (Phase 2).";
}