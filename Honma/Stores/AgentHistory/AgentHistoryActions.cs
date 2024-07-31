using Honma.Models;

namespace Honma.Stores;

public readonly record struct AgentHistoryLoad;

public readonly record struct AgentHistoryUpdated(IReadOnlyCollection<Agent> Agents);

public readonly record struct AgentHistoryRemoveAgent(string AccountId);