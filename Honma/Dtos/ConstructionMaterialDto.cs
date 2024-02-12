namespace Honma.Dtos;

public readonly record struct ConstructionMaterialDto(
    string TradeSymbol,
    int Required,
    int Fulfilled
);