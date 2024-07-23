using Honma.Constants;
using Honma.Icons;
using Honma.Pages;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Honma.Utils;

public static class Utils
{
    public static List<BreadcrumbItem> BuildBreadcrumbs(this RouteData routeData)
    {
        var breadcrumbs = new List<BreadcrumbItem>
        {
            new(BreadcrumbTexts.Home, Routes.Home, false, PhosphorIcons.Cube)
        };

        if (routeData.PageType == typeof(Login))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Login, Routes.Login, true));
        }
        else if (routeData.PageType == typeof(Factions))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Factions, Routes.Factions, true));
        }
        else if (routeData.PageType == typeof(AgentHistory))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.AgentHistory, Routes.AgentHistory, true));
        }
        else if (routeData.PageType == typeof(Contracts))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Contracts, Routes.Contracts, true));
        }

        return breadcrumbs;
    }
}