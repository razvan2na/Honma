namespace Honma.Dtos;

public readonly record struct CooldownDto(
    string ShipSymbol,
    int TotalSeconds,
    int RemainingSeconds,
    DateTime? Expiration
);