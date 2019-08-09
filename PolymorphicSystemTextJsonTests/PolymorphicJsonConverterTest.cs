using PolymorphicSystemTextJsonTests.TestClasses.InnerOuterContainer;
using PolymorphicSystemTextJsonTests.TestClasses.People;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xunit;

namespace PolymorphicSystemTextJsonTests
{
    public class PolymorphicJsonConverterTest
    {
        #region InnerContainer

        [Fact]
        public void InnerContainerWithAttributes()
        {
            // arrange
            var options = new JsonSerializerOptions();
            InnerContainerWithAttribute inner = new InnerContainerWithAttribute<string>
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

        [Fact]
        public void InnerContainerAddedConverter()
        {
            // arrange
            InnerContainer inner = new InnerContainer<string>
            {
                ContainerId = 0,
                Value = "StringValue"
            };

            var options = new JsonSerializerOptions();
            options.Converters.Add(new PolymorphicWriteOnlyJsonConverter<InnerContainer>());

            // act
            string json = JsonSerializer.Serialize(inner, options);

            // assert
            Assert.Contains(@"""ContainerId"":0", json);
            Assert.Contains(@"""Value"":""StringValue""", json);
        }

        #endregion

        #region People

        [Fact]
        public void PeopleAddedConverter()
        {
            // arrange
            Person inner = new Customer
            {
                PersonId = 0,
                Name = "C",
                CreditLimit = 100
            };

            var options = new JsonSerializerOptions();
            options.Converters.Add(new PolymorphicWriteOnlyJsonConverter<Person>());

            // act
            string json = JsonSerializer.Serialize(inner, options);

            // assert
            Assert.Contains(@"""PersonId"":0", json);
            Assert.Contains(@"""CreditLimit"":100", json);
            Assert.Contains(@"""Name"":""C""", json);
        }

        #endregion
    }
}
