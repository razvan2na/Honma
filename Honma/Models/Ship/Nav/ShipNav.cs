namespace Honma.Models;

public readonly record struct ShipNav(
    string SystemSymbol,
    string WaypointSymbol,
    ShipNavRoute Route,
    string Status,
    string FlightMode
);