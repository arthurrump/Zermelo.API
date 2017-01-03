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
            object value = reader.Value;

            if (value == null)
                return null;

            long ticks = (long)value;

            DateTimeOffset d = UnixTimeHelpers.FromUnixTimeSeconds(ticks);

            return d;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long ticks;

            if (value is DateTimeOffset d)
            {
                ticks = UnixTimeHelpers.ToUnixTimeSeconds(d.UtcDateTime);
            }
            else
            {
                throw new JsonSerializationException($"Expected {nameof(DateTimeOffset)} object value.");
            }

            writer.WriteValue(ticks);
        }
    }
}
