﻿using System.Text;
using Honma.Authentication;
using Honma.Components.AgentHistory;
using Honma.Components.Authentication;
using Honma.Components.Contracts;
using Honma.Components.Factions;
using Honma.Components.Home;
using Honma.Components.Ship;
using Honma.Components.Ships;
using Honma.Components.Systems;
using Honma.Components.Waypoints;
using Honma.Constants;
using Honma.Icons;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Refit;

namespace Honma.Utils;

public static class Utils
{
    public static List<BreadcrumbItem> BuildBreadcrumbs(this RouteData routeData)
    {
        var breadcrumbs = new List<BreadcrumbItem>();

        if (routeData.PageType == typeof(HomePage))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Home, Routes.Home, false, HonmaIcons.Home));
        }
        else if (routeData.PageType == typeof(LoginPage))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Login, Routes.Login, false, HonmaIcons.SignIn));
        }
        else if (routeData.PageType == typeof(FactionsPage))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Factions, Routes.Factions, false, HonmaIcons.Faction));
        }
        else if (routeData.PageType == typeof(AgentHistoryPage))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.AgentHistory, Routes.AgentHistory, false,
                HonmaIcons.AgentHistory));
        }
        else if (routeData.PageType == typeof(ContractsPage))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Contracts, Routes.Contracts, false,
                HonmaIcons.Contract));
        }
        else if (routeData.PageType == typeof(ShipsPage))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Ships, Routes.Ships, false, HonmaIcons.Ship));
        }
        else if (routeData.PageType == typeof(ShipPage))
        {
            var shipSymbol = routeData.RouteValues.First(entry => entry.Key == "shipSymbol").Value!.ToString();

            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Ships, Routes.Ships, false, HonmaIcons.Ship));
            breadcrumbs.Add(new BreadcrumbItem(shipSymbol!, $"{Routes.Ships}/{shipSymbol}", false, HonmaIcons.Ship));
        }
        else if (routeData.PageType == typeof(SystemsPage))
        {
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Systems, Routes.Systems, false, HonmaIcons.System));
        }
        else if (routeData.PageType == typeof(SystemPage))
        {
            var systemSymbol = routeData.RouteValues.First(entry => entry.Key == "systemSymbol").Value!.ToString();

            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Systems, Routes.Systems, false, HonmaIcons.System));
            breadcrumbs.Add(new BreadcrumbItem(systemSymbol!, $"{Routes.Systems}/{systemSymbol}", false,
                HonmaIcons.System));
        }
        else if (routeData.PageType == typeof(WaypointPage))
        {
            var systemSymbol = routeData.RouteValues.First(entry => entry.Key == "systemSymbol").Value!.ToString();
            var waypointSymbol = routeData.RouteValues.First(entry => entry.Key == "waypointSymbol").Value!.ToString();

            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Systems, Routes.Systems, false, HonmaIcons.System));
            breadcrumbs.Add(new BreadcrumbItem(systemSymbol!, $"{Routes.Systems}/{systemSymbol}", false,
                HonmaIcons.System));
            breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Waypoints, $"{Routes.Systems}/{systemSymbol}", false,
                HonmaIcons.Waypoint));
            breadcrumbs.Add(new BreadcrumbItem(waypointSymbol!,
                $"{Routes.Systems}/{systemSymbol}{Routes.Waypoints}/{waypointSymbol}", false, HonmaIcons.Waypoint));
        }

        return breadcrumbs;
    }

    public static IEnumerable<T> Replace<T, TKey>(this IEnumerable<T> source, T item, Func<T, TKey> keySelector)
        where TKey : IEquatable<TKey>
    {
        return source.Select(i => keySelector.Invoke(i).Equals(keySelector.Invoke(item)) ? item : i);
    }

    public static string ToMacroCase(this string pascalCase)
    {
        if (string.IsNullOrEmpty(pascalCase))
        {
            return string.Empty;
        }

        var result = new StringBuilder();

        for (var i = 0; i < pascalCase.Length; i++)
        {
            var c = pascalCase[i];

            if (char.IsUpper(c) && i > 0)
            {
                result.Append('_');
            }

            result.Append(char.ToUpper(c));
        }

        return result.ToString();
    }

    public static string ToNaturalLanguage(this string pascalCase)
    {
        if (string.IsNullOrEmpty(pascalCase))
        {
            return pascalCase;
        }

        var result = new StringBuilder();

        foreach (var character in pascalCase)
        {
            if (char.IsUpper(character) && result.Length > 0)
            {
                result.Append(' ');
            }

            result.Append(character);
        }

        return result.ToString();
    }

    public static string ToFormattedLargeNumber(this int number)
    {
        return ToFormattedLargeNumber((long)number);
    }

    public static string ToFormattedLargeNumber(this long number)
    {
        return number switch
        {
            >= 1_000_000_000 => $"{number / 1_000_000_000.0:0.##}b",
            >= 1_000_000 => $"{number / 1_000_000.0:0.##}m",
            >= 1_000 => $"{number / 1_000.0:0.##}k",
            _ => number.ToString()
        };
    }

    public static DateTime AddTimezoneOffset(this DateTime dateTime, int offset)
    {
        return dateTime.Add(TimeSpan.FromMinutes(-offset));
    }

    public static void AddClient<T>(this IServiceCollection services) where T : class
    {
        services.AddRefitClient<T>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(Globals.SpaceTradersUrl))
            .AddHttpMessageHandler<AuthenticationHeaderHandler>();
    }
}