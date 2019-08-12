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
        public void Config_NothingCustom()
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

            // act
            string configJson = JsonSerializer.Serialize(config, serializerOptions);

            string rawStringJson = JsonSerializer.Serialize(stringVal, serializerOptions);
            string rawIntJson = JsonSerializer.Serialize(intVals, serializerOptions);

            // assert
            Assert.Contains(@$"""BackgroundColor"":{{""Value"":{rawStringJson}}}", configJson);
            Assert.Contains(@$"""BorderWidth"":{{""Value"":{rawIntJson}}}", configJson);
        }

        [Fact]
        public void Config_WithSerializer()
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
            // serializerOptions.Converters.Add(...);

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
