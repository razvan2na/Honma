using Fluxor;

namespace Honma.Stores.ServerStatus;

[FeatureState]
public record ServerStatusState
{
    public Models.ServerStatus? Status { get; init; }
}