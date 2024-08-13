using Honma.Models;

namespace Honma.Stores;

public readonly record struct MarketLoad(string SystemSymbol, string WaypointSymbol);

public readonly record struct MarketUpdated(Market Market);