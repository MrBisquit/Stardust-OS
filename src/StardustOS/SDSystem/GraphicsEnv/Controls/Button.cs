using Cosmos.System;
using StardustOS.SDSystem.GraphicsEnv.AppSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.Controls
{
    public class Button : Control
    {

        public Action OnClick;
        public Rectangle ButtonRect = Rectangle.Empty;
        public string Text = "Button";
        public Color BackColor = Color.FromArgb(20,20,20);
        public Color ForeColor = Color.White;

        internal MouseState LastClickState = MouseState.None;

        public Button(Rectangle buttonrect,string text) : base()
        {

            ButtonRect = buttonrect;
            Text = text;

        }

        public override void Update()
        {
            base.Update();

            if (new Rectangle(ButtonRect.X + ParentWindow.WindowR.X, ButtonRect.Y + ParentWindow.WindowR.Y+25,ButtonRect.Width,ButtonRect.Height).IntersectsWith(GUI.Mouse))
            {

                if (MouseManager.MouseState == MouseState.Left && LastClickState == MouseState.None)
                {
                    LastClickState = MouseState.Left;
                }
                else if (MouseManager.MouseState == MouseState.None && LastClickState == MouseState.Left)
                {
                    OnClick.Invoke();
                    LastClickState = MouseState.None;
                }

            }

        }

        public override void Draw()
        {
            base.Draw();

            ParentWindow.AppView.DrawFilledRectangle(BackColor,ButtonRect.X, ButtonRect.Y, ButtonRect.Width, ButtonRect.Height);
            ParentWindow.AppView._DrawACSIIString(ForeColor,Text, ButtonRect.X, ButtonRect.Y);

        }

    }
}
