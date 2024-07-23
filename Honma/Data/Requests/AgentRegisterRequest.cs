namespace Honma.Data;

public readonly record struct AgentRegisterRequest(
    string Symbol,
    string Faction
);