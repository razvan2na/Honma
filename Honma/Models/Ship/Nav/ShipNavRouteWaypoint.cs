namespace Honma.Models;

public readonly record struct ShipNavRouteWaypoint(
    string Symbol,
    string Type,
    string SystemSymbol,
    int X,
    int Y
);