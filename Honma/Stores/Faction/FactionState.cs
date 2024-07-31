using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record FactionState
{
    public IReadOnlyCollection<Faction> Factions { get; init; } = [];
}