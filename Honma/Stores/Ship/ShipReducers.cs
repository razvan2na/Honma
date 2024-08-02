using Fluxor;
using Honma.Utils;

namespace Honma.Stores;

public static class ShipReducers
{
	[ReducerMethod]
	public static ShipState Reduce(ShipState state, ShipsUpdated action) => new()
	{
		Ships = action.Ships,
		Pagination = action.Pagination
	};
}