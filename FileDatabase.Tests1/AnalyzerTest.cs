// <copyright file="AnalyzerTest.cs">Copyright ©  2017</copyright>
using System;
using FileDatabase;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileDatabase.Tests
{
    /// <summary>Diese Klasse enthält parametrisierte Komponententests für Analyzer.</summary>
    [PexClass(typeof(Analyzer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AnalyzerTest
    {
        /// <summary>Test-Stub für AnalyzeCartItems(ICustomerDAO)</summary>
        [PexMethod]
        public void AnalyzeCartItemsTest([PexAssumeUnderTest]Analyzer target, ICustomerDAO customerDAO)
        {
            target.AnalyzeCartItems(customerDAO);
            // TODO: Assertionen zu Methode AnalyzerTest.AnalyzeCartItemsTest(Analyzer, ICustomerDAO) hinzufügen
        }
    }
}
