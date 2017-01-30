using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    class Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Attribute( string name, string value )
        {
            Name = name;
            Value = value;
        }
    }
}
