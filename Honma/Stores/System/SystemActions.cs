using Honma.Models;

namespace Honma.Stores;

public readonly record struct SystemLoad(string SystemSymbol);

public readonly record struct SystemUpdated(SystemDto System);