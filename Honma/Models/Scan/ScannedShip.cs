namespace Honma.Models;

public readonly record struct ScannedShip(
    string Symbol,
    ShipRegistration Registration,
    ShipNav Nav,
    ShipFrame Frame,
    ShipReactor Reactor,
    ShipEngine Engine,
    IReadOnlyList<ShipMount> Mounts
);