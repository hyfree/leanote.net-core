using System.Collections.Generic;
using leanoteLibrary.DB.MySql;
using leanoteLibrary.Entity;
using MySql.Data.MySqlClient;

namespace leanoteLibrary.Service
{
    public class AuthorService
    {
        public static int AddAuthor(AuthorEntity author)
        {
            if (author==null)
            {
                return 0;

            }
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            var sql = $"INSERT INTO author (Id,Name,Description) " +
                      $"VALUES ('{author.Id}','{author.Name}','{author.Description}')"; 
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }
        }
        public static int DeleteAuthorById(string id)
        {
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
              var sql = $"delete FROM author  WHERE Id = '{id}' ";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }
        }
        public static List<AuthorEntity> SelectAuthorById(string id)
        {
              var AuthorList = new List<AuthorEntity>();
            var sql = $"select * from author where Id='{id}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    AuthorList.Add(MySqlRead2Author(reader));
                }
                return AuthorList;
            }
        }
        public static List<AuthorEntity> SelectAuthorByName(string name)
        {
              var AuthorList = new List<AuthorEntity>();
            var sql = $"select * from author where Name='{name}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    AuthorList.Add(MySqlRead2Author(reader));
                }
                return AuthorList;
            }
        }
        public static List<AuthorEntity> SelectAllAuthor()
        {
              var AuthorList = new List<AuthorEntity>();
            var sql = $"select * from author";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    AuthorList.Add(MySqlRead2Author(reader));
                }
                return AuthorList;
            }
        }
        public static int UpdataAuthor(AuthorEntity author)
        {    var sql = $"UPDATE author SET Name = '{author.Name}',Description='{author.Description}' WHERE Id = '{author.Id}' ";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }
        private static AuthorEntity MySqlRead2Author(MySqlDataReader reader)
        {
            var author = new AuthorEntity
            {
                    Id=reader.GetString("Id"),
                    Name=reader.GetString("Name"),
                    Description=reader.GetString("Description")
            };
            return author;
        }
    }
}
