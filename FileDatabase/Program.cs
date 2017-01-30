using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    class Program
    {
        static void Main( string[] args )
        {
            var database = new Database();
            try
            {
                var entries = database.ReadEntries( @"database.txt" );
                foreach( Entry entry in entries )
                {
                    Console.WriteLine( "An entry \"" + entry.Name + "\"" );

                    foreach( Attribute attribute in entry.Attributes )
                        Console.WriteLine( "has Attribute \"" + attribute.Name + "\" with Value \"" + attribute.Value + "\"" );

                    Console.WriteLine();
                }
            }
            catch( ParserException e )
            {
                Console.WriteLine( e.Message );
            }

            Console.Read();
        }
    }
}
