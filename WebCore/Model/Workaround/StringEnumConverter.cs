using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Workaround
{
    internal class StringEnumConverter<TStringEnum> : Base.WriteOnlyConverterSystemTextJson<TStringEnum>
        where TStringEnum : StringEnum
    {
        public override void Write(System.Text.Json.Utf8JsonWriter writer, TStringEnum value, System.Text.Json.JsonSerializerOptions options)
        {
            // ToString was overwritten by StringEnum -> safe to just print the string representation
            writer.WriteStringValue(value.ToString());
        }
    }
}
