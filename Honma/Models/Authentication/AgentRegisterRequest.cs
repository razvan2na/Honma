namespace Honma.Models;

public readonly record struct AgentRegisterRequest(
    string Symbol,
    string Faction
);