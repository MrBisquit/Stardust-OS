using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.Security
{
    public class UserManager
    {
        // Env variables
        private string BaseUsersDir = "0:/Users/";
        private string BaseUserDir = "0:/Users/%Username%/";
        private string UserPassConfigFile = "0:/Users/%username%/pass.cfg";

        public User ActiveUser { get; private set; } = null;

        private string FillPathGaps(string path)
        {
            if(ActiveUser != null)
            {
                path.Replace("%Username%", ActiveUser.Username);
            }

            return path;
        }

        public void StartService()
        {
            if(!Directory.Exists(BaseUsersDir))
            {
                Directory.CreateDirectory(BaseUsersDir);
            }
        }

        public void Login(string username, string password)
        {
            
        }

        public void Logout()
        {

        }

        public bool CreateNewUser(string username, string password)
        {
            ActiveUser = new User();
            ActiveUser.Username = username;
            ActiveUser.Password.ForceUpdatePassword(password);
            if (Directory.Exists(FillPathGaps(BaseUserDir)))
            {
                return false;
            } else
            {
                Directory.CreateDirectory(FillPathGaps(BaseUserDir));
                ActiveUser.Password.ToFile(UserPassConfigFile);
                return true;
            }
        }
    }
}
