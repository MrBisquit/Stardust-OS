using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace StardustOS
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
