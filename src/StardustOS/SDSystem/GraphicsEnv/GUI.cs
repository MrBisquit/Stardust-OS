using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using IL2CPU.API.Attribs;
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

            foreach (var file in Directory.GetFiles(@"0:\StarDust\Desktop"))
            {

                canvas.DrawImage(FileICN, 0 + (60 * IconsX), 0 + (78 * IconsY));
                canvas.DrawString(Path.GetFileNameWithoutExtension(file),PCScreenFont.Default,Color.White, 0 + (60 * IconsX), 60 + (78 * IconsY));

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
