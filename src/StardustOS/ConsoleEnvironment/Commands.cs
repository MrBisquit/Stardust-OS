using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.ConsoleEnvironment
{
    public static class ConsoleCommands
    {

        public static Dictionary<string, Action<string[]>> Commands = new Dictionary<string, Action<string[]>>()
        {

            {"help",(args) => 
            {

                Console.WriteLine($"{OsInfo.OS_NAME} V{OsInfo.OS_VERSION}\r\n-----------------------------------\r\nhelp - show this list\r\nls - list directories and files\r\ncd - navigate to a directory\r\ncat - read a file\r\ned - edit or create a file\r\nmkdir - create a file");

            } }

        };

        public static string ErrorMessage = "Inavlid command";

        public static string StartupMessage = "Welcome to StardustOS";

    }
}
