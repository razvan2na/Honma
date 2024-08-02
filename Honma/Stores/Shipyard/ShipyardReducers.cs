using Fluxor;

namespace Honma.Stores;

public static class ShipyardReducers
{
	[ReducerMethod]
	public static ShipyardState Reduce(ShipyardState state, ShipyardUpdated action) => new()
	{
		Shipyard = action.Shipyard
	};
}