using Fluxor;

namespace Honma.Stores;

public static class SystemReducers
{
	[ReducerMethod]
	public static SystemState Reduce(SystemState state, SystemUpdated action) => new()
	{
		System = action.System
	};
}