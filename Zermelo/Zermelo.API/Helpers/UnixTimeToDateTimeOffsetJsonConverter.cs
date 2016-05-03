using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zermelo.API.Helpers
{
    internal class UnixTimeToDateTimeOffsetJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(DateTimeOffset) || objectType == typeof(int) || objectType == typeof(long))
                return true;

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(DateTimeOffset))
                throw new ArgumentException($"This converter can only convert to {nameof(DateTimeOffset)}.", nameof(objectType));

            if (reader.TokenType == JsonToken.Null)
                throw new JsonSerializationException($"Cannot convert null value to {objectType}");

            long ticks = (long)reader.Value;

            DateTimeOffset d = UnixTimeHelpers.FromUnixTimeSeconds(ticks);

            return d;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long ticks;

            if (value is DateTimeOffset)
            {
                DateTimeOffset dateTimeOffset = (DateTimeOffset)value;
                DateTimeOffset utcDateTimeOffset = dateTimeOffset.ToUniversalTime();
                ticks = UnixTimeHelpers.ToUnixTimeSeconds(utcDateTimeOffset.UtcDateTime);
            }
            else
            {
                throw new JsonSerializationException($"Expected {nameof(DateTimeOffset)} object value.");
            }

            writer.WriteStartConstructor("Date");
            writer.WriteValue(ticks);
            writer.WriteEndConstructor();

        }
    }
}
