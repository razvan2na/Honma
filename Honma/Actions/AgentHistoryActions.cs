using Honma.Models;

namespace Honma.Actions;

public readonly record struct AgentHistoryLoad;

public readonly record struct AgentHistoryUpdated(IReadOnlyList<Agent> Agents);

public readonly record struct AgentHistoryRemoveAgent(string AccountId);