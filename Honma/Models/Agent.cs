namespace Honma.Models;

public readonly record struct Agent(
    string? AccountId,
    string Symbol,
    string Headquarters,
    long Credits,
    string StartingFaction,
    int ShipCount,
    string? Token,
    DateTime? ExpiresOn
)
{
    public bool? IsExpired => ExpiresOn is null ? null : DateTime.UtcNow > ExpiresOn;
}