using System;
using System.Collections.Generic;
using System.Text;

namespace IndexableOptionTests.TestClasses
{
    class ConfigWithBase
    {
        public IndexableOptionWithBase<int> BorderWidth { get; set; }
        public IndexableOptionWithBase<string> BackgroundColor { get; set; }
    }
}
