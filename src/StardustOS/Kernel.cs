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
            Console.Clear();
            SDSystem.ConsoleGraphics.SelectionMenu selectionMenu = new SDSystem.ConsoleGraphics.SelectionMenu("Stardust OS - What mode do you want to boot in?", new List<SDSystem.ConsoleGraphics.SelectionMenu.SelectionElement>());
            selectionMenu.selectionElements.Add(new SDSystem.ConsoleGraphics.SelectionMenu.SelectionElement("GUI mode (Default)"));
            selectionMenu.selectionElements.Add(new SDSystem.ConsoleGraphics.SelectionMenu.SelectionElement("CLI mode"));

            SDSystem.ConsoleGraphics.SelectionMenu.SelectionResult result = selectionMenu.RedrawWithResult();

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
