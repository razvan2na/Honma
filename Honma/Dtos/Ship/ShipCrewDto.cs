namespace Honma.Dtos;

public readonly record struct ShipCrewDto(
    int Current,
    int Required,
    int Capacity,
    string Rotation,
    int Morale,
    int Wages
);