using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace PaswordManager
{
    [Serializable]
    public class DatabaseHolder
    {
        public List<List<string>> database { get; set; }
        public ListBox passwordsListBox;
        public DatabaseHolder()
        {
            passwordsListBox = new ListBox();
            database = new();
        }
        public DatabaseHolder LoadDb(string password) 
        {
            DatabaseHolder newDb;
            string paswordPath = Directory.GetCurrentDirectory() + "/" + MainWindow.PASSWORD_FILE_NAME;
            string ivPath = Directory.GetCurrentDirectory() + "/" + MainWindow.IV_FILE_NAME;
            using (StreamReader reader = new StreamReader(paswordPath))
            {
                string chipertext = reader.ReadToEnd();
            }
            string text = Cryptor.LoadEncrPasswords(paswordPath, ivPath, password);
            newDb = JsonSerializer.Deserialize<DatabaseHolder>(text);
            return newDb;
        }
        public void SaveDb(string password)
        {
            string paswordPath = Directory.GetCurrentDirectory() + "/" + MainWindow.PASSWORD_FILE_NAME;
            string ivPath = Directory.GetCurrentDirectory() + "/" + MainWindow.IV_FILE_NAME;
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(this, options);
            Cryptor.SaveEncrPaswords(paswordPath, ivPath, password, jsonString);
        }
    }
}
