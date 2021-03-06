using FileDatabase;
using System;
using Microsoft.Pex.Framework;

namespace FileDatabase
{
    /// <summary>A factory for FileDatabase.Database instances</summary>
    public static partial class DatabaseFactory
    {
        /// <summary>A factory for FileDatabase.Database instances</summary>
        [PexFactoryMethod("FileDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FileDatabase.Database")]
        public static Database Create()
        {
            Database database = new Database();
            return database;

            // TODO: Edit factory method of Database
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
