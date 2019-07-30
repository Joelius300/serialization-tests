using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Base
{
    public class EnumsContainer
    {
    }

    public class EnumsContainer<TObjectEnum, TStringEnum> : EnumsContainer
        where TObjectEnum : ObjectEnum
        where TStringEnum : StringEnum
    {
        public TObjectEnum MyObjectEnumValue { get; set; }
        public TStringEnum MyStringEnumValue { get; set; }

        public TObjectEnum[] MyObjectEnumArray { get; set; }
        public TStringEnum[] MyStringEnumArray { get; set; }
    }
}
