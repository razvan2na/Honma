using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record ContractState
{
    public IReadOnlyCollection<Contract> Contracts { get; init; } = [];
}