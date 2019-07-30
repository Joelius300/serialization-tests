using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Desired
{
    public class MyStringEnum : StringEnum
    {
        public static MyStringEnum Low => new MyStringEnum("__low__");
        public static MyStringEnum High => new MyStringEnum("__high__");
        public static MyStringEnum Top => new MyStringEnum("__top__");

        private MyStringEnum(string value) : base(value) { }
    }
}
