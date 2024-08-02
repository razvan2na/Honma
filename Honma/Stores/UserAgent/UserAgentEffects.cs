using Fluxor;
using Honma.Authentication;
using Honma.Constants;
using Honma.Data;
using Honma.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Refit;

namespace Honma.Stores;

public class UserAgentEffects(
    ISpaceTradersClient client,
    UserTokenService userTokenService,
    AgentHistoryService agentHistoryService,
    ClientAuthenticationStateProvider authenticationStateProvider,
    NavigationManager navigationManager,
    ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(UserAgentInitialize action, IDispatcher dispatcher)
    {
        var token = await userTokenService.Get();

        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        await userTokenService.Set(token);

        try
        {
            var agent = (await client.GetMyAgent()).Data;
            authenticationStateProvider.NotifyUserAuthentication(token);
            dispatcher.Dispatch(new UserAgentUpdated(agent with { Token = token }));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
            dispatcher.Dispatch(new UserAgentLogout());
        }
    }

    [EffectMethod]
    public async Task Handle(UserAgentLogin action, IDispatcher dispatcher)
    {
        await userTokenService.Set(action.Token);

        try
        {
            var agent = (await client.GetMyAgent()).Data;
            authenticationStateProvider.NotifyUserAuthentication(action.Token);
            dispatcher.Dispatch(new UserAgentUpdated(agent with { Token = action.Token }));
            navigationManager.NavigateTo(Routes.Home);
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
            dispatcher.Dispatch(new UserAgentLogout());
        }
    }

    [EffectMethod]
    public async Task Handle(UserAgentLogout action, IDispatcher dispatcher)
    {
        await userTokenService.Remove();
        authenticationStateProvider.NotifyUserLogout();
        navigationManager.NavigateTo(Routes.Home);
    }

    [EffectMethod]
    public async Task Handle(UserAgentRegister action, IDispatcher dispatcher)
    {
        try
        {
            var userData = (await client.RegisterAgent(new AgentRegisterRequest(action.Symbol, action.FactionSymbol))).Data;

            await userTokenService.Set(userData.Token);
            authenticationStateProvider.NotifyUserAuthentication(userData.Token);
            dispatcher.Dispatch(new UserAgentRegistered(userData));
            navigationManager.NavigateTo(Routes.Home);
        }
        catch (ApiException exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task Handle(UserAgentRegistered action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await agentHistoryService.Get() ?? [];
            var serverStatus = await client.GetStatus();
            var newAgent = action.UserData.Agent with
            {
                Token = action.UserData.Token,
                ExpiresOn = serverStatus.ServerResets.Next
            };

            if (agentHistory.Any(agent => agent.AccountId == newAgent.AccountId))
            {
                agentHistory = agentHistory
                    .Select(agent => agent.AccountId == newAgent.AccountId ? newAgent : agent)
                    .ToList();
            }
            else
            {
                agentHistory = new List<Models.Agent>(agentHistory) { newAgent };
            }

            await agentHistoryService.Set(agentHistory);
            dispatcher.Dispatch(new AgentHistoryUpdated(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task Handle(UserAgentUpdated action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await agentHistoryService.Get() ?? [];
            var serverStatus = await client.GetStatus();
            var newAgent = action.Agent with
            {
                ExpiresOn = serverStatus.ServerResets.Next
            };

            if (agentHistory.Any(agent => agent.AccountId == newAgent.AccountId))
            {
                agentHistory = agentHistory
                    .Select(agent => agent.AccountId == newAgent.AccountId ? newAgent : agent)
                    .ToList();
            }
            else
            {
                agentHistory = new List<Models.Agent>(agentHistory) { newAgent };
            }

            await agentHistoryService.Set(agentHistory);
            dispatcher.Dispatch(new AgentHistoryUpdated(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}