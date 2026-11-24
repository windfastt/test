namespace UltraCompress.Core;

/// <summary>
/// User-facing compression behavior tiers (see docs/user/USER.md).
/// </summary>
public enum CompressionProfile
{
    Balanced,
    Small,
    Tiny,
    Laboratory,
    Experimental,
}