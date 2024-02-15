namespace Honma.Models;

public readonly record struct Cooldown(
    string ShipSymbol,
    int TotalSeconds,
    int RemainingSeconds,
    DateTime? Expiration
);