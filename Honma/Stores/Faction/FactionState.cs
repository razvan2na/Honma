using Fluxor;

namespace Honma.Stores.Faction;

[FeatureState]
public record FactionState
{
    public IReadOnlyList<Models.Faction>? Factions { get; init; }
}