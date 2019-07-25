using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebCore.Model
{
    public class Config
    {
        public Person Creator { get; set; }

        public SteppedLine SteppedLine { get; set; }
        public TickSource TickSource { get; set; }

        public Dictionary<SteppedLine, string> SteppedLinesValues { get; set; }
        public TickSource[] TickSources { get; set; }
    }
}
