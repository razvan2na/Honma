namespace Honma.Models;

public readonly record struct Market(
    string Symbol,
    List<TradeGood> Exports,
    List<TradeGood> Imports,
    List<TradeGood> Exchange,
    List<MarketTransaction>? Transactions,
    List<MarketTradeGood>? TradeGoods
);