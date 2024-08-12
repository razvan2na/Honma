using Honma.Models;

namespace Honma.Data;

public readonly record struct RefuelShipResponse(
    Agent Agent,
    ShipFuel Fuel,
    MarketTransaction Transaction
);