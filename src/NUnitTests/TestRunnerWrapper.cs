using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTests
{
    public class TestRunnerWrapper
    {
        private const int TEST_STATE_FAILED = 3;

        private readonly EngineWrapperNUnit host;
        private readonly string solutionRoot;

        public void RunTestFile(string testFile)
        {
            var testRunnerPath = Path.Combine(solutionRoot, "tests", "testrunner.os");

            Assert.IsTrue(File.Exists(testRunnerPath),
                "Запускатель тестов отсутствует по пути " + testRunnerPath);

            var specificTestPath = Path.Combine(solutionRoot, "tests", testFile);
            var result = host.RunTestScriptFromPath(testRunnerPath, $"-run {specificTestPath}");

            if (result == TEST_STATE_FAILED)
            {
                Assert.Fail("Есть непройденные тесты!");
            }
        }

        public TestRunnerWrapper()
        {
            string rootFolder = Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", "..", "..");
            solutionRoot = Path.GetFullPath(rootFolder);

            string libPath = Path.Combine(solutionRoot, "opm");

            host = new EngineWrapperNUnit();
            host.StartEngine();
            host.Engine.InitExternalLibraries(libPath, null);             
        }

    }
}
