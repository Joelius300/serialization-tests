using IndexableOptionTests.TestClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace IndexableOptionTests.Converters
{
    internal class IndexableOptionConverterNewtonsoft : JsonConverter
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            if (!objectType.IsGenericType) return false;
            
            return objectType.GetGenericTypeDefinition() == typeof(IndexableOption<>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // this doesn't work because it will apparently use the converter also in here resulting in an endless loop -> StackOverflow
            // JObject o = JObject.FromObject(value, serializer);
            // JProperty prop = o.Property(IndexableOption<object>.PropertyName);
            // prop.Value.WriteTo(writer);

            var prop = value.GetType().GetProperty(IndexableOption<object>.PropertyName, BindingFlags.Instance | BindingFlags.NonPublic);

            try
            {
                // if the indexable option was not initialized, this will throw an InvalidOperationException
                object toWrite = prop.GetValue(value);

                // write the property
                JToken.FromObject(toWrite).WriteTo(writer);
            }
            catch (TargetInvocationException oex) 
                when (oex.InnerException is InvalidOperationException iex)
            {
                Console.WriteLine("Error while trying to serialize an indexable option:");
                Console.WriteLine(iex.Message);

                // non-defined value
                writer.WriteUndefined();
            }
        }
    }
}
