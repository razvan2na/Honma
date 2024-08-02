using Honma.Models;

namespace Honma.Data;

public readonly record struct ShipPurchaseResponse(
	Agent Agent,
	Ship Ship,
	ShipyardTransaction Transaction
);