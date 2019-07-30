using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.ContainerBug
{
    public class OuterContainer
    {
        public InnerContainer Container { get; set; }
    }
}
