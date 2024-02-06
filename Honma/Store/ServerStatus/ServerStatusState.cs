using Fluxor;
using Honma.Dtos;

namespace Honma.Store;

[FeatureState]
public record ServerStatusState()
{
    public ServerStatusDto? Status { get; init; }
}