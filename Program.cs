using DapperDatabase.ServerDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDatabase
{
    public class Program
    {
        private static void Main(string[] args)
        {
            LanguageManager.LoadFromFile("file.txt");
            LanguageManager.SaveToDatabase();
            Console.ReadLine();

        }
    }
}
