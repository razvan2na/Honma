using Honma.Models;

namespace Honma.Data;

public readonly record struct AgentRegisterResponse(
    Agent Agent,
    string Token
);