using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Base
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        public Desired.IndexableOption<string> FavouriteColors { get; set; }
        public Desired.IndexableOption<int> NumberOrNumbers { get; set; }
    }
}
