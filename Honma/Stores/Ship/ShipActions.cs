﻿using Honma.Data;
using Honma.Models;

namespace Honma.Stores;

public readonly record struct ShipsLoad(int Limit, int Page);

public readonly record struct ShipsUpdated(IReadOnlyCollection<Ship> Ships, Pagination Pagination);

public readonly record struct ShipPurchase(string ShipType, string WaypointSymbol);

public readonly record struct ShipLoad(string ShipSymbol);

public readonly record struct ShipUpdated(Ship Ship);

public readonly record struct ShipOrbit(string ShipSymbol);

public readonly record struct ShipDock(string ShipSymbol);

public readonly record struct ShipNavUpdated(string ShipSymbol, ShipNav Nav);