using Fluxor;
using Honma.Models;

namespace Honma.States;

[FeatureState]
public record AgentState()
{
    public Agent? Agent { get; init; }
}