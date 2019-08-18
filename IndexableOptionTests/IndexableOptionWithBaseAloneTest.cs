using IndexableOptionTests.Converters;
using IndexableOptionTests.TestClasses;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace IndexableOptionTests
{
    public class IndexableOptionWithBaseAloneTest
    {
        #region Single value

        [Fact]
        public void IndexableOptionWithBaseSingleValue_NothingCustom()
        {
            // arrange
            string stringVal = "StringValue";
            IndexableOptionWithBase<string> option = new IndexableOptionWithBase<string>(stringVal);
            var serializerOptions = new JsonSerializerOptions();

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(stringVal, serializerOptions);

            // assert
            Assert.Equal(@$"{{""Value"":{rawJson}}}", optionJson);
            Assert.NotEqual(rawJson, optionJson);
        }

        [Fact]
        public void IndexableOptionWithBaseSingleValue_WithSerializer_Desired()
        {
            // arrange
            string stringVal = "StringValue";
            IndexableOptionWithBase<string> option = new IndexableOptionWithBase<string>(stringVal);

            var serializerOptions = new JsonSerializerOptions();
            // serializerOptions.Converters.Add(...);

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(stringVal, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        [Fact]
        public void IndexableOptionWithBaseSingleValue_WithSerializer_BaseAdded()
        {
            // arrange
            string stringVal = "StringValue";
            IndexableOptionWithBase<string> option = new IndexableOptionWithBase<string>(stringVal);

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionBaseConverter());

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(stringVal, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        #endregion

        #region Multiple values

        [Fact]
        public void IndexableOptionWithBaseMultipleValues_NothingCustom()
        {
            // arrange
            int[] intVals = new[] { 1, 2, 3, 9 };
            IndexableOptionWithBase<int> option = new IndexableOptionWithBase<int>(intVals);
            var serializerOptions = new JsonSerializerOptions();

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Equal(@$"{{""Value"":{rawJson}}}", optionJson);
            Assert.NotEqual(rawJson, optionJson);
        }

        [Fact]
        public void IndexableOptionWithBaseMultipleValues_WithSerializer_Desired()
        {
            // arrange
            int[] intVals = new[] { 1, 2, 3, 9 };
            IndexableOptionWithBase<int> option = new IndexableOptionWithBase<int>(intVals);
            var serializerOptions = new JsonSerializerOptions();
            // serializerOptions.Converters.Add(...);

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        [Fact]
        public void IndexableOptionWithBaseMultipleValues_WithSerializer_BaseAdded()
        {
            // arrange
            int[] intVals = new[] { 1, 2, 3, 9 };
            IndexableOptionWithBase<int> option = new IndexableOptionWithBase<int>(intVals);
            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionBaseConverter());

            // act
            string optionJson = JsonSerializer.Serialize(option, serializerOptions);
            string rawJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Equal(rawJson, optionJson);
        }

        #endregion
    }
}
