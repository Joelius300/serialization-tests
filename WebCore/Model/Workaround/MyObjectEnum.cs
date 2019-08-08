using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Workaround
{
    [System.Text.Json.Serialization.JsonConverter(typeof(ObjectEnumConverter<MyObjectEnum>))]
    public class MyObjectEnum : ObjectEnum
    {
        public static MyObjectEnum ExampleString => new MyObjectEnum("Example-workaround");
        public static MyObjectEnum True => new MyObjectEnum(true);
        public static MyObjectEnum Number(double value) => new MyObjectEnum(value);

        private MyObjectEnum(bool value) : base(value) { }
        private MyObjectEnum(string value) : base(value) { }
        private MyObjectEnum(double value) : base(value) { }
    }
}
