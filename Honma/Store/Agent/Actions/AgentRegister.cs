using Honma.Models;

namespace Honma.Store;

public readonly record struct AgentRegister(string Symbol, FactionSymbol FactionSymbol);