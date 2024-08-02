using Honma.Data;
using Honma.Models;

namespace Honma.Stores;

public readonly record struct ShipsLoad(int Limit, int Page);

public readonly record struct ShipsUpdated(IReadOnlyCollection<Ship> Ships, Pagination Pagination);

public readonly record struct ShipPurchase(string ShipType, string WaypointSymbol);
