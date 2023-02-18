using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaswordManager
{
    internal static class Cryptor
    {
        public static Aes aes = Aes.Create();
        public static void CreateAES(string password)
        {
            aes.KeySize = 256;
            aes.Key=PasswordToHash(password);
            byte[] iv = { 33, 13, 43, 75, 221, 54, 65, 13, 67, 21, 32, 56, 78, 62, 84, 60 };
            aes.IV=iv;
        }
        public static byte[] PasswordToHash(string password)
        {
            byte[] pasb = Encoding.ASCII.GetBytes(password);
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(pasb, 0, pasb.Length - 1);
            return hash;
        }
    }

}
