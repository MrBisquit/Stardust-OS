﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.Process
{
    public class Process
    {

        public int ProcessID;
        public string ProcessName,ProcessDirectory;

        public virtual void Update()
        { }

    }
}
