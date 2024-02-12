namespace Honma.Dtos;

public readonly record struct ServerResetDto(
    DateTime Next,
    string Frequency
);