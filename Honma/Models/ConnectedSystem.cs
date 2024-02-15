namespace Honma.Models;

public readonly record struct ConnectedSystem(
    string Symbol,
    string SectorSymbol,
    string Type,
    string? FactionSymbol,
    int X,
    int Y,
    int Distance
);