using IndexableOptionTests.Converters;
using IndexableOptionTests.TestClasses;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace IndexableOptionTests
{
    public class IndexableOptionWrappedTest
    {
        [Fact]
        public void Config_WithSerializer_Generic_Added()
        {
            // arrange
            string stringVal = "StringValue";
            int[] intVals = new[] { 7, 1, 5 };

            IndexableOption<string> stringOption = new IndexableOption<string>(stringVal);
            IndexableOption<int> intOption = new IndexableOption<int>(intVals);

            Config config = new Config
            {
                BackgroundColor = stringOption,
                BorderWidth = intOption
            };

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionConverterGeneric<int>());
            serializerOptions.Converters.Add(new IndexableOptionConverterGeneric<string>());

            // act
            string configJson = JsonSerializer.Serialize(config, serializerOptions);

            string rawStringJson = JsonSerializer.Serialize(stringVal, serializerOptions);
            string rawIntJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Contains(@$"""BackgroundColor"":{rawStringJson}", configJson);
            Assert.Contains(@$"""BorderWidth"":{rawIntJson}", configJson);
        }

        [Fact]
        public void Config_WithSerializer_Newtonsoft_Added()
        {
            // arrange
            string stringVal = "StringValue";
            int[] intVals = new[] { 7, 1, 5 };

            IndexableOption<string> stringOption = new IndexableOption<string>(stringVal);
            IndexableOption<int> intOption = new IndexableOption<int>(intVals);

            Config config = new Config
            {
                BackgroundColor = stringOption,
                BorderWidth = intOption
            };

            var serializerOptions = new Newtonsoft.Json.JsonSerializerSettings();
            serializerOptions.Converters.Add(new IndexableOptionConverterNewtonsoft());

            // act
            string configJson = Newtonsoft.Json.JsonConvert.SerializeObject(config, serializerOptions);

            string rawStringJson = Newtonsoft.Json.JsonConvert.SerializeObject(stringVal, serializerOptions);
            string rawIntJson = Newtonsoft.Json.JsonConvert.SerializeObject(intVals, serializerOptions);

            // assert
            Assert.Contains(@$"""BackgroundColor"":{rawStringJson}", configJson);
            Assert.Contains(@$"""BorderWidth"":{rawIntJson}", configJson);
        }

        [Fact]
        public void Config_Empty_WithSerializer_Newtonsoft_Added()
        {
            // arrange
            Config config = new Config(); // <-- default value for indexable options will be used

            var serializerOptions = new Newtonsoft.Json.JsonSerializerSettings();
            serializerOptions.Converters.Add(new IndexableOptionConverterNewtonsoft());

            // act
            string configJson = Newtonsoft.Json.JsonConvert.SerializeObject(config, serializerOptions);

            // assert
            Assert.Contains(@$"""BackgroundColor"":undefined", configJson);
            Assert.Contains(@$"""BorderWidth"":undefined", configJson);
        }

        [Fact]
        public void Config_WithSerializer_Factory_Added()
        {
            // arrange
            string stringVal = "StringValue";
            int[] intVals = new[] { 7, 1, 5 };

            IndexableOption<string> stringOption = new IndexableOption<string>(stringVal);
            IndexableOption<int> intOption = new IndexableOption<int>(intVals);

            Config config = new Config
            {
                BackgroundColor = stringOption,
                BorderWidth = intOption
            };

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionConverterFactory());

            // act
            string configJson = JsonSerializer.Serialize(config, serializerOptions);

            string rawStringJson = JsonSerializer.Serialize(stringVal, serializerOptions);
            string rawIntJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Contains(@$"""BackgroundColor"":{rawStringJson}", configJson);
            Assert.Contains(@$"""BorderWidth"":{rawIntJson}", configJson);
        }
    }
}
