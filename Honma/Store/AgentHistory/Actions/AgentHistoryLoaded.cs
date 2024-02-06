using Honma.Models;

namespace Honma.Store;

public readonly record struct AgentHistoryLoaded(IReadOnlyList<Agent> Agents);