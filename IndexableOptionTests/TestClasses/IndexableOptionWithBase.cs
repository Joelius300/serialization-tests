using System;
using System.Collections.Generic;
using System.Text;

namespace IndexableOptionTests.TestClasses
{
    /// <summary>
    /// Represents a field that can be either a single value or multiple values (array). This is used for typesafe js-interop.
    /// </summary>
    /// <typeparam name="T">The type of data this <see cref="IndexableOptionWithBase{T}"/> is supposed to hold.</typeparam>
#pragma warning disable 0618
    public class IndexableOptionWithBase<T> : IndexableOptionBase
#pragma warning restore 0618
    {
        public override object Value { get; }

        public IndexableOptionWithBase(T singleValue) => Value = singleValue;
        public IndexableOptionWithBase(T[] indexedValues) => Value = indexedValues;
    }
}
