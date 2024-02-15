namespace Honma.Models;

public readonly record struct Siphon(
    string ShipSymbol,
    SiphonYield Yield
);