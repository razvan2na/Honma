namespace Honma.Dtos;

public readonly record struct ScannedShipDto(
    string Symbol,
    ShipRegistrationDto Registration,
    ShipNavDto Nav,
    ShipFrameDto Frame,
    ShipReactorDto Reactor,
    ShipEngineDto Engine,
    IReadOnlyList<ShipMountDto> Mounts
);