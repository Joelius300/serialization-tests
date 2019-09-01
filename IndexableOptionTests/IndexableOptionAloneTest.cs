using IndexableOptionTests.Converters;
using IndexableOptionTests.TestClasses;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace IndexableOptionTests
{
    public class IndexableOptionAloneTest
    {
        #region Single value

        private string DummyStringValue => "StringValue";

        [Fact]
        public void SingleValue_WithSerializer_Generic_Added()
        {
            // arrange
            string stringVal = DummyStringValue;
            IndexableOption<string> option = new IndexableOption<string>(DummyStringValue);

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionConverterGeneric<string>());

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(stringVal, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        [Fact]
        public void SingleValue_WithSerializer_Newtonsoft_Added()
        {
            // arrange
            string stringVal = DummyStringValue;
            IndexableOption<string> option = new IndexableOption<string>(DummyStringValue);

            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.Converters.Add(new IndexableOptionConverterNewtonsoft());

            // act
            string optionJson = Newtonsoft.Json.JsonConvert.SerializeObject(option, settings);
            string rawJson = Newtonsoft.Json.JsonConvert.SerializeObject(stringVal, settings);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        [Fact]
        public void SingleValue_WithSerializer_Factory_Added()
        {
            // arrange
            string stringVal = DummyStringValue;
            IndexableOption<string> option = new IndexableOption<string>(DummyStringValue);

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionConverterFactory());

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(stringVal, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        #endregion

        #region Multiple values

        private int[] DummyIntArray => new[] { 1, 2, 3, 9 };

        [Fact]
        public void MultipleValues_WithSerializer_Generic_Added()
        {
            // arrange
            int[] intVals = DummyIntArray;
            IndexableOption<int> option = new IndexableOption<int>(DummyIntArray);

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionConverterGeneric<int>());

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        [Fact]
        public void MultipleValues_WithSerializer_Newtonsoft_Added()
        {
            // arrange
            int[] intVals = DummyIntArray;
            IndexableOption<int> option = new IndexableOption<int>(DummyIntArray);

            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.Converters.Add(new IndexableOptionConverterNewtonsoft());

            // act
            string optionJson = Newtonsoft.Json.JsonConvert.SerializeObject(option, settings);
            string rawJson = Newtonsoft.Json.JsonConvert.SerializeObject(intVals, settings);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        [Fact]
        public void MultipleValues_WithSerializer_Factory_Added()
        {
            // arrange
            int[] intVals = DummyIntArray;
            IndexableOption<int> option = new IndexableOption<int>(DummyIntArray);

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionConverterFactory());

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        #endregion
    }
}
