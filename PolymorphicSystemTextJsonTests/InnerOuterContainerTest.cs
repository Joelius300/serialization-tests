using PolymorphicSystemTextJsonTests.TestClasses.InnerOuterContainer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace PolymorphicSystemTextJsonTests
{
    public class InnerOuterContainerTest
    {
        #region Non supported


        // for https://github.com/dotnet/corefx/issues/39903#issuecomment-519714998
        [Fact]
        public void InnerContainerNonSupportedPolymorphic()
        {
            // arrange
            var options = new JsonSerializerOptions();

            InnerContainer inner = new InnerContainer<string>
            {
                ContainerId = 0,
                Value = "StringValue"
            };

            // act
            string json = JsonSerializer.Serialize(inner, options);

            // assert
            Assert.Contains(@"""ContainerId"":0", json);
            Assert.DoesNotContain(@"""Value"":""StringValue""", json);
        }

        // for https://github.com/dotnet/corefx/issues/39903#issuecomment-519714998
        [Fact]
        public void InnerContainerPolymorphic_DeclaredObject()
        {
            // arrange
            var options = new JsonSerializerOptions();

            InnerContainer inner = new InnerContainer<string>
            {
                ContainerId = 0,
                Value = "StringValue"
            };

            object objectInner = inner;

            // act
            string jsonExplicit = JsonSerializer.Serialize(inner, inner.GetType(), options);
            string jsonViaObject = JsonSerializer.Serialize(objectInner, /*typeof(object),*/ options);

            // assert
            Assert.Equal(jsonExplicit, jsonViaObject);
        }

        #endregion

        #region Dedicated converter

        private class InnerContainerPolymorphicSerializerConverter : JsonConverter<InnerContainer>
        {
            public override InnerContainer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                throw new NotSupportedException($"Deserializing not supported. Type={typeToConvert}.");
            }

            public override void Write(Utf8JsonWriter writer, InnerContainer value, JsonSerializerOptions options)
            {
                JsonSerializer.Serialize(writer, value, value.GetType(), options);
            }
        }

        [Fact]
        public void InnerContainerCustomConverterPolymorphic()
        {
            // arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new InnerContainerPolymorphicSerializerConverter());

            InnerContainer inner = new InnerContainer<string>
            {
                ContainerId = 0,
                Value = "StringValue"
            };

            // act
            string json = JsonSerializer.Serialize(inner, options);

            // assert
            Assert.Contains(@"""ContainerId"":0", json);
            Assert.Contains(@"""Value"":""StringValue""", json);
        }

        #endregion
    }
}
