using Honma.Models;
using Refit;

namespace Honma.Data;

public interface ISpaceTradersClient
{
    [Get("/")]
    Task<ServerStatus> GetStatus();

    [Post("/register")]
    Task<Response<AgentRegisterResponse>> RegisterAgent([Body] AgentRegisterRequest request);

    [Get("/my/agent")]
    Task<Response<Agent>> GetMyAgent();

    [Get("/factions")]
    Task<Response<IReadOnlyList<Faction>>> GetFactions([Query] int limit, [Query] int page);

    [Get("/factions/{symbol}")]
    Task<Response<Faction>> GetFaction(string symbol);

    [Get("/my/contracts")]
    Task<Response<IReadOnlyList<Contract>>> GetContracts([Query] int limit, [Query] int page);

    [Post("/my/contracts/{contractId}/accept")]
    Task<Response<ContractAcceptResponse>> AcceptContract(string contractId);

    [Get("/my/ships")]
    Task<Response<IReadOnlyCollection<Ship>>> GetShips([Query] int limit, [Query] int page);

    [Get("/systems")]
    Task<Response<IReadOnlyCollection<SystemDto>>> GetSystems([Query] int limit, [Query] int page);

    [Get("/systems/{systemSymbol}")]
    Task<Response<SystemDto>> GetSystem(string systemSymbol);

    [Get("/systems/{systemSymbol}/waypoints/{waypointSymbol}")]
    Task<Response<Waypoint>> GetWaypoint(string systemSymbol, string waypointSymbol);
}