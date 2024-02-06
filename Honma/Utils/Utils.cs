using System.Reflection;
using Honma.Constants;
using Honma.Icons;
using Honma.Models.Base;
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
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Login, Routes.Login, true));
        else if (routeData.PageType == typeof(Factions))
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Factions, Routes.Factions, true));
        else if (routeData.PageType == typeof(AgentHistory))
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.AgentHistory, Routes.AgentHistory, true));

        return breadcrumbs;
    }

    public static List<T> GetConstantValues<T, TCollection>() where TCollection : IConstantCollection<T> where T : class
    {
        var values = typeof(TCollection)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(f => f.FieldType == typeof(T))
            .Select(f =>
                f.GetValue(null) as T ?? throw new Exception($"Cannot get constant collection of type {typeof(T)}"))
            .ToList();

        return values;
    }
}