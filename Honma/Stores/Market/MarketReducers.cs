using Fluxor;

namespace Honma.Stores;

public static class MarketReducers
{
    [ReducerMethod]
    public static MarketState Reduce(MarketState state, MarketUpdated action)
    {
        return new MarketState { Market = action.Market };
    }
}