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
        public static void SaveEncrPaswords(string Paswdpath, string IVpath, string paswd, string plaintext)
        {
            byte[] key = GetKey(paswd);
            using Aes aes = Aes.Create();
            File.WriteAllBytes(IVpath, aes.IV);
            WriteEncrDataToFile(plaintext, aes.IV, key, Paswdpath);
        }
        public static string LoadEncrPasswords(string Paswdpath, string IVpath, string paswd)
        {
            byte[] key = GetKey(paswd);
            byte [] iv =File.ReadAllBytes(IVpath);
            try
            {
                string plaintext = ReadEncrDataFromFile(Paswdpath, GetKey(paswd), iv);
                return plaintext;
            }
            catch (Exception ex)
            {
                throw new IncorrectPasswordExeption();
            }
        }
        static void WriteEncrDataToFile(string plaintext, byte [] iv, byte [] key, string filePath)
        {
            byte[] bytes = Encoding.Default.GetBytes(plaintext);
            string outputFileName = filePath; //файл, который будет содержать зашифрованные данные
            using Aes aes = Aes.Create();
            aes.IV = iv;
            aes.Key =key;
            using MemoryStream inStream = new MemoryStream(bytes); //создаем файловый поток на чтение
            using FileStream outStream = new FileStream(outputFileName, FileMode.Create);//создаем файловый поток на запись
            //поток для шифрования данных
            CryptoStream encStream = new CryptoStream(outStream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write);

            long readTotal = 0;

            int len;
            int tempSize = 100; //размер временного хранилища
            byte[] bin = new byte[tempSize];    //временное Хранилище для зашифрованной информации

            while (readTotal < inStream.Length)
            {
                len = inStream.Read(bin, 0, tempSize);
                encStream.Write(bin, 0, len);
                readTotal = readTotal + len;
            }
            encStream.Close();
            outStream.Close();
            inStream.Close();
        }
        static string ReadEncrDataFromFile(string sourceFile, byte [] key, byte[] iv)
        {
            using FileStream fileStream = new(sourceFile, FileMode.Open);
            using Aes aes = Aes.Create();
            aes.IV = iv;
            using CryptoStream cryptoStream = new(fileStream,
                                       aes.CreateDecryptor(key, iv),
                                                  CryptoStreamMode.Read); //создаем поток для чтения (расшифровки) данных
            using MemoryStream outStream = new MemoryStream();//создаем поток для расшифрованных данных

            using BinaryReader decryptReader = new(cryptoStream);
            int tempSize = 10;  //размер временного хранилища
            byte[] data;        //временное хранилище для зашифрованной информации
            while (true)
            {
                data = decryptReader.ReadBytes(tempSize);
                if (data.Length == 0)
                    break;
                outStream.Write(data, 0, data.Length);
            }
            return System.Text.Encoding.Default.GetString(outStream.ToArray());
        }
        static byte[] GetKey(string key)
        {
            using SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
        }
    }
}

