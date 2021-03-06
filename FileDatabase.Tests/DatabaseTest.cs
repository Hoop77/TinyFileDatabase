// <copyright file="DatabaseTest.cs">Copyright ©  2017</copyright>
using System;
using System.Collections;
using FileDatabase;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileDatabase.Tests
{
    /// <summary>Diese Klasse enthält parametrisierte Komponententests für Database.</summary>
    [PexClass(typeof(Database))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DatabaseTest
    {
        /// <summary>Test-Stub für ReadEntries(String)</summary>
        [PexMethod(MaxRunsWithoutNewTests = 200)]
        [PexAllowedException(typeof(ArgumentNullException))]
        [PexAllowedException("FileDatabase", "FileDatabase.ParserException")]
        internal ArrayList ReadEntriesTest([PexAssumeUnderTest]Database target, string content)
        {
            ArrayList result = target.ReadEntriesFromString(content);
            return result;
            // TODO: Assertionen zu Methode DatabaseTest.ReadEntriesTest(Database, String) hinzufügen
        }
    }
}
