using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record AgentHistoryState
{
    public IReadOnlyCollection<Agent> Agents { get; init; } = [];
}