using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaswordManager
{
    internal static class Cryptor
    {
        public static byte[] Encrypt(string textToEncrypt, string password)
        {
            byte[] plaintext = Encoding.Unicode.GetBytes(textToEncrypt);
            Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.Key = PasswordToHash(password);
            byte[] iv = { 33, 13, 43, 75, 221, 54, 65, 13, 67, 21, 32, 56, 78, 62, 84, 60 };
            byte[] chipertext = aes.EncryptCbc(plaintext, iv, PaddingMode.PKCS7);
            return chipertext;
        }
        public static string Decrypt(byte[] chipertext, string password)
        {
            Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.Key = PasswordToHash(password);
            byte[] iv = { 33, 13, 43, 75, 221, 54, 65, 13, 67, 21, 32, 56, 78, 62, 84, 60 };
            string plaintext = Encoding.Unicode.GetString(aes.DecryptCbc(chipertext, iv, PaddingMode.PKCS7));
            return plaintext;
        }
        public static byte[] PasswordToHash(string password)
        {
            byte[] pasb = Encoding.Unicode.GetBytes(password);
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(pasb, 0, pasb.Length - 1);
            return hash;
        }
    }

}
