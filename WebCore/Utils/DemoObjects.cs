using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore;
using WebCore.Model;
using WebCore.Model.Base;

namespace WebCore.Utils
{
    public static partial class DemoObjects
    {
        public static Person DummyPerson => _dummyPerson.Value;
        private static readonly Lazy<Person> _dummyPerson = new Lazy<Person>(() => GetDummyPerson());

        public static SimplesContainer DummySimples => _dummySimples.Value;
        private static readonly Lazy<SimplesContainer> _dummySimples = new Lazy<SimplesContainer>(() => GetDummySimples());

        public static ArraysContainer DummyArrays => _dummyArrays.Value;
        private static readonly Lazy<ArraysContainer> _dummyArrays = new Lazy<ArraysContainer>(() => GetDummyArrays());


        private static Person GetDummyPerson() => new Person()
        {
            FirstName = "Tom",
            MiddleName = null,
            LastName = "Taylor",
            Gender = Gender.Male
        };

        private static SimplesContainer GetDummySimples() => 
            new SimplesContainer
            {
                MyInt = 1,
                MyString = "asdf",
                MyPoint = new Point
                {
                    X = 6,
                    Y = 9
                }
            };

        private static ArraysContainer GetDummyArrays() => 
            new ArraysContainer
            {
                MyIntArray = new[] { 1, 2, 3, 5, 8 },
                MyStringArray = new[] { "a", "b", "c", "d", "e" },
                MyPoints = new[]
                {
                    new Point
                    {
                        X = 9,
                        Y = 4
                    },
                    new Point
                    {
                        X = 99,
                        Y = 12345
                    }
                }
            };
    }
}
