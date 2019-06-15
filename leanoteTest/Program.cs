using System;
using MySql.Data.MySqlClient;

namespace leanoteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MySqlConnection mysql = leanoteLibrary.DB.MySql.HyMySqlHelper.MySqlConnection;
            
        }
    }
}
