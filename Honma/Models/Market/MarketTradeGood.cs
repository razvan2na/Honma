namespace Honma.Models;

public readonly record struct MarketTradeGood(
    string Symbol,
    string Type,
    int TradeVolume,
    string Supply,
    string? Activity,
    int PurchasePrice,
    int SellPrice
);