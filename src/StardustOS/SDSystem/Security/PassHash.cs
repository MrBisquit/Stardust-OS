using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StardustOS.SDSystem.Security
{
    public class PassHash
    {
        private byte[] salt;
        private byte[] hash;
        public void FromFile(string Path)
        {
            if(File.Exists(Path))
            {
                string[] FileContent = File.ReadAllText(Path).Split('\n');
                for (int i = 0; i < FileContent.Length; i++)
                {
                    string[] Split = FileContent[i].Split("=");
                    if (Split.Length != 2) return;
                    
                    switch (Split[0])
                    {
                        case "SALT":
                            salt = Encoding.Default.GetBytes(Split[1]);
                            break;
                        case "HASH":
                            hash = Encoding.Default.GetBytes(Split[1]);
                            break;
                    }
                }
            }
        }

        public void ToFile(string Path)
        {
            string FileContent = $"SALT={salt}\nHASH={hash}";
            File.WriteAllText(Path, FileContent);
        }

        public bool ChangePassword(string OldPassword, string NewPassword, string ConfirmPassword) => _ChangePassword(OldPassword, NewPassword, ConfirmPassword);

        private bool _ChangePassword(string OP, string NP, string CP)
        {
            if (NP != CP) return false;

            if(!CompareHashes(Encoding.Default.GetString(hash), HashPassword(OP, salt)))
            {
                return false;
            }

            ForceUpdatePassword(NP);

            return true;
        }

        public void ForceUpdatePassword(string NP)
        {
            hash = HashPassword(NP, salt);
        }

        private static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);
                return salt;
            }
        }

        private static byte[] HashPassword(string password, byte[] salt)
        {
            const int iterations = 10000; // Adjust as needed
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return pbkdf2.GetBytes(32); // 32 bytes = 256 bits
            }
        }
        private static bool CompareHashes(string storedHash, byte[] userHash)
        {
            // Compare the byte arrays (constant-time comparison)
            return storedHash == Convert.ToBase64String(userHash);
        }
    }
}
