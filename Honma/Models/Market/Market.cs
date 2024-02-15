namespace Honma.Models;

public readonly record struct Market(
    string Symbol,
    IReadOnlyList<TradeGood> Exports,
    IReadOnlyList<TradeGood> Imports,
    IReadOnlyList<TradeGood> Exchange,
    IReadOnlyList<MarketTransaction> Transactions,
    IReadOnlyList<MarketTradeGood> TradeGoods
);