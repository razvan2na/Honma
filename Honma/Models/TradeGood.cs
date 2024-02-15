namespace Honma.Models;

public readonly record struct TradeGood(
    string Symbol,
    string Name,
    string Description
);