namespace Honma.Dtos;

public readonly record struct AgentDto(
    string? AccountId,
    string Symbol,
    string Headquarters,
    long Credits,
    string StartingFaction,
    int ShipCount
);