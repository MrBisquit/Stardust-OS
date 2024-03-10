using Cosmos.System.Graphics.Fonts;
using StardustOS.SDSystem.GraphicsEnv.AppSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            MainAppHandle = new Window(new(200, 200, 600, 400), AppName, Color.White);

            //File.WriteAllLines("0:/test.cfg", new string[] { "TEST=test" });

            /*if(ConfigMan.FetchConfig<string>("0:/test.cfg", true)["test"] == "test")
            {

            }*/
        }

        public override void Update()
        {
            base.Update();

            GUI.canvas.DrawString("F", PCScreenFont.Default, Color.White, WindowR.X + +3, WindowR.Y + 3);
        }
    }
}
