using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Desired
{
    [System.Text.Json.Serialization.JsonConverter(typeof(StringEnumConverter))]
    // Newtonsoft serialization doesn't belong in "Desired" anymore but its output is still correct
    [Newtonsoft.Json.JsonConverter(typeof(Base.Newtonsoft.StringEnumConverter))]
    public abstract class StringEnum : Base.StringEnum
    {
        protected StringEnum(string stringRep) : base(stringRep) { }
    }
}
