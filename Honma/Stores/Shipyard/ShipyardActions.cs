using Honma.Models;

namespace Honma.Stores;

public readonly record struct ShipyardLoad(string SystemSymbol, string WaypointSymbol);

public readonly record struct ShipyardUpdated(Shipyard Shipyard);