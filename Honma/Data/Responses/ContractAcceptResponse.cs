using Honma.Models;

namespace Honma.Data;

public readonly record struct ContractAcceptResponse(
    Agent Agent,
    Contract Contract
);