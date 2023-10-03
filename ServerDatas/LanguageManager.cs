using Dapper;
using DapperDatabase.ServerDatas.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDatabase.ServerDatas
{
    public static class LanguageManager 
    {
        private const string TABLE_NAME = "Inter_Language";
        private static List<LanguageInfo> languages = new List<LanguageInfo>();
        public static List<LanguageInfo> Languages 
        {
            get {  return languages; }
            set { languages = value; }
        }

        public static void LoadFromFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] splits = line.Split(':');
                    languages.Add(new LanguageInfo() { MessageName = splits[0], VietnamMsg = splits[1] });
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void SaveToDatabase()
        {
            using (ServerDapper db = new ServerDapper()) 
            {
                foreach (LanguageInfo info in languages)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@MessageName", info.MessageName);
                    parameters.Add("@vi", info.VietnamMsg);

                    db.Data.Query<LanguageInfo>($"INSERT INTO {TABLE_NAME} (MessageName, vi) VALUES (@MessageName, @vi)", parameters);
                    Console.WriteLine($"MessageName: {info.MessageName} - Vietnam: {info.VietnamMsg}");
                }
            }
        }
    }
}
