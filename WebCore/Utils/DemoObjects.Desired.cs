using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Model.Base;
using WebCore.Model.Desired;

namespace WebCore.Utils
{
    public static partial class DemoObjects
    {
        public static class Desired
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
                    MyObjectEnum.ExampleString,
                    MyObjectEnum.False,
                    MyObjectEnum.Number(37)
                },
                MyStringEnumArray = new[]
                {
                    MyStringEnum.Low,
                    MyStringEnum.High,
                    MyStringEnum.Top
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
