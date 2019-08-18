using IndexableOptionTests.Converters;
using IndexableOptionTests.TestClasses;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace IndexableOptionTests
{
    public class IndexableOptioneWithBaseWrappedTest
    {
        [Fact]
        public void ConfigWithBase_NothingCustom()
        {
            // arrange
            string stringVal = "StringValue";
            int[] intVals = new[] { 7, 1, 5 };

            IndexableOptionWithBase<string> stringOption = new IndexableOptionWithBase<string>(stringVal);
            IndexableOptionWithBase<int> intOption = new IndexableOptionWithBase<int>(intVals);

            ConfigWithBase config = new ConfigWithBase
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
        public void ConfigWithBase_WithSerializer_Desired()
        {
            // arrange
            string stringVal = "StringValue";
            int[] intVals = new[] { 7, 1, 5 };

            IndexableOptionWithBase<string> stringOption = new IndexableOptionWithBase<string>(stringVal);
            IndexableOptionWithBase<int> intOption = new IndexableOptionWithBase<int>(intVals);

            ConfigWithBase config = new ConfigWithBase
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

        [Fact]
        public void ConfigWithBase_WithSerializer_BaseAdded()
        {
            // arrange
            string stringVal = "StringValue";
            int[] intVals = new[] { 7, 1, 5 };

            IndexableOptionWithBase<string> stringOption = new IndexableOptionWithBase<string>(stringVal);
            IndexableOptionWithBase<int> intOption = new IndexableOptionWithBase<int>(intVals);

            ConfigWithBase config = new ConfigWithBase
            {
                BackgroundColor = stringOption,
                BorderWidth = intOption
            };

            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new IndexableOptionBaseConverter());

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
