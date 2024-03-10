using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System.Drawing;

namespace StardustOS.SDSystem.GraphicsEnv
{
    public static class GUI
    {

        public static Canvas canvas;
        static Point LMpos = Point.Empty;
        static Bitmap mouseBG;

        [ManifestResourceStream(ResourceName = "StardustOS.SDSystem.Resources.purple.bmp")]
        static byte[] PurpleBGRaw;
        static Bitmap PurpleBG;

        static int IconsX;
        static int IconsY;

        public static void Start(uint w,uint h)
        {

            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(w,h,ColorDepth.ColorDepth32));
            MouseManager.ScreenWidth = w;
            MouseManager.ScreenHeight = h;

            PurpleBG = new Bitmap(PurpleBGRaw);
            if (PurpleBG.Width != w || PurpleBG.Height != h)
            {
                PurpleBG.Resize(w,h);
            }
            canvas.DrawImage(PurpleBG,0,0);
            canvas.DrawFilledRectangle(Color.FromArgb(150,20,20,20),0,(int)h-40,(int)w,40);

            mouseBG = Bitmap.FromCanvasRegion(canvas, (int)MouseManager.X, (int)MouseManager.Y, 10, 15);
            LMpos.X = (int)MouseManager.X;
            LMpos.Y = (int)MouseManager.Y;
            canvas.DrawFilledRectangle(Color.White, (int)MouseManager.X, (int)MouseManager.Y, 10, 15);

            while (true)
            {
                Update();
            }

        }
        public static void Update()
        {

            if (LMpos.X != MouseManager.X || LMpos.Y != MouseManager.Y)
            {

                canvas.DrawImage(mouseBG,LMpos.X,LMpos.Y);
                mouseBG = Bitmap.FromCanvasRegion(canvas, (int)MouseManager.X, (int)MouseManager.Y,10,15);
                canvas.DrawFilledRectangle(Color.White, (int)MouseManager.X, (int)MouseManager.Y, 10, 15);
                LMpos.X = (int)MouseManager.X;
                LMpos.Y = (int)MouseManager.Y;

            }

            canvas.Display();

        }

    }
}
