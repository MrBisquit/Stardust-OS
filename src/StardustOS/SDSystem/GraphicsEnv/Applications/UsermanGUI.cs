using Cosmos.System.Graphics.Fonts;
using StardustOS.SDSystem.GraphicsEnv.AppSystem;
using StardustOS.SDSystem.GraphicsEnv.Controls;
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
            MainAppHandle = new Window(new(200, 200, 600, 400), AppName, Color.FromArgb(40, 40, 40)); ;

            (MainAppHandle as Window).controls.Add(new Label(Point.Empty,"Userman Login"));

            Button loginButton = new Button(new Rectangle(20, 20, 100, 50), "Login");
            loginButton.OnClick = () => 
            {

                Console.Beep();

            };
            (MainAppHandle as Window).controls.Add(loginButton);
            //File.WriteAllLines("0:/test.cfg", new string[] { "TEST=test" });

            /*if(ConfigMan.FetchConfig<string>("0:/test.cfg", true)["test"] == "test")
            {

            }*/
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
