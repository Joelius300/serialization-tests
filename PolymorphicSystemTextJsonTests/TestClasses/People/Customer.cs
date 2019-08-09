using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphicSystemTextJsonTests.TestClasses.People
{
    class Customer : Person
    {
        public string Name { get; set; }
        public int CreditLimit { get; set; }
    }
}
