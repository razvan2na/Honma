namespace Honma.Dtos;

public readonly record struct ConnectedSystemDto(
    string Symbol,
    string SectorSymbol,
    string Type,
    string? FactionSymbol,
    int X,
    int Y,
    int Distance
);