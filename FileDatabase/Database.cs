using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    public class Database
    {
        private TextReader contentReader;
        private string line;
        private bool endOfFile;
        private int lineNumber;

        private ArrayList entries;

        public Database() {}

        public ArrayList ReadEntriesFromFile( string filename )
        {
            contentReader = new StreamReader( filename );

            return ReadEntries();
        }

        public ArrayList ReadEntriesFromString(string content)
        {
            contentReader = new StringReader(content);

            return ReadEntries();
        }

        private ArrayList ReadEntries()
        {
            entries = new ArrayList();
            endOfFile = false;
            lineNumber = 0;
            
            // read first line
            ReadLine();

            Entry entry = null;
            
            while( (entry = ParseNextEntry()) != null )
                entries.Add(entry);

            contentReader.Close();

            return entries;
        }

        private Entry ParseNextEntry()
        {
            string name = ParseEntryName();
            if( name == null )
                return null;
            
            return new Entry( name, ParseAttributes() );
        }

        private string ParseEntryName()
        {
            if( endOfFile )
                return null;

            var lineReader = new StringReader( line );

            if( lineReader.Read() != '[' )
                throw new ParserException( "The entry name must have the form [ENTRY_NAME]!", lineNumber );

            string entryName = ReadUntil( ']', lineReader );
            if( entryName == null )
                throw new ParserException( "The entry name must have the form [ENTRY_NAME]!", lineNumber );

            entryName = entryName.Trim();
            if( entryName.Equals( string.Empty ) )
                throw new ParserException( "The entry name must not be empty!", lineNumber );

            if( entryName.Contains( ' ' ) )
                throw new ParserException( "The entry name must not contain any whitespaces!", lineNumber );

            if( !ReadUntilLineEnd( lineReader ) )
                throw new ParserException( "The entry name must have the form [ENTRY_NAME]!", lineNumber );

            return entryName;
        }

        private ArrayList ParseAttributes()
        {
            var attributes = new ArrayList();
            
            while( ReadLine() && line[ 0 ] != '[' ) // stop if recognizing the start of an entry
            {
                var attribute = ParseAttribute();
                attributes.Add( attribute );
            }

            return attributes;
        }

        private Attribute ParseAttribute()
        {
            var lineReader = new StringReader( line );

            // get string until '='
            string name = ReadUntil( '=', lineReader );
            if( name == null )
                throw new ParserException( "The attribute name must have the form: ATTRIBUTE_NAME = \"ATTRIBUTE_VALUE\"", lineNumber );

            // ignore whitespaces before '='
            name = name.TrimEnd();

            // the name must not contain any whitespaces
            if( name.Contains( ' ' ) )
                throw new ParserException( "The attribute name must not contain any whitespaces!", lineNumber );

            // get string inbetween '=' and first quotes
            string untilFirstQuotes = ReadUntil( '"', lineReader );
            if( untilFirstQuotes == null )
                throw new ParserException( "The attribute value must be between quotation marks!", lineNumber );

            // string inbetween '=' and first quotes must only be whitespaces or empty
            if( !untilFirstQuotes.TrimStart().Equals( string.Empty ) )
                throw new ParserException( "The attribute name must have the form: ATTRIBUTE_NAME = \"ATTRIBUTE_VALUE\"", lineNumber );

            // get the value inbetween the quotes
            string value = ReadUntil( '"', lineReader );
            if( value == null )
                throw new ParserException( "The attribute value must be between quotation marks!", lineNumber );

            // the rest (after second quotes) must be either null or empty
            if( !ReadUntilLineEnd( lineReader ) )
                throw new ParserException( "The attribute name must have the form: ATTRIBUTE_NAME = \"ATTRIBUTE_VALUE\"", lineNumber );

            return new Attribute( name, value );
        }

        /// <summary>
        /// Reads the next line from the file and ignores empty lines.
        /// </summary>
        /// <returns>
        /// false if end of file reaches
        /// </returns>
        private bool ReadLine()
        {
            do
            {
                line = contentReader.ReadLine();
                if( line == null )
                {
                    endOfFile = true;
                    return false;
                }

                line = line.Trim(); // Fix

                lineNumber++;
            }
            while( line.Equals( string.Empty ) );
            
            // Error!
            //line = line.Trim();
            
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// true if the rest of the line is empty or only whitespaces.
        /// </returns>
        private bool ReadUntilLineEnd( StringReader reader )
        {
            string rest = reader.ReadToEnd();
            if( rest == null || rest.Trim().Equals( string.Empty ) )
                return true;

            return false;
        }

        /// <summary>
        /// Reads reader until character occurs.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="reader"></param>
        /// <returns>
        /// The string read excluding character or null if character hasn' been read.
        /// </returns>
        private string ReadUntil( int character, StringReader reader )
        {
            string result = string.Empty;
            int c;

            while( true )
            {
                c = reader.Read();
                if( c == -1 )
                    return null;

                if( c == character )
                    break;

                result += Convert.ToChar( c );
            }

            return result;
        }
    }
}
