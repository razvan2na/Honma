using Fluxor;
using Honma.Data;
using Honma.Utils;
using MudBlazor;
using Exception = System.Exception;

namespace Honma.Stores;

public class ShipEffects(ISpaceTradersClient client, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(ShipsLoad action, IDispatcher dispatcher)
    {
        try
        {
            var (ships, pagination) = await client.GetShips(action.Limit, action.Page);

            dispatcher.Dispatch(
                new ShipsUpdated(
                    ships ?? throw new InvalidOperationException(),
                    pagination
                )
            );
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task Handle(ShipPurchase action, IDispatcher dispatcher)
    {
        try
        {
            var response = (await client.PurchaseShip(new ShipPurchaseRequest(action.ShipType, action.WaypointSymbol)))
                .Data;

            dispatcher.Dispatch(new UserAgentUpdated(response.Agent));

            snackbar.Add("Ship purchased!", Severity.Success);
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task Handle(ShipLoad action, IDispatcher dispatcher)
    {
        var ship = (await client.GetShip(action.ShipSymbol)).Data;
        dispatcher.Dispatch(new ShipUpdated(ship));
    }

    [EffectMethod]
    public async Task Handle(ShipOrbit action, IDispatcher dispatcher)
    {
        var shipNav = (await client.OrbitShip(action.ShipSymbol)).Data.Nav;
        dispatcher.Dispatch(new ShipNavUpdated(action.ShipSymbol, shipNav));
        snackbar.Add("The ship has successfully moved into orbit at its current location.", Severity.Success);
    }

    [EffectMethod]
    public async Task Handle(ShipDock action, IDispatcher dispatcher)
    {
        var shipNav = (await client.DockShip(action.ShipSymbol)).Data.Nav;
        dispatcher.Dispatch(new ShipNavUpdated(action.ShipSymbol, shipNav));
        snackbar.Add("The ship has successfully docked at its current location.", Severity.Success);
    }
}