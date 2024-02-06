using Honma.Dtos;

namespace Honma.Models;

public readonly record struct Agent(
    string? AccountId,
    string Symbol,
    string Headquarters,
    long Credits,
    FactionSymbol StartingFaction,
    int ShipCount,
    string? Token
)
{
    public Agent(AgentDto dto, string token) : this(
        dto.AccountId,
        dto.Symbol,
        dto.Headquarters,
        dto.Credits,
        new FactionSymbol(dto.StartingFaction),
        dto.ShipCount,
        token)
    {
    }
}