using Honma.Data;
using Honma.Models;
using Refit;

namespace Honma.Clients;

public interface ISystemsClient : IClient
{
    [Get("/systems/{systemSymbol}/waypoints/{waypointSymbol}/market")]
    Task<Response<Market>> GetMarket(string systemSymbol, string waypointSymbol);
}