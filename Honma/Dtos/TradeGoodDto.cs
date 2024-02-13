namespace Honma.Dtos;

public readonly record struct TradeGoodDto(
    string Symbol,
    string Name,
    string Description
);