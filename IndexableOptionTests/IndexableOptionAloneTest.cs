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
        public void IndexableOptionSingleValue_WithSerializer()
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
        public void IndexableOptionMultipleValues_WithSerializer()
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

        #endregion
    }
}
