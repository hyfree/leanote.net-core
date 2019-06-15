using System.Collections.Generic;
using leanoteLibrary.DB.MySql;
using leanoteLibrary.Entity;
using MySql.Data.MySqlClient;

namespace leanoteLibrary.Service
{
    public class ChapterService
    {

        public static int InsertChapter(ChapterEntity chapter)
        {
            if (chapter==null)
            {
                return 0;

            }
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            var sql = $"INSERT INTO chapter (ChapterId,ArticleId,Content,Summary,SerialNumber,Title,CreatTime) " +
                      $"VALUES ('{chapter.ChapterId}','{chapter.ArticleId}','{chapter.Content}','{chapter.Summary}','{chapter.SerialNumber}','{chapter.Title}','{chapter.CreatTime}')"; 
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }
        }
        public static List<ChapterEntity> SelectChapterByArticleId(string articleId)
        {
          
            var chapterList = new List<ChapterEntity>();
            var sql = $"select * from chapter where ArticleId='{articleId}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    chapterList.Add(MySqlRead2Chapter(reader));
                }
                return chapterList;
            }
        }
        public static List<ChapterEntity> SelectChapterByChapterId(string chapterId)
        {
          
            var chapterList = new List<ChapterEntity>();
            var sql = $"select * from chapter where ChapterId='{chapterId}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    chapterList.Add(MySqlRead2Chapter(reader));
                }
                return chapterList;
            }
        }
        public static List<ChapterEntity> SelectAllChapter(int minLimit,int maxLimit)
        {
          
            var chapterList = new List<ChapterEntity>();
            var sql = $"select * from chapter limit {minLimit},{maxLimit}";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    chapterList.Add(MySqlRead2Chapter(reader));
                }
                return chapterList;
            }
        }
        public static int UpdateChapterByChapterId(string chapterId, string title, string context,string summary,int serialNumber)
        {
            var sql = $"UPDATE chapter SET Title = '{title}',Content='{context}',Summary='{summary}',SerialNumber='{serialNumber}' WHERE ChapterId = '{chapterId}' ";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }
        public static int DeleteChapterByChapterId(string chapterId)
        {
            var sql = $"delete FROM chapter  WHERE ChapterId = '{chapterId}' ";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }
        public static int DeleteChapterByArticleId(string articleId)
        {
            var sql = $"delete FROM chapter  WHERE ArticleId = '{articleId}' ";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }
        private static ChapterEntity MySqlRead2Chapter(MySqlDataReader reader)
        {
            var chapter = new ChapterEntity
            {
                ChapterId=reader.GetString("ChapterId"),
                ArticleId=reader.GetString("ArticleId"),
                Content=reader.GetString("Content"),
                Summary=reader.GetString("Summary"),
                SerialNumber=reader.GetInt32("SerialNumber"),
                Title=reader.GetString("Title"),
                CreatTime=reader.GetDateTime("CreatTime")
            };
            return chapter;
        }
    }
}
