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
    Task<PagedResponse<Faction>> GetFactions([Query] int limit, [Query] int page);

    [Get("/factions/{symbol}")]
    Task<Response<Faction>> GetFaction(string symbol);

    [Get("/my/contracts")]
    Task<PagedResponse<Contract>> GetContracts([Query] int limit, [Query] int page);

    [Post("/my/contracts/{contractId}/accept")]
    Task<Response<ContractAcceptResponse>> AcceptContract(string contractId);

    [Get("/my/ships")]
    Task<PagedResponse<Ship>> GetShips([Query] int limit, [Query] int page);

    [Post("/my/ships")]
    Task<Response<PurchaseShipResponse>> PurchaseShip([Body] PurchaseShipRequest request);

    [Get("/my/ships/{shipSymbol}")]
    Task<Response<Ship>> GetShip(string shipSymbol);

    [Post("/my/ships/{shipSymbol}/orbit")]
    Task<Response<ShipNavUpdateResponse>> OrbitShip(string shipSymbol);

    [Post("/my/ships/{shipSymbol}/dock")]
    Task<Response<ShipNavUpdateResponse>> DockShip(string shipSymbol);

    [Post("/my/ships/{shipSymbol}/navigate")]
    Task<Response<NavigateShipResponse>> NavigateShip(string shipSymbol, [Body] NavigateShipRequest request);

    [Post("/my/ships/{shipSymbol}/refuel")]
    Task<Response<RefuelShipResponse>> RefuelShip(string shipSymbol, [Body] RefuelShipRequest request);

    [Post("/my/ships/{shipSymbol}/extract")]
    Task<Response<ExtractResourcesResponse>> ExtractResources(string shipSymbol);

    [Get("/systems")]
    Task<PagedResponse<SystemDto>> GetSystems([Query] int limit, [Query] int page);

    [Get("/systems/{systemSymbol}")]
    Task<Response<SystemDto>> GetSystem(string systemSymbol);

    [Get("/systems/{systemSymbol}/waypoints")]
    Task<PagedResponse<Waypoint>> GetSystemWaypoints(
        string systemSymbol,
        [Query] int limit,
        [Query] int page,
        [Query(CollectionFormat.Multi)] List<string>? traits = null,
        [Query] string? type = null);

    [Get("/systems/{systemSymbol}/waypoints/{waypointSymbol}")]
    Task<Response<Waypoint>> GetWaypoint(string systemSymbol, string waypointSymbol);

    [Get("/systems/{systemSymbol}/waypoints/{waypointSymbol}/market")]
    Task<Response<Market>> GetMarket(string systemSymbol, string waypointSymbol);

    [Get("/systems/{systemSymbol}/waypoints/{waypointSymbol}/shipyard")]
    Task<Response<Shipyard>> GetShipyard(string systemSymbol, string waypointSymbol);

    [Get("/systems/{systemSymbol}/waypoints/{waypointSymbol}/jump-gate")]
    Task<Response<JumpGate>> GetJumpGate(string systemSymbol, string waypointSymbol);
}