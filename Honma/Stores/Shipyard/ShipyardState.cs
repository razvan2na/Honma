using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record ShipyardState
{
	public Shipyard? Shipyard { get; set; }
}