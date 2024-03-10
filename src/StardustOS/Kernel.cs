using StardustOS.SDSystem.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace StardustOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs;

        public static UserManager UserManager;

        protected override void BeforeRun()
        {
            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            Console.WriteLine("Starting UserManager...");
            UserManager = new UserManager();
            //UserManager.StartService();
            Console.WriteLine("Started UserManager");

            if (!Directory.Exists(@"0:\StarDust\Desktop"))
            {
                Directory.CreateDirectory(@"0:\StarDust\Desktop");
                File.WriteAllText(@"0:\StarDust\Desktop\test.txt","test");
                File.WriteAllText(@"0:\StarDust\Desktop\hello.bas","10 print \"Hello\"");
                Directory.CreateDirectory(@"0:\StarDust\Desktop\testdir");
            }

            SDSystem.ConsoleEnvironment.console.Start();
        }

        protected override void Run()
        {
            SDSystem.ConsoleEnvironment.console.Update();
        }
    }
}
