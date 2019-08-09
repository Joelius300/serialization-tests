using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphicSystemTextJsonTests.TestClasses.InnerOuterContainer
{
    // non-generic for generalization
    public abstract class InnerContainer
    {
        public int ContainerId { get; set; }
    }

    // generic for actual use
    public class InnerContainer<TValue> : InnerContainer
    {
        public TValue Value { get; set; }
    }


    // non-generic for generalization
    [System.Text.Json.Serialization.JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<InnerContainerWithAttribute>))]
    public abstract class InnerContainerWithAttribute
    {
        public int ContainerId { get; set; }
    }

    // generic for actual use
    public class InnerContainerWithAttribute<TValue> : InnerContainerWithAttribute
    {
        public TValue Value { get; set; }
    }
}
