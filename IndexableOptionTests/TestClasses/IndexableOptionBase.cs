using IndexableOptionTests.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace IndexableOptionTests.TestClasses
{
    /// <summary>
    /// Don't use this class, it's just for serialization. Use <see cref="IndexableOptionWithBase{T}"/> instead.
    /// </summary>
    [Obsolete("Don't use this class, it's just for serialization. Use IndexableOptionWithBase<T> instead.")]
    // [JsonConverter(typeof(IndexableOptionBaseConverter))]
    public abstract class IndexableOptionBase
    {
        public abstract object Value { get; }
    }
}
