using Honma.Models;

namespace Honma.Stores;

public record ShipsLoad(int Limit, int Page);

public record ShipsUpdated(IReadOnlyCollection<Ship> Ships);
