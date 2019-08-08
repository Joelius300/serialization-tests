using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Workaround
{
    [System.Text.Json.Serialization.JsonConverter(typeof(StringEnumConverter<MyStringEnum>))]
    public class MyStringEnum : StringEnum
    {
        public static MyStringEnum Low => new MyStringEnum("##low##");
        public static MyStringEnum High => new MyStringEnum("##high##");
        public static MyStringEnum Top => new MyStringEnum("##top##");

        private MyStringEnum(string value) : base(value) { }
    }
}
