namespace Honma.Models;

public readonly record struct AgentRegisterResponse(
    Agent Agent,
    string Token
);