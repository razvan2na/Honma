namespace Honma.Dtos;

public readonly record struct SiphonDto(
    string ShipSymbol,
    SiphonYieldDto Yield
);