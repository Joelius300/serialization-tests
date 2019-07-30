using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Model.Base;
using WebCore.Model.Workaround;

namespace WebCore.Utils
{
    public static partial class DemoObjects
    {
        public static class Workaround
        {
            public static EnumsContainer DummyEnums => _dummyEnums.Value;
            private static readonly Lazy<EnumsContainer> _dummyEnums =
                new Lazy<EnumsContainer>(() => GetDummyEnums());

            public static BaseConfig DummyBaseConfig => _dummyBaseConfig.Value;
            private static readonly Lazy<BaseConfig> _dummyBaseConfig =
                new Lazy<BaseConfig>(() => GetDummyBaseConfig());

            private static EnumsContainer GetDummyEnums() =>
            new EnumsContainer<MyObjectEnum, MyStringEnum>
            {
                MyObjectEnumValue = MyObjectEnum.ExampleString,
                MyStringEnumValue = MyStringEnum.Low,
                MyObjectEnumArray = new[]
                {
                    MyObjectEnum.True,
                    MyObjectEnum.ExampleString,
                    MyObjectEnum.Number(12.345)
                },
                MyStringEnumArray = new[]
                {
                    MyStringEnum.Top,
                    MyStringEnum.High,
                    MyStringEnum.Low
                }
            };

            private static BaseConfig GetDummyBaseConfig() =>
            new BaseConfig()
            {
                Simples = DummySimples,
                Arrays = DummyArrays,
                Enums = DummyEnums,
                MyPerson = DummyPerson
            };
        }
    }
}
