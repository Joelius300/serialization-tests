using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Base.Newtonsoft
{
    internal class IndexableOptionConverter<T> : WriteOnlyConverterNewtonsoft<Desired.IndexableOption<T>>
    {
        public override void WriteJson(JsonWriter writer, Desired.IndexableOption<T> value, JsonSerializer serializer)
        {
            try
            {
                // if it can be written in a single JToken, 
                // json.net understands what type the boxed object and serializes it accordingly -> correct value and type (eg. bool, string, double)
                writer.WriteValue(value.Value);
            }
            catch (JsonWriterException)
            {
                // if it couldn't be written in a single JToken it's probably multiple values (array). 
                // So we serialize explicitly
                serializer.Serialize(writer, value.Value);
            }
        }
    }
}
