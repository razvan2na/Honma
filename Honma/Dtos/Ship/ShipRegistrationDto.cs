namespace Honma.Dtos;

public readonly record struct ShipRegistrationDto(
    string Name,
    string FactionSymbol,
    string Role
);