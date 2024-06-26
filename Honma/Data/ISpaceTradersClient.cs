﻿using Honma.Models;
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
}