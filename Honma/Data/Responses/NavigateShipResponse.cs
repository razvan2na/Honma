using Honma.Models;

namespace Honma.Data;

public readonly record struct NavigateShipResponse(
    ShipFuel Fuel,
    ShipNav Nav
);