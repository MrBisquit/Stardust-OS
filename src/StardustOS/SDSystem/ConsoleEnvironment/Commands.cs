using Lynox.Additions.LUA;
using StardustOS.SDSystem.GraphicsEnv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.ConsoleEnvironment
{
    public static class ConsoleCommands
    {

        public static Dictionary<string, Action<string[]>> Commands = new Dictionary<string, Action<string[]>>()
        {

            {"help",(args) =>
            {

                Console.WriteLine($"{OsInfo.OS_NAME} V{OsInfo.OS_VERSION}\r\n-----------------------------------\r\nhelp - show this list\r\nls - list directories and files\r\ncd - navigate to a directory\r\ncat - read a file\r\ned - edit or create a file\r\nmkdir - create a file");
                Console.WriteLine("userman - Security User Manager\n    -nu <username> <password> - Creates a new user");
            }},
            {"basic",(args) =>
            {

                string code = "";
                if (args.Length == 2)
                {
                    code = File.ReadAllText(args[1]);
	            }
                else
                {
                    while (true)
                    {

                        string i = Console.ReadLine();
                        if (i == ":RUN")
                        {
                            break;
                        }
                        else
                        {
                            code += i + "\n";
                        }

                    }
                }
                Basic.Run(code);

            }},
            {"lua",(args) =>
            {

                string code = "";
                if (args.Length == 2)
                {
                    code = File.ReadAllText(args[1]);
                }
                else
                {
                    while (true)
                    {

                        string i = Console.ReadLine();
                        if (i == ":RUN")
                        {
                            break;
                        }
                        else
                        {
                            code += i + "\n";
                        }

                    }
                }
                LUA.Run(code);

            }},
            // Temp gui init
            {"gui",(args) =>
            {

                uint w = 1280,h = 720;
                if (args.Length == 3)
                {
                    w = (uint)int.Parse(args[1]);
                    h = (uint)int.Parse(args[2]);
	            }
                GUI.Start(w,h);

            }},
            {"userman",(args) =>
            {
                if(args.Length == 3)
                {
                    if(args[0] == "-nu")
                    {
                        Console.WriteLine("Creating a new user...");

                        Kernel.UserManager.CreateNewUser(args[1], args[2]);

                        Console.WriteLine("Created a new user...");
                    }
                }
            }},
        };

        public static string ErrorMessage = "Inavlid command";

        public static string StartupMessage = "Welcome to StardustOS";

    }
}
