using Newtonsoft.Json;

namespace WebCore.Model.Base.Newtonsoft
{
    internal class StringEnumConverter : WriteOnlyConverterNewtonsoft<StringEnum>
    {
        public override void WriteJson(JsonWriter writer, StringEnum value, JsonSerializer serializer)
        {
            // ToString was overwritten by StringEnum -> safe to just print the string representation
            writer.WriteValue(value.ToString());
        }
    }
}