﻿using Honma.Models;

namespace Honma.Icons;

public static class HonmaIcons
{
    public const string CaretRight = "ph-bold ph-caret-right";
    public const string ClockCountdown = "ph-bold ph-clock-countdown";
    public const string ClockCounterClockwise = "ph-bold ph-clock-counter-clockwise";
    public const string Compass = "ph-bold ph-compass";
    public const string Copy = "ph-bold ph-copy";
    public const string Cube = "ph-bold ph-cube";
    public const string Github = "ph-bold ph-github-logo";
    public const string Home = "ph-bold ph-house-simple";
    public const string Medal = "ph-bold ph-medal";
    public const string Path = "ph-bold ph-path";
    public const string Planet = "ph-bold ph-planet";
    public const string PiggyBank = "ph-bold ph-piggy-bank";
    public const string SignIn = "ph-bold ph-sign-in";
    public const string Trash = "ph-bold ph-trash-simple";
    public const string UserRectangle = "ph-bold ph-user-rectangle";
    public const string Key = "ph-bold ph-key";

    public const string Agent = "ph-bold ph-identification-badge";
    public const string AgentHistory = "ph-bold ph-user-list";
    public const string Announcement = "ph-bold ph-megaphone-simple";
    public const string Buy = "ph-bold ph-tray-arrow-down";
    public const string Cargo = "ph-bold ph-package";
    public const string Chart = "ph-bold ph-map-trifold";
    public const string Condition = "ph-bold ph-nut";
    public const string Contract = "ph-bold ph-file-text";
    public const string Credits = "ph-bold ph-currency-cny";
    public const string Crew = "ph-bold ph-users-three";
    public const string Dashboard = "ph-bold ph-kanban";
    public const string Engine = "ph-bold ph-engine";
    public const string Exchange = "ph-bold ph-swap";
    public const string Export = "ph-bold ph-arrow-square-out";
    public const string Faction = "ph-bold ph-flag-banner-fold";
    public const string Frame = "ph-bold ph-cube-transparent";
    public const string Fuel = "ph-bold ph-gas-can";
    public const string Import = "ph-bold ph-arrow-square-in";
    public const string Integrity = "ph-bold ph-subtract-square";
    public const string Jump = "ph-bold ph-compass-rose";
    public const string Loadout = "ph-bold ph-circuitry";
    public const string Market = "ph-bold ph-storefront";
    public const string Module = "ph-bold ph-diamonds-four";
    public const string MoraleHigh = "ph-bold ph-smiley";
    public const string MoraleMedium = "ph-bold ph-smiley-meh";
    public const string MoraleLow = "ph-bold ph-smiley-nervous";
    public const string MoraleVeryLow = "ph-bold ph-smiley-sad";
    public const string Mount = "ph-bold ph-memory";
    public const string Orbit = "ph-bold ph-planet";
    public const string Power = "ph-bold ph-lightning";
    public const string Range = "ph-bold ph-compass-tool";
    public const string Reactor = "ph-bold ph-atom";
    public const string Route = "ph-bold ph-path";
    public const string Sell = "ph ph-tray-arrow-up";
    public const string Ship = "ph-bold ph-rocket-launch";
    public const string Shipyard = "ph-bold ph-crane-tower";
    public const string Speed = "ph-bold ph-speedometer";
    public const string Strength = "ph-bold ph-crosshair-simple";
    public const string System = "ph-bold ph-map-pin-simple-area";
    public const string Warp = "ph-bold ph-aperture";
    public const string Waypoint = "ph-bold ph-map-pin-simple";

    public static readonly Dictionary<ShipPartSpecification, string> Specification = new()
    {
        { ShipPartSpecification.FuelCapacity, Fuel },
        { ShipPartSpecification.ModuleSlots, Module },
        { ShipPartSpecification.MountingPoints, Mount },
        { ShipPartSpecification.PowerOutput, Power },
        { ShipPartSpecification.Speed, Speed },
        { ShipPartSpecification.Capacity, Cargo },
        { ShipPartSpecification.Range, Range },
        { ShipPartSpecification.Strength, Strength }
    };
}