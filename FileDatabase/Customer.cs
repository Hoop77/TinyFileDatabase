using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ArrayList CartItems { get; set; }
    }
}
