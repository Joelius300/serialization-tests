using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphicSystemTextJsonTests.TestClasses.InnerOuterContainer
{
    public class OuterContainer
    {
        // use of non-generic class, actual type can of course be generic (derived class)
        public InnerContainer Container { get; set; }
    }
}
