using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Desired
{
    internal class StringEnumConverter : Base.WriteOnlyConverterSystemTextJson<StringEnum>
    {
        public override void Write(System.Text.Json.Utf8JsonWriter writer, StringEnum value, System.Text.Json.JsonSerializerOptions options)
        {
            // ToString was overwritten by StringEnum -> safe to just print the string representation
            writer.WriteStringValue(value.ToString());
        }
    }
}
