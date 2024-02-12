using Honma.Dtos;

namespace Honma.Models;

public readonly record struct Agent(
    string? AccountId,
    string Symbol,
    string Headquarters,
    long Credits,
    FactionSymbol StartingFaction,
    int ShipCount,
    string? Token,
    DateTime? ExpiresOn
)
{
    public Agent(AgentDto dto, string token, DateTime? expiresOn = null) : this(
        dto.AccountId,
        dto.Symbol,
        dto.Headquarters,
        dto.Credits,
        new FactionSymbol(dto.StartingFaction),
        dto.ShipCount,
        token,
        expiresOn) { }

    public bool? IsExpired => ExpiresOn is null ? null : DateTime.UtcNow > ExpiresOn;
}