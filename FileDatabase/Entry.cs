using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    class Entry
    {
        public string Name { get; set; }
        public ArrayList Attributes { get; set; }

        public Entry( string name, ArrayList attributes )
        {
            Name = name;
            Attributes = attributes;
        }
    }
}
