using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.Process
{
    public class Process
    {
        public int x, y;
        public Process process;

        public event EventHandler<UpdateEventArgs> Update;
        
        public class UpdateEventArgs
        {
            public int x, y;
            public Process process;
        }
    }
}
