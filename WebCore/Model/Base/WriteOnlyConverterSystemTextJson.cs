using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebCore.Model.Base
{
    internal abstract class WriteOnlyConverterSystemTextJson<T> : JsonConverter<T>
    {
        public sealed override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException("Don't use me to read JSON");
        }

        public abstract override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options);
    }
}
