using System.Text.Json.Serialization;
using System;
using System.Globalization;
using System.Text.Json;

namespace Firebase.Auth.Requests.Converters
{
    internal class JavaScriptDateTimeConverter : JsonConverter<DateTime>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            long timestamp;
            switch (reader.TokenType)
            {
                case JsonTokenType.Number:
                    timestamp = reader.GetInt64();
                    break;
                case JsonTokenType.String:
                    string input = reader.GetString();
                    if (!long.TryParse(input, out timestamp))
                    {
                        try
                        {
                            DateTime parsedValue = DateTime.Parse(input, CultureInfo.InvariantCulture);
                            return parsedValue;
                        }
                        catch (Exception)
                        {
                            throw new JsonException("Can't convert \"{input}\" into DateTime");
                        }
                    }
                    if (!options.NumberHandling.HasFlag(JsonNumberHandling.AllowReadingFromString))
                    {
                        throw new JsonException("Can't convert number string into DateTime, options do not allow reading numbers from strings");
                    }
                    break;
                case JsonTokenType.None:
                case JsonTokenType.StartObject:
                case JsonTokenType.EndObject:
                case JsonTokenType.StartArray:
                case JsonTokenType.EndArray:
                case JsonTokenType.PropertyName:
                case JsonTokenType.Comment:
                case JsonTokenType.True:
                case JsonTokenType.False:
                case JsonTokenType.Null:
                    throw new JsonException($"Can't convert {reader.TokenType} into DateTime");
                default:
                    throw new JsonException("Invalid JSON found reading DateTime");
            };

            if (timestamp > 1000000000000000L)
                return new(timestamp);
            if (timestamp > 1000000000000L)
                return DateTime.UnixEpoch.AddMilliseconds(timestamp);
            else
                return DateTime.UnixEpoch.AddSeconds(timestamp);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((long)(value - DateTime.UnixEpoch).TotalMilliseconds);
        }
    }
}
