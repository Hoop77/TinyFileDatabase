// <copyright file="AnalyzerTest.cs">Copyright ©  2017</copyright>

using System;
using FileDatabase;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace FileDatabase.Tests
{
    /// <summary>Diese Klasse enthält parametrisierte Komponententests für Analyzer.</summary>
    [TestClass]
    [PexClass(typeof(Analyzer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AnalyzerTest
    {

        /// <summary>Test-Stub für AnalyzeCartItems()</summary>
        [PexMethod]
        public void AnalyzeCartItemsTest([PexAssumeUnderTest]Analyzer target)
        {
            target.AnalyzeCartItems();
        }
    }
}
