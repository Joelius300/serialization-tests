using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Model;

namespace WebCore.Utils
{
    public static class DemoObjects
    {
        public static Config DummyConfig => new Config()
        {
            Creator = DummyPerson,
            SteppedLine = SteppedLine.False,
            TickSource = TickSource.Labels,
            SteppedLinesValues = new Dictionary<SteppedLine, string>
            {
                { SteppedLine.Before,   "__before__" },
                { SteppedLine.After,    "__after__" },
                { SteppedLine.Middle,   "__middle__" },
                { SteppedLine.True,     "__true__" },
                { SteppedLine.False,    "__false__" }
            },
            TickSources = new TickSource[0]
        };

        public static Person DummyPerson => new Person()
        {
            FirstName = "Tom",
            MiddleName = null,
            LastName = "Taylor",
            Gender = Gender.Male
        };
    }
}
