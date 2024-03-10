using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.Security
{
    public class User
    {
        public string Username { get; set; } = null;
        public PassHash Password { get; set; } = null;
    }
}
