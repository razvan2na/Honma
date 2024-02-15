using Fluxor;
using Honma.Models;

namespace Honma.States;

[FeatureState]
public record ServerStatusState()
{
    public ServerStatus? Status { get; init; }
}