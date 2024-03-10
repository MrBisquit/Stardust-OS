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
    public class window : process
    {

        internal Rectangle Window = Rectangle.Empty;
        internal Rectangle LastWindow;
        public string Title;
        public ControlList controls;
        public Bitmap AppView;
        internal Bitmap WindowBGView;
        public Color BackgroundColor;
        internal bool IsDragging = false;

        public window(Rectangle window,string title,Color BackgroundColor)
        {

            this.BackgroundColor = BackgroundColor;
            Window = window;
            LastWindow = window;
            Title = title;
            WindowBGView = Bitmap.FromCanvasRegion(GUI.canvas, Window.X, Window.Y, (ushort)Window.Width, (ushort)Window.Height);
            AppView = Bitmap.MakeGradient(BackgroundColor,BackgroundColor, (uint)Window.Width, (uint)Window.Height - 25);
            controls = new(this);
            Draw();

        }
        Point DraggingOffset = Point.Empty;
        public override void Update()
        {
            base.Update();

            if (Window.IntersectsWith(GUI.Mouse))
            {
                if(MouseManager.MouseState == MouseState.Left && !IsDragging)
                {

                    DraggingOffset.X = GUI.Mouse.Location.X - Window.Location.X;
                    DraggingOffset.Y = GUI.Mouse.Location.Y - Window.Location.Y;
                    IsDragging = true;

                }
                else if (MouseManager.MouseState == MouseState.Left && IsDragging)
                {

                    Window.X = GUI.Mouse.X - DraggingOffset.X;
                    Window.Y = GUI.Mouse.Y - DraggingOffset.Y;

                }
                else if (MouseManager.MouseState != MouseState.Left && IsDragging)
                {
                    IsDragging = false;
                }

            }
            //Window.Location = GUI.Mouse.Location;

            if (LastWindow.Location != Window.Location || LastWindow.Size != Window.Size)
                if (!IsDragging) Draw();

        }

        public void Draw()
        {

            GUI.DrawMouseBuffer();
            GUI.canvas.DrawImage(WindowBGView, LastWindow.X, LastWindow.Y);
            WindowBGView = Bitmap.FromCanvasRegion(GUI.canvas, Window.X, Window.Y, (ushort)Window.Width, (ushort)Window.Height);
            GUI.canvas.DrawFilledRectangle(Color.FromArgb(20,20,20), Window.X, Window.Y, (ushort)Window.Width, 25);
            GUI.canvas.DrawString(Title,PCScreenFont.Default,Color.White, Window.X + +3, Window.Y +3);
            ViewDraw();
            GUI.GetMouseBuffer();
            GUI.DrawMouse();
            LastWindow.Location = Window.Location;
            LastWindow.Size = Window.Size;

        }
        public void ViewDraw()
        {
            GUI.canvas.DrawImage(AppView, Window.X, Window.Y + 25);
        }

    }
}
