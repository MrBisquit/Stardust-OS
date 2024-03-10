using StardustOS.SDSystem.GraphicsEnv.AppSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.Applications
{
    public class Testapp :application
    {

        public Testapp() 
        {

            AppName = "TestApp";
            MaiAppHandle = new window(new(400, 200, 400, 400), AppName, System.Drawing.Color.White);

        }

    }
}
