using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace NUnitTests
{
    [ContextClass("Тестер", "TestRunner")]
    class TestRunner : AutoContext<TestRunner>
    {

        [ContextMethod("ПолучитьТестовыеСлучаи", "GetTestCases")]
        public IValue GetTestCases(IValue testObject, IValue fullObjectName)
        {
            return null;
        }
    }
}
