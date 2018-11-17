using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmIntegrationTests.IntegrationTesters
{
    interface IIntegrationTester
    {
        void RunTests();
        void RunTestByName(string name);
    }
}
