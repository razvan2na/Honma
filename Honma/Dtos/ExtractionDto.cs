namespace Honma.Dtos;

public readonly record struct ExtractionDto(
    string ShipSymbol,
    ExtractionYieldDto Yield,
    int Units
);