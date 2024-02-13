namespace Honma.Dtos;

public readonly record struct ShipNavDto(
    string SystemSymbol,
    string WaypointSymbol,
    ShipNavRouteDto Route,
    string Status,
    string FlightMode
);