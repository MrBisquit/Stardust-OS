using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.ConsoleEnvironment
{
    public static class console
    {

        public static string CurrentDirectory = @"0:\";

        public static void Start()
        {
            Console.Clear();
            Console.WriteLine(ConsoleCommands.StartupMessage);
        }

        public static void Update()
        {

            Console.Write(CurrentDirectory + " > ");
            string[] input = Console.ReadLine().Split(' ');

            if (ConsoleCommands.Commands.ContainsKey(input[0].ToLower()))
            {
                ConsoleCommands.Commands[input[0].ToLower()].Invoke(input);
            }
            else
            {
                Console.WriteLine(ConsoleCommands.ErrorMessage);
            }

        }

    }
}
