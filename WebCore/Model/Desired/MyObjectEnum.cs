using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Desired
{
    public class MyObjectEnum : ObjectEnum
    {
        public static MyObjectEnum ExampleString => new MyObjectEnum("Example-desired");
        public static MyObjectEnum False => new MyObjectEnum(false);
        public static MyObjectEnum Number(int value) => new MyObjectEnum(value);

        private MyObjectEnum(bool value) : base(value) { }
        private MyObjectEnum(string value) : base(value) { }
        private MyObjectEnum(int value) : base(value) { }
    }
}
