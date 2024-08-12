namespace Honma.Data;

public readonly record struct PurchaseShipRequest(
    string ShipType,
    string WaypointSymbol
);