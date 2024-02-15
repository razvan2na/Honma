namespace Honma.Models;

public readonly record struct ShipRegistration(
    string Name,
    string FactionSymbol,
    string Role
);