namespace UltraCompress.Core;

/// <summary>
/// Pluggable codec backend (zstd, 7z, brotli, …).
/// </summary>
public interface ICompressionBackend
{
    string CodecName { get; }

    Task<byte[]> CompressAsync(ReadOnlyMemory<byte> input, CompressStep step, CancellationToken cancellationToken = default);

    Task<byte[]> DecompressAsync(ReadOnlyMemory<byte> compressed, CompressStep step, CancellationToken cancellationToken = default);
}