using Fluxor;

namespace Honma.Stores.AgentHistory;

[FeatureState]
public record AgentHistoryState
{
    public IReadOnlyList<Models.Agent>? Agents { get; set; }
}