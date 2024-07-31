using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record UserAgentState
{
    public Agent? Agent { get; init; }
}