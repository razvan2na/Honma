using Fluxor;
using Honma.Models;

namespace Honma.Store;

[FeatureState]
public record FactionsState()
{
    public IReadOnlyList<Faction>? Factions { get; init; }
}