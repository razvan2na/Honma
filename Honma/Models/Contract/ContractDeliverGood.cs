namespace Honma.Models;

public readonly record struct ContractDeliverGood(
    string TradeSymbol,
    string DestinationSymbol,
    int UnitsRequired,
    int UnitsFulfilled
);