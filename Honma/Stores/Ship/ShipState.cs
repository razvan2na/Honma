using Fluxor;
using Honma.Data;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record ShipState
{
	public IReadOnlyCollection<Ship> Ships { get; init; } = [];

	public Pagination Pagination { get; init; }
}