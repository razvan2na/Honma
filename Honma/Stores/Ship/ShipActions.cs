using Honma.Data;
using Honma.Models;

namespace Honma.Stores;

public readonly record struct ShipsLoad(int Page);

public readonly record struct ShipsUpdated(IReadOnlyCollection<Ship> Ships, Pagination Pagination);

public readonly record struct ShipPurchase(string ShipType, string WaypointSymbol);

public readonly record struct ShipLoad(string ShipSymbol);

public readonly record struct ShipUpdated(Ship Ship);

public readonly record struct ShipOrbit(string ShipSymbol);

public readonly record struct ShipDock(string ShipSymbol);

public readonly record struct ShipNavigate(string ShipSymbol, string WaypointSymbol);

public readonly record struct ShipRefuel(string ShipSymbol, int? Units = null, bool? FromCargo = null);

public readonly record struct ShipExtractResources(string ShipSymbol);

public readonly record struct ShipNavUpdated(string ShipSymbol, ShipNav Nav);

public readonly record struct ShipFuelUpdated(string ShipSymbol, ShipFuel Fuel);

public readonly record struct ShipCooldownUpdated(string ShipSymbol, Cooldown Cooldown);

public readonly record struct ShipCargoUpdated(string ShipSymbol, ShipCargo Cargo);