using Cosmos.HAL;
using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using StardustOS.SDSystem.Process;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.GraphicsEnv.AppSystem
{
    public class Window : Process.Process
    {

        internal Rectangle WindowR = Rectangle.Empty;
        internal Rectangle LastWindow;
        public string Title;
        public ControlList controls;
        public Bitmap AppView;
        internal Bitmap WindowBGView;
        public Color BackgroundColor;
        internal bool IsDragging = false;

        public Window(Rectangle window, string title, Color BackgroundColor)
        {

            this.BackgroundColor = BackgroundColor;
            WindowR = window;
            LastWindow = window;
            Title = title;
            WindowBGView = Bitmap.FromCanvasRegion(GUI.canvas, WindowR.X, WindowR.Y, (ushort)WindowR.Width, (ushort)WindowR.Height);
            AppView = Bitmap.MakeGradient(BackgroundColor,BackgroundColor, (uint)WindowR.Width, (uint)WindowR.Height - 25);
            controls = new(this);
            Draw();

        }
        Point DraggingOffset = Point.Empty;
        public override void Update()
        {
            base.Update();

            if (WindowR.IntersectsWith(GUI.Mouse))
            {
                if(MouseManager.MouseState == MouseState.Left && !IsDragging)
                {

                    DraggingOffset.X = GUI.Mouse.Location.X - WindowR.Location.X;
                    DraggingOffset.Y = GUI.Mouse.Location.Y - WindowR.Location.Y;
                    IsDragging = true;

                }
                else if (MouseManager.MouseState == MouseState.Left && IsDragging)
                {

                    WindowR.X = GUI.Mouse.X - DraggingOffset.X;
                    WindowR.Y = GUI.Mouse.Y - DraggingOffset.Y;

                }
                else if (MouseManager.MouseState != MouseState.Left && IsDragging)
                {
                    IsDragging = false;
                }

            }
            //Window.Location = GUI.Mouse.Location;

            if (LastWindow.Location != WindowR.Location || LastWindow.Size != WindowR.Size)
                if (!IsDragging) Draw();

        }

        public void Draw()
        {

            GUI.DrawMouseBuffer();
            GUI.canvas.DrawImage(WindowBGView, LastWindow.X, LastWindow.Y);
            WindowBGView = Bitmap.FromCanvasRegion(GUI.canvas, WindowR.X, WindowR.Y, (ushort)WindowR.Width, (ushort)WindowR.Height);
            GUI.canvas.DrawFilledRectangle(Color.FromArgb(20,20,20), WindowR.X, WindowR.Y, (ushort)WindowR.Width, 25);
            GUI.canvas.DrawString(Title,PCScreenFont.Default,Color.White, WindowR.X + +3, WindowR.Y +3);
            ViewDraw();
            GUI.GetMouseBuffer();
            GUI.DrawMouse();
            LastWindow.Location = WindowR.Location;
            LastWindow.Size = WindowR.Size;

        }
        public void ViewDraw()
        {
            GUI.canvas.DrawImage(AppView, WindowR.X, WindowR.Y + 25);
        }

    }
}
