namespace Honma.Models;

public readonly record struct ScannedSystem(
    string Symbol,
    string SectorSymbol,
    string Type,
    int X,
    int Y,
    int Distance
);