using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Workaround
{ 
    internal class MyObjectEnumConverter : Base.WriteOnlyConverterSystemTextJson<MyObjectEnum>
    {
        public override void Write(System.Text.Json.Utf8JsonWriter writer, MyObjectEnum value, System.Text.Json.JsonSerializerOptions options)
        {
            System.Text.Json.JsonSerializer.Serialize(writer, value.Value, value.Value.GetType(), options);
        }
    }
}
