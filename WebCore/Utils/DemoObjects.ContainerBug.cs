using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Model;
using WebCore.Model.ContainerBug;
using WebCore.Model.Base;

namespace WebCore.Utils
{
    public static partial class DemoObjects
    {
        public static class ContainerBug
        {
            public static InnerContainer DummyInnerContainer => new InnerContainer<string>
            {
                Value = "StringValue"
            };

            public static OuterContainer DummyOuterContainer => new OuterContainer
            {
                Container = DummyInnerContainer
            };
        }
    }
}
