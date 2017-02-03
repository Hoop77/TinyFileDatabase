using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    class Program
    {
        static void Main( string[] args )
        {
            new Program().CreateDatabaseEntries();
        }

        private string ReadContent()
        {
            var fileReader = new StreamReader(@"Database.txt");

            var content = "";
            string line;
            while ((line = fileReader.ReadLine()) != null)
            {
                content += line + "\n";
            }

            return content;
        }

        private void CreateDatabaseEntries()
        {
            try
            {
                var entries = new Database().ReadEntries( ReadContent() );
                foreach (Entry entry in entries)
                {
                    Console.WriteLine("An entry \"" + entry.Name + "\"");

                    foreach (Attribute attribute in entry.Attributes)
                        Console.WriteLine("has Attribute \"" + attribute.Name + "\" with Value \"" + attribute.Value + "\"");

                    Console.WriteLine();
                }
            }
            catch (ParserException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    }
}
