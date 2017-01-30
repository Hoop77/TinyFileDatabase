using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    class ParserException : Exception
    {
        public ParserException( string message, int lineNumber ) : base( "Parsing Error - Line " + lineNumber + ": " + message ) { }
    }
}
