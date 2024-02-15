namespace Honma.Models;

public readonly record struct Shipyard(
    string Symbol,
    IReadOnlyList<ShipType> ShipTypes,
    IReadOnlyList<ShipyardTransaction>? Transactions,
    IReadOnlyList<ShipyardShip>? Ships,
    int? ModificationFee
);