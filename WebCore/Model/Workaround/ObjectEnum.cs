using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Workaround
{
    // Newtonsoft for correct output
    [global::Newtonsoft.Json.JsonConverter(typeof(Base.Newtonsoft.ObjectEnumConverter))]
    public abstract class ObjectEnum : Base.ObjectEnum
    {
        protected ObjectEnum(object value) : base(value) { }
    }
}
