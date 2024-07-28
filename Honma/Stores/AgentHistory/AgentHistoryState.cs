using Fluxor;

namespace Honma.Stores;

[FeatureState]
public record AgentHistoryState
{
    public IReadOnlyList<Models.Agent>? Agents { get; set; }
}