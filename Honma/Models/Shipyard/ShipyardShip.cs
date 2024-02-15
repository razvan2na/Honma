using Honma.Dtos;

namespace Honma.Models;

public readonly record struct ShipyardShip(
    string Type,
    string Name,
    string Description,
    string Supply,
    string? Activity,
    int PurchasePrice,
    ShipFrame Frame,
    ShipReactor Reactor,
    ShipEngine Engine,
    IReadOnlyList<ShipModule> Modules,
    IReadOnlyList<ShipMount> Mounts,
    ShipCrew Crew
);