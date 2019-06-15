using System.Collections.Generic;
using leanoteLibrary.DB.MySql;
using leanoteLibrary.Entity;
using MySql.Data.MySqlClient;

namespace leanoteLibrary.Service
{
    public class PayManager
    {
        public static int BuyChapter(PayEntity payEntity)
        {
            if (payEntity==null)
            {
                return 0;

            }
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            var sql = $"INSERT INTO pay (Id,UserId,Type,Chapter,PayTime,Money) " +
                      $"VALUES ('{payEntity.Id}','{payEntity.UserId}','{payEntity.Type}','{payEntity.Chapter}','{payEntity.PayTime}','{payEntity.Money}')"; 
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }
        }

        public static bool CheckPurchase(string chapterId, string userid)
        {
            var list = SelectPayByUserId(userid,chapterId);
            if (list.Count==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        public static List<PayEntity> SelectPayByPayId(string payId)
        {
          
            var payList = new List<PayEntity>();
            var sql = $"select * from pay where Id='{payId}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    payList.Add(MySqlRead2Pay(reader));
                }
                return payList;
            }
        }
        public static List<PayEntity> SelectPayByUserId(string userid)
        {
          
            var payList = new List<PayEntity>();
            var sql = $"select * from pay where UserId='{userid}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    payList.Add(MySqlRead2Pay(reader));
                }
                return payList;
            }
        }
        public static List<PayEntity> SelectPayByUserId(string userid,string chapterid)
        {
          
            var payList = new List<PayEntity>();
            var sql = $"select * from pay where UserId='{userid}' and Chapter='{chapterid}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    payList.Add(MySqlRead2Pay(reader));
                }
                return payList;
            }

        }
        public static List<PayEntity> SelectAllChapter(int minLimit,int maxLimit)
        {
          
            var payList = new List<PayEntity>();
            var sql = $"select * from pay limit {minLimit},{maxLimit}";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    payList.Add(MySqlRead2Pay(reader));
                }
                return payList;
            }
        }
        private static PayEntity MySqlRead2Pay(MySqlDataReader reader)
        {
            var entity = new PayEntity
            {
               Id  =reader.GetString("Id"),
               UserId = reader.GetString("UserId"),
               Type = reader.GetString("Type"),
               Chapter = reader.GetString("Chapter"),
               PayTime = reader.GetDateTime("PayTime") ,
               Money = reader.GetInt32("Money")
            };
            return entity;
        }
    }
}
