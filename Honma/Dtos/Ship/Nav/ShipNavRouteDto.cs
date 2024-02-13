namespace Honma.Dtos;

public readonly record struct ShipNavRouteDto(
    ShipNavRouteWaypointDto Destination,
    ShipNavRouteWaypointDto Origin,
    DateTime DepartureTime,
    DateTime Arrival
);