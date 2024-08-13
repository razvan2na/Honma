using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record MarketState
{
    public Market? Market { get; init; }
}