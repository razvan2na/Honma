using Honma.Models;

namespace Honma.Stores;

public readonly record struct ContractsLoad(int Limit, int Page);

public readonly record struct ContractsLoaded(IReadOnlyCollection<Contract> Contracts);

public readonly record struct ContractUpdated(Contract Contract);

public readonly record struct ContractAccept(string ContractId);
