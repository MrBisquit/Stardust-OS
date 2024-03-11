using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.AppSystem
{
    public class Control
    {

        public Window ParentWindow;

        public Control() 
        {

        }

        public virtual void Start()
        {

            Draw();

        }

        public virtual void Update()
        { }
        public virtual void Draw()
        { }

    }
}
