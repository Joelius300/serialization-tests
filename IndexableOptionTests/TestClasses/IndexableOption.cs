using System;
using System.Collections.Generic;
using System.Text;

namespace IndexableOptionTests.TestClasses
{
    /// <summary>
    /// Represents a field that can be either a single value or multiple values (array). This is used for typesafe js-interop.
    /// </summary>
    /// <typeparam name="T">The type of data this <see cref="IndexableOption{T}"/> is supposed to hold.</typeparam>
    // [Newtonsoft.Json.JsonConverter(typeof(Converters.IndexableOptionConverterNewtonsoft))] <-- this works :)
    public sealed class IndexableOption<T>
    {
        public const string PropertyName = nameof(Value);

        public object Value { get; }

        public IndexableOption(T singleValue) => Value = singleValue;
        public IndexableOption(T[] indexedValues) => Value = indexedValues;
    }
}
