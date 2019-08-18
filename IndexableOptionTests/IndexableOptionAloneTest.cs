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

        [Fact]
        public void IndexableOptionSingleValue_NothingCustom()
        {
            // arrange
            string stringVal = "StringValue";
            IndexableOption<string> option = new IndexableOption<string>(stringVal);
            var serializerOptions = new JsonSerializerOptions();

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(stringVal, serializerOptions);

            // assert
            Assert.Equal(@$"{{""Value"":{rawJson}}}", optionJson);
            Assert.NotEqual(rawJson, optionJson);
        }

        [Fact]
        public void IndexableOptionSingleValue_WithSerializer_Desired()
        {
            // arrange
            string stringVal = "StringValue";
            IndexableOption<string> option = new IndexableOption<string>(stringVal);

            var serializerOptions = new JsonSerializerOptions();
            // serializerOptions.Converters.Add(...);

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(stringVal, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        [Fact]
        public void IndexableOptionSingleValue_WithSerializer_GenericAdded()
        {
            // arrange
            string stringVal = "StringValue";
            IndexableOption<string> option = new IndexableOption<string>(stringVal);

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionConverterGeneric<string>());

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(stringVal, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        #endregion

        #region Multiple values

        [Fact]
        public void IndexableOptionMultipleValues_NothingCustom()
        {
            // arrange
            int[] intVals = new[] { 1, 2, 3, 9 };
            IndexableOption<int> option = new IndexableOption<int>(intVals);
            var serializerOptions = new JsonSerializerOptions();

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Equal(@$"{{""Value"":{rawJson}}}", optionJson);
            Assert.NotEqual(rawJson, optionJson);
        }

        [Fact]
        public void IndexableOptionMultipleValues_WithSerializer_Desired()
        {
            // arrange
            int[] intVals = new[] { 1, 2, 3, 9 };
            IndexableOption<int> option = new IndexableOption<int>(intVals);
            var serializerOptions = new JsonSerializerOptions();
            // serializerOptions.Converters.Add(...);

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        [Fact]
        public void IndexableOptionMultipleValues_WithSerializer_GenericAdded()
        {
            // arrange
            int[] intVals = new[] { 1, 2, 3, 9 };
            IndexableOption<int> option = new IndexableOption<int>(intVals);
            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionConverterGeneric<int>());

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        #endregion
    }
}
