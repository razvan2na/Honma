namespace Honma.Dtos;

public readonly record struct MarketTradeGoodDto(
    string Symbol,
    string Type,
    int TradeVolume,
    string Supply,
    string? Activity,
    int PurchasePrice,
    int SellPrice
);