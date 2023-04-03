﻿using System;
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
        public DatabaseHolder LoadDb() 
        {
            DatabaseHolder newDb;
            using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"/paswd.enc"))
            {
                string text = reader.ReadToEnd();
                newDb = JsonSerializer.Deserialize<DatabaseHolder>(text);
            }
            return newDb;
        }
        public void SaveDb()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(this, options);
            using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"/paswd.enc", false))
            {
                writer.WriteLineAsync(jsonString);
            }
        }
    }
}
