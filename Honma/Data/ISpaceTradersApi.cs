using Honma.Data.Responses;
using Honma.Dtos;
using Refit;

namespace Honma.Data;

public interface ISpaceTradersApi
{
    [Get("/")]
    Task<ServerStatusDto> GetStatus();

    [Post("/register")]
    Task<Response<UserDataDto>> RegisterAgent([Body] AgentRegisterDto dto);

    [Get("/my/agent")]
    Task<Response<AgentDto>> GetMyAgent();

    [Get("/factions")]
    Task<Response<IReadOnlyList<FactionDto>>> GetFactions([Query] int limit, [Query] int page);

    [Get("/factions/{symbol}")]
    Task<Response<FactionDto>> GetFaction(string symbol);

    [Get("/my/contracts")]
    Task<Response<IReadOnlyList<ContractDto>>> GetContracts([Query] int limit, [Query] int page);
}