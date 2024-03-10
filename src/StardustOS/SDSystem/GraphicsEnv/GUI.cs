using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using IL2CPU.API.Attribs;
using StardustOS.SDSystem.GraphicsEnv.Applications;
using StardustOS.SDSystem.GraphicsEnv.AppSystem;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

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

        [ManifestResourceStream(ResourceName = "StardustOS.SDSystem.Resources.file.bmp")]
        static byte[] FileRaw;
        static Bitmap FileICN;

        [ManifestResourceStream(ResourceName = "StardustOS.SDSystem.Resources.folder.bmp")]
        static byte[] FolderRaw;
        static Bitmap FolderICN;

        static int IconsX;
        static int IconsY;

        public static List<application> applications = new List<application>();

        public static Rectangle Mouse = Rectangle.Empty;

        public static void Start(uint w,uint h)
        {

            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(w,h,ColorDepth.ColorDepth32));
            MouseManager.ScreenWidth = w;
            MouseManager.ScreenHeight = h;

            PurpleBG = new Bitmap(PurpleBGRaw);
            FileICN = new Bitmap(FileRaw);
            FolderICN = new Bitmap(FolderRaw);
            if (PurpleBG.Width != w || PurpleBG.Height != h)
            {
                PurpleBG.Resize(w,h);
            }
            canvas.DrawImage(PurpleBG,0,0);

            int YICNMax = (int)((78 / h) - 1);

            foreach (var file in Directory.GetFiles(@"0:\StarDust\Desktop"))
            {

                canvas.DrawImage(FileICN, 0 + (60 * IconsX), 0 + (78 * IconsY));
                canvas.DrawString(Path.GetExtension(file),PCScreenFont.Default,Color.Black, 9 + (60 * IconsX), 35 + (78 * IconsY));
                canvas.DrawString(Path.GetFileNameWithoutExtension(file),PCScreenFont.Default,Color.White, 0 + (60 * IconsX), 60 + (78 * IconsY));

                if (IconsY == YICNMax)
                {
                    IconsY = 0;
                    IconsX++;
                }
                else
                {
                    IconsY++;
                }

            }
            foreach (var file in Directory.GetDirectories(@"0:\StarDust\Desktop"))
            {

                canvas.DrawImage(FolderICN, 0 + (60 * IconsX), 0 + (78 * IconsY));
                canvas.DrawString(Path.GetFileNameWithoutExtension(file), PCScreenFont.Default, Color.White, 0 + (60 * IconsX), 60 + (78 * IconsY));

                if (IconsY == 8)
                {
                    IconsY = 0;
                    IconsX++;
                }
                else
                {
                    IconsY++;
                }

            }

            canvas.DrawFilledRectangle(Color.FromArgb(150,20,20,20),0,(int)h-40,(int)w,40);

            mouseBG = Bitmap.FromCanvasRegion(canvas, (int)MouseManager.X, (int)MouseManager.Y, 10, 15);
            LMpos.X = (int)MouseManager.X;
            LMpos.Y = (int)MouseManager.Y;
            Mouse.Width = 10;
            Mouse.Height = 15;
            canvas.DrawFilledRectangle(Color.White, (int)MouseManager.X, (int)MouseManager.Y, 10, 15);

            //test
            applications.Add(new Testapp());

            while (true)
            {
                Update();
            }

        }
        public static void Update()
        {

            Mouse.X = (int)MouseManager.X;
            Mouse.Y = (int)MouseManager.Y;

            foreach (var app in applications)
            {
                app.Update();
            }

            if (LMpos.X != MouseManager.X || LMpos.Y != MouseManager.Y)
            {

                DrawMouseBuffer();
                GetMouseBuffer();
                DrawMouse();
                LMpos.X = (int)MouseManager.X;
                LMpos.Y = (int)MouseManager.Y;

            }

            canvas.Display();

        }

        public static void DrawMouseBuffer()
        {
            canvas.DrawImage(mouseBG, LMpos.X, LMpos.Y);
        }

        public static void DrawMouse()
        {
            canvas.DrawFilledRectangle(Color.White, (int)MouseManager.X, (int)MouseManager.Y, 10, 15);
        }

        public static void GetMouseBuffer()
        {
            mouseBG = Bitmap.FromCanvasRegion(canvas, (int)MouseManager.X, (int)MouseManager.Y, 10, 15);
        }

    }
}
