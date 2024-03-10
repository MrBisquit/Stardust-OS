using StardustOS.SDSystem.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.AppSystem
{
    public class application : process
    {

        internal process MaiAppHandle;
        public string AppName = "Application";

        public application()
        {



        }

        public override void Update()
        {
            base.Update();
            MaiAppHandle.Update();
        }

    }
}
