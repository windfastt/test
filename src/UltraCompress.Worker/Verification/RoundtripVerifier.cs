using System.Security.Cryptography;
using UltraCompress.Core;

namespace UltraCompress.Worker.Verification;

/// <summary>
/// Verifies lossless round-trip when recipe.verify requests it (stub: full pipeline integration in Phase 1+).
/// </summary>
public sealed class RoundtripVerifier
{
    public VerificationResult Verify(byte[] original, byte[] roundtripped, VerifyOptions options)
    {
        if (!options.DecompressRoundtrip)
        {
            return VerificationResult.Skipped("Round-trip verification disabled by recipe.");
        }

        if (!original.AsSpan().SequenceEqual(roundtripped))
        {
            return VerificationResult.Failed("Decompressed bytes do not match original.");
        }

        if (options.HashOriginal)
        {
            var hash = Convert.ToHexString(SHA256.HashData(original)).ToLowerInvariant();
            return VerificationResult.Success(hash);
        }

        return VerificationResult.Success(null);
    }
}

public sealed record VerificationResult(bool Passed, string? OriginalSha256, string Message)
{
    public static VerificationResult Success(string? sha256) =>
        new(true, sha256, "Round-trip verification passed.");

    public static VerificationResult Failed(string message) =>
        new(false, null, message);

    public static VerificationResult Skipped(string message) =>
        new(true, null, message);
}