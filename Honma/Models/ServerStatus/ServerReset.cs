namespace Honma.Models;

public readonly record struct ServerReset(
    DateTime Next,
    string Frequency
);