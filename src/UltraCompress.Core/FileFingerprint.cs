namespace UltraCompress.Core;

/// <summary>
/// Static probe of a file used for advisor, caching, and recipe lookup.
/// </summary>
public sealed record FileFingerprint
{
    public required string Path { get; init; }

    public required long SizeBytes { get; init; }

    public required DateTimeOffset LastModifiedUtc { get; init; }

    /// <summary>SHA-256 of file contents (hex, lowercase).</summary>
    public string? ContentHashSha256 { get; init; }

    /// <summary>Detected MIME or magic label (e.g. application/pdf).</summary>
    public string? DetectedType { get; init; }

    /// <summary>Shannon entropy in bits per byte (0–8), when computed.</summary>
    public double? EntropyBitsPerByte { get; init; }

    public string SizeClass => SizeBytes switch
    {
        < 1024 => "tiny",
        < 1024 * 1024 => "small",
        < 100 * 1024 * 1024 => "medium",
        _ => "large",
    };
}