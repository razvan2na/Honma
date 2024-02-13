namespace Honma.Dtos;

public readonly record struct MarketDto(
    string Symbol,
    IReadOnlyList<TradeGoodDto> Exports,
    IReadOnlyList<TradeGoodDto> Imports,
    IReadOnlyList<TradeGoodDto> Exchange,
    IReadOnlyList<MarketTransactionDto> Transactions,
    IReadOnlyList<MarketTradeGoodDto> TradeGoods
);