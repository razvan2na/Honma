using Honma.Models;

namespace Honma.Actions;

public readonly record struct ContractAccept(int ContractId);

public readonly record struct ContractsLoad(int Limit, int Page);

public readonly record struct ContractsLoaded(IReadOnlyList<Contract> Contracts);

public readonly record struct ContractUpdated(Contract Contract);