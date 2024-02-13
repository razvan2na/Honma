namespace Honma.Dtos;

public readonly record struct ShipDto(
    string Symbol,
    ShipRegistrationDto Registration,
    ShipNavDto Nav,
    ShipCrewDto Crew,
    ShipFrameDto Frame,
    ShipReactorDto Reactor,
    ShipEngineDto Engine,
    CooldownDto Cooldown,
    IReadOnlyList<ShipModuleDto> Modules,
    IReadOnlyList<ShipMountDto> Mounts,
    ShipCargoDto Cargo,
    ShipFuelDto Fuel
);