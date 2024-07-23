using Fluxor;
using Honma.Models;

namespace Honma.Stores.UserAgent;

[FeatureState]
public record UserAgentState
{
    public Agent? Agent { get; init; }
}