﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IndexableOptionTests.TestClasses
{
    /// <summary>
    /// Represents a field that can be either a single value or multiple values (array). This is used for typesafe js-interop.
    /// </summary>
    /// <typeparam name="T">The type of data this <see cref="IndexableOption{T}"/> is supposed to hold.</typeparam>
    public class IndexableOption<T>
    {
        public object Value { get; }

        public IndexableOption(T singleValue) => Value = singleValue;
        public IndexableOption(T[] indexedValues) => Value = indexedValues;
    }
}