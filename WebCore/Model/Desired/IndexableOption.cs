using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Desired
{
    /// <summary>
    /// This class is only used for serialization. Do not use this class. Instead use <see cref="IndexableOption{T}"/>
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Base.Newtonsoft.IndexableOptionBaseConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(IndexableOptionBaseConverter))]    // not supported https://github.com/dotnet/corefx/issues/39905
    public abstract class IndexableOptionBase
    {
        public abstract object Value { get; }

    }

    /// <summary>
    /// Represents a field that can be either a single value or multiple values (array). This is used for typesafe js-interop.
    /// </summary>
    /// <typeparam name="T">The type of data this <see cref="IndexableOption{T}"/> is supposed to hold.</typeparam>
    public class IndexableOption<T> : IndexableOptionBase
    {
        public override object Value { get; }

        public IndexableOption(T singleValue) => Value = singleValue;
        public IndexableOption(T[] indexedValues) => Value = indexedValues;
    }
}
