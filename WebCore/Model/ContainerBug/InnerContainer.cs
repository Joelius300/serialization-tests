using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.ContainerBug
{
        public abstract class InnerContainer
        {
            public int MyInt { get; set; } = 3;
        }

    public class InnerContainer<TValue> : InnerContainer
    {
        public TValue Value { get; set; }
    }
}
