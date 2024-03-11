using StardustOS.SDSystem.GraphicsEnv.AppSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.Controls
{
    public class Label : Control
    {

        public Point Location = Point.Empty;
        public string Text = "Label";
        public Color ForeColor = Color.White;

        public Label(Point location, string text) : base()
        {

            Location = location;
            Text = text;

        }

        public override void Draw()
        {
            base.Draw();
            ParentWindow.AppView._DrawACSIIString(ForeColor, Text, Location.X, Location.Y);

        }

    }
}
