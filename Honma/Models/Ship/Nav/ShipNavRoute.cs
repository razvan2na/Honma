namespace Honma.Models;

public readonly record struct ShipNavRoute(
    ShipNavRouteWaypoint Destination,
    ShipNavRouteWaypoint Origin,
    DateTime DepartureTime,
    DateTime Arrival
);