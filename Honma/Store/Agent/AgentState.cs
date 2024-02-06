using Fluxor;
using Honma.Models;

namespace Honma.Store;

[FeatureState]
public record AgentState()
{
    public Agent? Agent { get; init; }
}