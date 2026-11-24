using UltraCompress.Core;
using ZstdSharp;

namespace UltraCompress.Worker.Backends;

public sealed class ZstdCompressionBackend : ICompressionBackend
{
    public string CodecName => "zstd";

    public Task<byte[]> CompressAsync(
        ReadOnlyMemory<byte> input,
        CompressStep step,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var level = Math.Clamp(step.Level, 1, 22);
        using var compressor = new Compressor(level);
        var output = compressor.Wrap(input.Span).ToArray();
        return Task.FromResult(output);
    }

    public Task<byte[]> DecompressAsync(
        ReadOnlyMemory<byte> compressed,
        CompressStep step,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        using var decompressor = new Decompressor();
        var output = decompressor.Unwrap(compressed.Span).ToArray();
        return Task.FromResult(output);
    }
}