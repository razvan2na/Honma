using System.Text.Json;
using System.Text.Json.Serialization;
using Honma.Models.Base;

namespace Honma.Models;

[JsonConverter(typeof(FactionSymbolConverter))]
public record FactionSymbol(string Value) : ConstantValue<FactionSymbol>(Value);

public abstract class FactionSymbols : IConstantCollection<FactionSymbol>
{
    public static readonly FactionSymbol Cosmic = new("COSMIC");
    public static readonly FactionSymbol Void = new("VOID");
    public static readonly FactionSymbol Galactic = new("GALACTIC");
    public static readonly FactionSymbol Quantum = new("QUANTUM");
    public static readonly FactionSymbol Dominion = new("DOMINION");
    public static readonly FactionSymbol Astro = new("ASTRO");
    public static readonly FactionSymbol Corsairs = new("CORSAIRS");
    public static readonly FactionSymbol Obsidian = new("OBSIDIAN");
    public static readonly FactionSymbol Aegis = new("AEGIS");
    public static readonly FactionSymbol United = new("UNITED");
    public static readonly FactionSymbol Solitary = new("SOLITARY");
    public static readonly FactionSymbol Cobalt = new("COBALT");
    public static readonly FactionSymbol Omega = new("OMEGA");
    public static readonly FactionSymbol Echo = new("ECHO");
    public static readonly FactionSymbol Lords = new("LORDS");
    public static readonly FactionSymbol Cult = new("CULT");
    public static readonly FactionSymbol Ancients = new("ANCIENTS");
    public static readonly FactionSymbol Shadow = new("SHADOW");
    public static readonly FactionSymbol Ethereal = new("ETHEREAL");
}

public class FactionSymbolConverter : JsonConverter<FactionSymbol>
{
    public override FactionSymbol Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new FactionSymbol(value ?? throw new InvalidOperationException());
    }

    public override void Write(Utf8JsonWriter writer, FactionSymbol value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}
