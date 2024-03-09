using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace StardustOS
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            SDSystem.ConsoleEnvironment.console.Start();
        }

        protected override void Run()
        {
            SDSystem.ConsoleEnvironment.console.Update();
        }
    }
}
