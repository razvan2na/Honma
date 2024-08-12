namespace Honma.Models;

public readonly record struct Extraction(
    string ShipSymbol,
    ExtractionYield Yield,
    int Units
);