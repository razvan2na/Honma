using Fluxor;
using Honma.Models;

namespace Honma.States;

[FeatureState]
public record ContractsState()
{
    public IReadOnlyList<Contract>? Contracts { get; init; }
}