using IndexableOptionTests.TestClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IndexableOptionTests.Converters
{
    internal class IndexableOptionConverterGeneric<T> : JsonConverter<IndexableOption<T>>
    {
        public override IndexableOption<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, IndexableOption<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, value.Value.GetType(), options);
        }
    }
}
