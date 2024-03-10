using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.AppSystem
{
    public class ControlList
    {

        internal List<Control> _controls;
        Window Window;

        public ControlList(Window window)
        {

            Window = window;
            _controls = new();

        }

        public Control this[int index]
        {
            get
            {
                // Retrieve the value at the specified index
                return _controls[index];
            }
            set
            {
                // Assign a value at the specified index
                _controls[index] = value;
            }
        }

        public void Add(Control control)
        {
            _controls.Add(control);
            Window.ViewDraw();
        }

    }
}
