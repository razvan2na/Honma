using Fluxor;
using Honma.Models;

namespace Honma.Store;

[FeatureState]
public record AgentHistoryState
{
    public IReadOnlyList<Agent>? Agents { get; set; }
}