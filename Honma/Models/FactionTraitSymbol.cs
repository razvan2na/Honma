using System.Text.Json;
using System.Text.Json.Serialization;
using Honma.Models.Base;

namespace Honma.Models;

[JsonConverter(typeof(FactionTraitSymbolConverter))]
public record FactionTraitSymbol(string Value) : ConstantValue<FactionTraitSymbol>(Value);

public abstract class FactionTraitSymbols : IConstantCollection<FactionTraitSymbol>
{
    public static readonly FactionTraitSymbol Bureaucratic = new("BUREAUCRATIC");
    public static readonly FactionTraitSymbol Secretive = new("SECRETIVE");
    public static readonly FactionTraitSymbol Capitalistic = new("CAPITALISTIC");
    public static readonly FactionTraitSymbol Industrious = new("INDUSTRIOUS");
    public static readonly FactionTraitSymbol Peaceful = new("PEACEFUL");
    public static readonly FactionTraitSymbol Distrustful = new("DISTRUSTFUL");
    public static readonly FactionTraitSymbol Welcoming = new("WELCOMING");
    public static readonly FactionTraitSymbol Smugglers = new("SMUGGLERS");
    public static readonly FactionTraitSymbol Scavengers = new("SCAVENGERS");
    public static readonly FactionTraitSymbol Rebellious = new("REBELLIOUS");
    public static readonly FactionTraitSymbol Exiles = new("EXILES");
    public static readonly FactionTraitSymbol Pirates = new("PIRATES");
    public static readonly FactionTraitSymbol Raiders = new("RAIDERS");
    public static readonly FactionTraitSymbol Clan = new("CLAN");
    public static readonly FactionTraitSymbol Guild = new("GUILD");
    public static readonly FactionTraitSymbol Dominion = new("DOMINION");
    public static readonly FactionTraitSymbol Fringe = new("FRINGE");
    public static readonly FactionTraitSymbol Forsaken = new("FORSAKEN");
    public static readonly FactionTraitSymbol Isolated = new("ISOLATED");
    public static readonly FactionTraitSymbol Localized = new("LOCALIZED");
    public static readonly FactionTraitSymbol Established = new("ESTABLISHED");
    public static readonly FactionTraitSymbol Notable = new("NOTABLE");
    public static readonly FactionTraitSymbol Dominant = new("DOMINANT");
    public static readonly FactionTraitSymbol Inescapable = new("INESCAPABLE");
    public static readonly FactionTraitSymbol Innovative = new("INNOVATIVE");
    public static readonly FactionTraitSymbol Bold = new("BOLD");
    public static readonly FactionTraitSymbol Visionary = new("VISIONARY");
    public static readonly FactionTraitSymbol Curious = new("CURIOUS");
    public static readonly FactionTraitSymbol Daring = new("DARING");
    public static readonly FactionTraitSymbol Exploratory = new("EXPLORATORY");
    public static readonly FactionTraitSymbol Resourceful = new("RESOURCEFUL");
    public static readonly FactionTraitSymbol Flexible = new("FLEXIBLE");
    public static readonly FactionTraitSymbol Cooperative = new("COOPERATIVE");
    public static readonly FactionTraitSymbol United = new("UNITED");
    public static readonly FactionTraitSymbol Strategic = new("STRATEGIC");
    public static readonly FactionTraitSymbol Intelligent = new("INTELLIGENT");
    public static readonly FactionTraitSymbol ResearchFocused = new("RESEARCH_FOCUSED");
    public static readonly FactionTraitSymbol Collaborative = new("COLLABORATIVE");
    public static readonly FactionTraitSymbol Progressive = new("PROGRESSIVE");
    public static readonly FactionTraitSymbol Militaristic = new("MILITARISTIC");
    public static readonly FactionTraitSymbol TechnologicallyAdvanced = new("TECHNOLOGICALLY_ADVANCED");
    public static readonly FactionTraitSymbol Aggressive = new("AGGRESSIVE");
    public static readonly FactionTraitSymbol Imperialistic = new("IMPERIALISTIC");
    public static readonly FactionTraitSymbol TreasureHunters = new("TREASURE_HUNTERS");
    public static readonly FactionTraitSymbol Dexterous = new("DEXTEROUS");
    public static readonly FactionTraitSymbol Unpredictable = new("UNPREDICTABLE");
    public static readonly FactionTraitSymbol Brutal = new("BRUTAL");
    public static readonly FactionTraitSymbol Fleeting = new("FLEETING");
    public static readonly FactionTraitSymbol Adaptable = new("ADAPTABLE");
    public static readonly FactionTraitSymbol SelfSufficient = new("SELF_SUFFICIENT");
    public static readonly FactionTraitSymbol Defensive = new("DEFENSIVE");
    public static readonly FactionTraitSymbol Proud = new("PROUD");
    public static readonly FactionTraitSymbol Diverse = new("DIVERSE");
    public static readonly FactionTraitSymbol Independent = new("INDEPENDENT");
    public static readonly FactionTraitSymbol SelfInterested = new("SELF_INTERESTED");
    public static readonly FactionTraitSymbol Fragmented = new("FRAGMENTED");
    public static readonly FactionTraitSymbol Commercial = new("COMMERCIAL");
    public static readonly FactionTraitSymbol FreeMarkets = new("FREE_MARKETS");
    public static readonly FactionTraitSymbol Entrepreneurial = new("ENTREPRENEURIAL");
}

public class FactionTraitSymbolConverter : JsonConverter<FactionTraitSymbol>
{
    public override FactionTraitSymbol Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new FactionTraitSymbol(value ?? throw new InvalidOperationException());
    }

    public override void Write(Utf8JsonWriter writer, FactionTraitSymbol value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}