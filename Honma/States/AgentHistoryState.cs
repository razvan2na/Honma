using Fluxor;
using Honma.Models;

namespace Honma.States;

[FeatureState]
public record AgentHistoryState
{
    public IReadOnlyList<Agent>? Agents { get; set; }
}