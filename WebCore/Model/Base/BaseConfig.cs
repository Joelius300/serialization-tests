using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Model.Base
{
    public class BaseConfig
    {
        public Person MyPerson { get; set; }

        public SimplesContainer Simples { get; set; }
        public ArraysContainer Arrays { get; set; }

        // BUG: It doesn't use the actual type of the object but the empty EnumsContainer class
        // This doesn't happen if you serialize an EnumConverter directly..
        // if you don't tell it what type-params it has it still serializes it correctly if it isnt part of another class like it is here.
        public EnumsContainer Enums { get; set; }
    }
}
