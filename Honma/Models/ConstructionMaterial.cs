namespace Honma.Models;

public readonly record struct ConstructionMaterial(
    string TradeSymbol,
    int Required,
    int Fulfilled
);