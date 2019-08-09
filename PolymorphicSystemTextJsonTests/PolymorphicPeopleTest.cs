using PolymorphicSystemTextJsonTests.TestClasses.People;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace PolymorphicSystemTextJsonTests
{
    public class PolymorphicPeopleTest
    {
        /* converter from 
         * https://github.com/dotnet/corefx/blob/fbb8b5c4b9566ba81596aa35f42b71bbda601528/src/System.Text.Json/tests/Serialization/CustomConverterTests.Polymorphic.cs#L160
         * from
         * https://github.com/dotnet/corefx/issues/39903
         */
        private class PersonPolymorphicSerializerConverter : JsonConverter<Person>
        {
            public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                throw new NotSupportedException($"Deserializing not supported. Type={typeToConvert}.");
            }

            public override void Write(Utf8JsonWriter writer, Person value, JsonSerializerOptions options)
            {
                JsonSerializer.Serialize(writer, value, value.GetType(), options);
            }
        }

        [Fact]
        public void PersonNonSupportedPolymorphicSingleValue()
        {
            // arrange
            var options = new JsonSerializerOptions();

            Customer customer = new Customer
            {
                PersonId = 0,
                Name = "C",
                CreditLimit = 100
            };

            Person person = customer;


            // act
            string json = JsonSerializer.Serialize(person, options);


            // assert
            Assert.Contains(@"""PersonId"":0", json);
            Assert.DoesNotContain(@"""CreditLimit"":100", json);
            Assert.DoesNotContain(@"""Name"":""C""", json);
        }

        [Fact]
        public void PersonNonSupportedPolymorphicArray()
        {
            // arrange
            var options = new JsonSerializerOptions();

            Customer customer = new Customer
            {
                PersonId = 0,
                Name = "C",
                CreditLimit = 100
            };

            Person[] people = new[] { customer };
            

            // act
            string arrayJson = JsonSerializer.Serialize(people, options);


            // assert
            Assert.Contains(@"""PersonId"":0", arrayJson);
            Assert.DoesNotContain(@"""CreditLimit"":100", arrayJson);
            Assert.DoesNotContain(@"""Name"":""C""", arrayJson);
        }

        [Fact]
        public void PersonCustomConverterPolymorphicSingleValue()
        {
            // arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new PersonPolymorphicSerializerConverter());

            Customer customer = new Customer
            {
                PersonId = 0,
                Name = "C",
                CreditLimit = 100
            };

            Person person = customer;


            // act
            string json = JsonSerializer.Serialize(person, person.GetType(), options);


            // assert
            Assert.Contains(@"""PersonId"":0", json);
            Assert.Contains(@"""CreditLimit"":100", json);
            Assert.Contains(@"""Name"":""C""", json);
            Assert.Throws<NotSupportedException>(() => JsonSerializer.Deserialize<Person>(json, options));
        }

        [Fact]
        public void PersonCustomConverterPolymorphicArray()
        {
            // arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new PersonPolymorphicSerializerConverter());

            Customer customer = new Customer
            {
                PersonId = 0,
                Name = "C",
                CreditLimit = 100
            };

            Person[] people = new[] { customer };


            // act
            string arrayJson = JsonSerializer.Serialize(people, options);


            // assert
            Assert.Contains(@"""PersonId"":0", arrayJson);
            Assert.Contains(@"""CreditLimit"":100", arrayJson);
            Assert.Contains(@"""Name"":""C""", arrayJson);
            Assert.Throws<NotSupportedException>(() => JsonSerializer.Deserialize<Person[]>(arrayJson, options));
        }
    }
}
