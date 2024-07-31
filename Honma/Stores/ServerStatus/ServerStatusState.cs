using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record ServerStatusState
{
    public ServerStatus? Status { get; init; }
}