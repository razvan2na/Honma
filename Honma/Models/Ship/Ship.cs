namespace Honma.Models;

public readonly record struct Ship(
    string Symbol,
    ShipRegistration Registration,
    ShipNav Nav,
    ShipCrew Crew,
    ShipFrame Frame,
    ShipReactor Reactor,
    ShipEngine Engine,
    Cooldown Cooldown,
    IReadOnlyList<ShipModule> Modules,
    IReadOnlyList<ShipMount> Mounts,
    ShipCargo Cargo,
    ShipFuel Fuel
);