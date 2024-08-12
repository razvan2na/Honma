using Honma.Models;

namespace Honma.Data;

public readonly record struct PurchaseShipResponse(
    Agent Agent,
    Ship Ship,
    ShipyardTransaction Transaction
);