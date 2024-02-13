namespace Honma.Dtos;

public readonly record struct ShipyardShipDto(
    string Type,
    string Name,
    string Description,
    string Supply,
    string? Activity,
    int PurchasePrice,
    ShipFrameDto Frame,
    ShipReactorDto Reactor,
    ShipEngineDto Engine,
    IReadOnlyList<ShipModuleDto> Modules,
    IReadOnlyList<ShipMountDto> Mounts,
    ShipCrewDto Crew
);