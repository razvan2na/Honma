using Fluxor;

namespace Honma.Stores.Contract;

[FeatureState]
public record ContractState()
{
    public IReadOnlyList<Models.Contract>? Contracts { get; init; }
}