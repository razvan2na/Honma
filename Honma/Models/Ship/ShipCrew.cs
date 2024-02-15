namespace Honma.Models;

public readonly record struct ShipCrew(
    int Current,
    int Required,
    int Capacity,
    string Rotation,
    int Morale,
    int Wages
);