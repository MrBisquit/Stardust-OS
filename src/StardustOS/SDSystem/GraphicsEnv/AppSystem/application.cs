using StardustOS.SDSystem.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.AppSystem
{
    public class Application : Process.Process
    {

        internal Process.Process MaiAppHandle;
        public string AppName = "Application";

        public Application()
        {



        }

        public override void Update()
        {
            base.Update();
            MaiAppHandle.Update();
        }

    }
}
