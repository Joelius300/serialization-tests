using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Desired
{
        
    // Newtonsoft serialization doesn't belong in "Desired" anymore but its output is still correct
    [Newtonsoft.Json.JsonConverter(typeof(Base.Newtonsoft.ObjectEnumConverter))]
    public abstract class ObjectEnum : Base.ObjectEnum
    {
        protected ObjectEnum(object value) : base(value) { }
    }
}
