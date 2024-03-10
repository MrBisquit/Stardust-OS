using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace StardustOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs;

        protected override void BeforeRun()
        {
            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            SDSystem.ConsoleEnvironment.console.Start();
        }

        protected override void Run()
        {
            SDSystem.ConsoleEnvironment.console.Update();
        }
    }
}
