using System.Collections.Generic;
using leanoteLibrary.DB.MySql;
using leanoteLibrary.Entity;
using MySql.Data.MySqlClient;

namespace leanoteLibrary.Service
{
    public class ArticleService
    {
        public  static int InsertArticle(ArticleEntity art)
        {
            if (art==null)
            {
                return 0;

            }
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            var sql = $"INSERT INTO article (ArticleId,Title,CreatUser,CreatTime,Author,score,ArticleType,status,Sources,Summary,Description,SEOTitle,SEOKeyWord,SEODescription,AllowComments,Topping,Recommend,Hot,TurnMap,RecType) " +
                      $"VALUES ('{art.ArticleId}', '{art.Title}','{art.CreatUser}','{art.CreatTime}'," +
                      $"'{art.Author}','{art.Score}','{art.ArticleType}','{art.Status}','{art.Sources}','{art.Summary}','{art.Description}','{art.SEOTitle}','{art.SEOKeyWord}','{art.SEODescription}','{art.AllowComments}','{art.Topping}','{art.Recommend}','{art.Hot}','{art.TurnMap}','{art.RecType}')"; 
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }
         public  static int UpdateArticleById(ArticleEntity article)
        {
            if (article==null)
            {
                return 0;

            }
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            //var sql = $"INSERT INTO article (ArticleId,Title,CreatUser,CreatTime,Author,score,ArticleType,status,Sources,Summary,Description,SEOTitle,SEOKeyWord,SEODescription,AllowComments,Topping,Recommend,Hot,TurnMap,RecType) " +
            //          $"VALUES ('{art.ArticleId}', '{art.Title}','{art.CreatUser}','{art.CreatTime}'," +
            //          $"'{art.Author}','{art.score}','{art.ArticleType}','{art.status}','{art.Sources}','{art.Summary}','{art.Description}','{art.SEOTitle}','{art.SEOKeyWord}','{art.SEODescription}','{art.AllowComments}','{art.Topping}','{art.Recommend}','{art.Hot}','{art.TurnMap}','{art.RecType}')"; 
            var sql=$"UPDATE article SET Title = '{article.Title}', CreatUser = '{article.CreatUser}',Author='{article.Author}',Score='{article.Score}',ArticleType='{article.ArticleType}',Status='{article.Status}',Sources='{article.Sources}',Summary='{article.Summary}'," +
                $"Description='{article.Description}',SEOTitle='{article.SEOTitle}',SEOKeyWord='{article.SEOKeyWord}',SEODescription='{article.SEODescription}',RecType='{article.RecType}'  WHERE ArticleId = '{article.ArticleId}'";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }
        public static List<ArticleEntity> FindArticleByTitle(string title)
        {

            var articleList = new List<ArticleEntity>();
            var sql = $"select * from article WHERE Title LIKE '%{title}%';";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    articleList.Add(MySqlRead2Article(reader));
                }
                return articleList;
            }
        }
        public static List<ArticleEntity> FindArticleByArticleId(string articleId)
        {

            var articleList = new List<ArticleEntity>();
            var sql = $"select * from article WHERE ArticleId ='{articleId}';";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    articleList.Add(MySqlRead2Article(reader));
                }
                return articleList;
            }
        }
        public static List<ArticleEntity> SelectAllArticle()
        {
          
            var articleList = new List<ArticleEntity>();
            var sql = $"select * from article";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    articleList.Add(MySqlRead2Article(reader));
                }
                return articleList;
            }
        }
        public static List<ArticleEntity> SelectAllArticle(int minLimit,int maxLimit)
        {
          
            var articleList = new List<ArticleEntity>();
            var sql = $"select * from article limit {minLimit},{maxLimit}";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    articleList.Add(MySqlRead2Article(reader));
                }
                return articleList;
            }
        }
        public static int DeleteChapterByArticleId(string articleId)
        {
            var sql = $"delete FROM article  WHERE ArticleId = '{articleId}' ";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                if (num > 0)
                {
                      num= ChapterService.DeleteChapterByArticleId(articleId);
                return num;

                }
                else
                {
                    return num;
                }
              
            }
        }
        private static ArticleEntity MySqlRead2Article(MySqlDataReader reader)
        {
            var ate = new ArticleEntity
            {
                ArticleId=reader.GetString("ArticleId"),
                Title=reader.GetString("Title"),
                CreatUser=reader.GetString("CreatUser"),
                CreatTime=reader.GetDateTime("CreatTime"),
                Author=reader.GetString("Author"),
                Score=reader.GetInt32("score"),
                ArticleType=reader.GetString("ArticleType"),
                Sources=reader.GetString("Sources"),
                Status=reader.GetString("status"),
                Summary=reader.GetString("Summary"),
                Description=reader.GetString("Description"),
                SEOTitle=reader.GetString("SEOTitle"),
                SEOKeyWord=reader.GetString("SEOKeyWord"),
                SEODescription=reader.GetString("SEODescription"),

                AllowComments=reader.GetBoolean("AllowComments"),
                Topping=reader.GetBoolean("Topping"),
                Recommend=reader.GetBoolean("Recommend"),
                Hot=reader.GetBoolean("Hot"),
                TurnMap=reader.GetBoolean("TurnMap"),
                RecType=reader.GetString("RecType")
            };
            return ate;
        }
    }
}
