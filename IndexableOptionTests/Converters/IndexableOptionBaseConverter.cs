using IndexableOptionTests.TestClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IndexableOptionTests.Converters
{
#pragma warning disable 0618
    internal class IndexableOptionBaseConverter : JsonConverter<IndexableOptionBase>
    {
        public override IndexableOptionBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, IndexableOptionBase value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, value.Value.GetType(), options);
        }
    }
#pragma warning restore 0618
}
