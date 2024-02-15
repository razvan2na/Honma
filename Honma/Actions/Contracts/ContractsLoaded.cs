using Honma.Models;

namespace Honma.Actions;

public readonly record struct ContractsLoaded(IReadOnlyList<Contract> Contracts);