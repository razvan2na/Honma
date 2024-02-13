namespace Honma.Dtos;

public readonly record struct ContractDeliverGoodDto(
    string TradeSymbol,
    string DestinationSymbol,
    int UnitsRequired,
    int UnitsFulfilled
);