using System;
using NUnit.Framework;

using OneScript.XMLSchema;

namespace NUnitTests
{
    [TestFixture]
    public class OScriptTestRunner
    {
        private TestRunnerWrapper host;

        [OneTimeSetUp]
        public void Initialize()
        {
            host = new TestRunnerWrapper();
        }

        [Test]
        public void TestXMLSchema() => host.RunTestFile(@"test-XMLSchema.os");

        [Test]
        public void TestXSImport() => host.RunTestFile(@"test-XSImport.os");

        [Test]
        public void TestXSInclude() => host.RunTestFile(@"test-XSInclude.os");

        //[Test]
        //public void TestXSDocumentation() => host.RunTestFile(@"test-XSDocumentation.os");
    }
}
