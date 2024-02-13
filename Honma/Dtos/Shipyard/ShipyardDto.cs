namespace Honma.Dtos;

public readonly record struct ShipyardDto(
    string Symbol,
    IReadOnlyList<ShipTypeDto> ShipTypes,
    IReadOnlyList<ShipyardTransactionDto>? Transactions,
    IReadOnlyList<ShipyardShipDto>? Ships,
    int? ModificationFee
);