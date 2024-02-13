namespace Honma.Dtos;

public readonly record struct ScannedSystemDto(
    string Symbol,
    string SectorSymbol,
    string Type,
    int X,
    int Y,
    int Distance
);