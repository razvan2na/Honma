namespace Honma.Data;

public readonly record struct ShipPurchaseRequest(
	string ShipType,
	string WaypointSymbol
);