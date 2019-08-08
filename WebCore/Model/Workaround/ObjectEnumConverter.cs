using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Workaround
{ 
    internal class ObjectEnumConverter<TObjectEnum> : Base.WriteOnlyConverterSystemTextJson<TObjectEnum> 
        where TObjectEnum : ObjectEnum
    {
        public override void Write(System.Text.Json.Utf8JsonWriter writer, TObjectEnum value, System.Text.Json.JsonSerializerOptions options)
        {
            System.Text.Json.JsonSerializer.Serialize(writer, value.Value, value.Value.GetType(), options);
        }
    }
}
