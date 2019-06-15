using System.Collections.Generic;
using leanoteLibrary.DB.MySql;
using leanoteLibrary.Entity;
using MySql.Data.MySqlClient;

namespace leanoteLibrary.Service
{
    public class UserService
    {
        /// <summary>
        /// 向数据库中插入用户
        /// </summary>
        /// <param name="userEntity">用户</param>
        /// <returns>返回是否成功 1成功,其他均为失败</returns>
        public  static int AddUser(UserEntity userEntity)
        {
            if (userEntity==null)
            {
                return 0;

            }
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            var sql = $"INSERT INTO user (userid,password,username,email,age,mygroup,intro, address,token) VALUES ('{userEntity.Userid}', '{userEntity.PassWord}','{userEntity.UserName}','{userEntity.Email}'," +
                      $"{userEntity.Age},'{userEntity.Group}','{userEntity.Intro}','{userEntity.Address}','{userEntity.Token}')"; 
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }
//        删除用户
//        查询用户
        /// <summary>
        /// 通过用户ID查询用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public static List<UserEntity> SelectUserByUserId(string userId)
        {
            if (userId==null)
            {
                return null;
            }
            var userList = new List<UserEntity>();
           

            var sql = $"select * from user where userid='{userId}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    userList.Add(MySqlRead2User(reader));
                }
                return userList;
            }
        }
        public static List<UserEntity> SelectUserByUserEmail(string email)
        {
            if (email==null)
            {
                return null;
            }
            var userList = new List<UserEntity>();
            var sql = $"select * from user where email='{email}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                    userList.Add(MySqlRead2User(reader));
                }
                return userList;
            }
        }
        public static List<UserEntity> SelectUserByUserName(string name)
        {
            if (name==null)
            {
                return null;
            }
            var userList = new List<UserEntity>();
            var sql = $"select * from user where username='{name}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                   
                    userList.Add(MySqlRead2User(reader));
                }
                return userList;
            }
        }
        /// <summary>
        /// 选取若干用户
        /// </summary>
        /// <param name="minLimit">从第几个位置</param>
        /// <param name="maxLimit">一共选取多少</param>
        /// <returns></returns>
        public static List<UserEntity> SelectAllUser(int  minLimit,int maxLimit)
        {
            
            var userList = new List<UserEntity>();
            var sql = $"select * from user limit {minLimit},{maxLimit}";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    // Console.WriteLine(reader.GetInt32("userid") + reader.GetString("username") + reader.GetString("password"));//"userid"是数据库对应的列名，推荐这种方式
                   
                    userList.Add(MySqlRead2User(reader));
                }
                return userList;
            }
        }
        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="token">用户授权密钥</param>
        /// <returns></returns>
        public static int ActivateUser(string userid,string token)
        {
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            var sql = $"UPDATE user SET activity = '1' WHERE userid = '{userid}' AND token='{token}' ";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }
        public enum SqlGroup
        {
            root,admin,user
        }
        public static int EditGroup(string email,SqlGroup userGroup)
        {
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            var sql = $"UPDATE user SET mygroup = '{userGroup.ToString()}' WHERE email = '{email}'";
            using (var cmd = new MySqlCommand(sql, HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }

        private static UserEntity MySqlRead2User(MySqlDataReader reader)
        {
            var entity = new UserEntity
            {
                Userid = reader.GetString("userid"),
                PassWord = reader.GetString("password"),
                UserName = reader.GetString("username"),
                Email = reader.GetString("email"),
                Age = reader.GetInt32("age"),
                Group = reader.GetString("mygroup"),
                Intro = reader.GetString("intro"),
                Token=reader.GetString("token"),
                Telephone=reader.GetString("telephone"),
                QQ=reader.GetString("qq"),
                Twitter=reader.GetString("twitter"),
                Avatar=reader.GetString("avatar"),
                Rank=reader.GetInt32("rank"),
                Credit=reader.GetInt32("credit"),
                Gb = reader.GetInt32("gb"),
                
                
            };
            return entity;
        }

        public static int ChangeUserDataByUserId(string userid,string newName,string newEmail,string newPassword,string newPhone,string newQQ,string newTwitter,string newIntro)
        {
            //INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')
            var sql = $"UPDATE user SET username = '{newName}',email='{newEmail}',password='{newPassword}',telephone='{newPhone}',qq='{newQQ}',twitter='{newTwitter}',intro='{newIntro}' WHERE userid = '{userid}' ";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }
        }

        public static int ChangeAvatar(string newAvatar,string userid)
        {
            var sql = $"UPDATE user SET avatar = '{newAvatar}' WHERE userid = '{userid}'";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }
        public static int ChangeGb(string userid,int gb,bool add)
        {

            string operationalCharacter  = string.Empty;
            if (add)
            {
                operationalCharacter  = "+";

            }
            else
            {
                operationalCharacter  = "-";
            }
            //update user set property=property-1 where username='test';
           
            var sql = $"UPDATE user SET gb =gb {operationalCharacter } {gb} WHERE userid = '{userid}'";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }

            public static int ChangeTokenByEmail(string email,string token)
        {
            var sql = $"UPDATE user SET token = '{token}' WHERE email = '{email}'";
            using (var cmd=new MySqlCommand(sql,HyMySqlHelper.MySqlConnection))
            {
                var num = cmd.ExecuteNonQuery();
                return num;
            }

        }

    }
}
