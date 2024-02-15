using Honma.Models;

namespace Honma.Dtos;

public readonly record struct Extraction(
    string ShipSymbol,
    ExtractionYield Yield,
    int Units
);