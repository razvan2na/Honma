using Fluxor;
using Honma.Models;

namespace Honma.States;

[FeatureState]
public record FactionsState()
{
    public IReadOnlyList<Faction>? Factions { get; init; }
}