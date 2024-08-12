using Honma.Models;

namespace Honma.Data;

public readonly record struct ExtractResourcesResponse(
    Cooldown Cooldown,
    Extraction Extraction,
    ShipCargo Cargo
);