using StardustOS.SDSystem.GraphicsEnv.AppSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.Applications
{
    public class UsermanGUI : Application
    {
        public UsermanGUI()
        {
            AppName = "Userman GUI";
            MaiAppHandle = new Window(new(200, 200, 600, 400), AppName, System.Drawing.Color.White);
        }

        public override void Update()
        {
            
        }
    }
}
