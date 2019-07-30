using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Workaround
{
    // Newtonsoft for correct output
    [global::Newtonsoft.Json.JsonConverter(typeof(Base.Newtonsoft.StringEnumConverter))]
    public abstract class StringEnum : Base.StringEnum
    {
        protected StringEnum(string stringRep) : base(stringRep) { }
    }
}
