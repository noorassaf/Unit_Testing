using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing.Test
{
    [TestClass]
    public class MyTestClass
    {
        [AssemblyInitialize]
        public static void myAssemblyInitialize(TestContext testContext)
        {
             testContext.WriteLine("AssemblyInitialize");
        }
        [AssemblyCleanup]
        public static void myAssemblyCleanup()
        {

        }
    }
}
