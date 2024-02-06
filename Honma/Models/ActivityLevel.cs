using System.Text.Json;
using System.Text.Json.Serialization;
using Honma.Models.Base;

namespace Honma.Models;

[JsonConverter(typeof(ActivityLevelConverter))]
public record ActivityLevel(string Value) : ConstantValue<ActivityLevel>(Value);

public abstract class ActivityLevels : IConstantCollection<ActivityLevel>
{
    public static readonly ActivityLevel Weak = new("WEAK");
    public static readonly ActivityLevel Growing = new("GROWING");
    public static readonly ActivityLevel Strong = new("STRONG");
    public static readonly ActivityLevel Restricted = new("RESTRICTED");
}

public class ActivityLevelConverter : JsonConverter<ActivityLevel>
{
    public override ActivityLevel Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new ActivityLevel(value ?? throw new InvalidOperationException());
    }

    public override void Write(Utf8JsonWriter writer, ActivityLevel value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}