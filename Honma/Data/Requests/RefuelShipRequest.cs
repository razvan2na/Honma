namespace Honma.Data;

public readonly record struct RefuelShipRequest(
    int? Units = null,
    bool? FromCargo = null
);