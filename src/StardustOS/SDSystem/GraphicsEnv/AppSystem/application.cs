using StardustOS.SDSystem.Process;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.AppSystem
{
    public class Application : Process.Process
    {

        internal Process.Process MainAppHandle;
        public string AppName = "Application";

        public Rectangle WindowR = Rectangle.Empty;

        public Application()
        {



        }

        public override void Update()
        {
            base.Update();
            MainAppHandle.Update();
        }

    }
}
