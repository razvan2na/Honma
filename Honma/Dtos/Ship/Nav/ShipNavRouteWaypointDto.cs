namespace Honma.Dtos;

public readonly record struct ShipNavRouteWaypointDto(
    string Symbol,
    string Type,
    string SystemSymbol,
    int X,
    int Y
);