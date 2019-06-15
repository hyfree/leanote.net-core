using leanoteLibrary.DB.MySql;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace leanoteLibrary.DB.MySql
{
    public static class HyMySqlHelper
    {

        private static HyMySqlConfig _mySqlConfig;
        private static MySqlConnection _mySqlConnection;
        /// <summary>
        /// 返回一个MySql链接
        /// </summary>
        public static MySqlConnection MySqlConnection
        {
            get
            {
                if (_mySqlConnection != null)
                {
                    return _mySqlConnection;
                }
                else
                {
                    if (_mySqlConfig == null)
                    {
                        InitConfig();
                    }
                    _mySqlConnection = new MySqlConnection(_mySqlConfig.ConnectStr);
                    _mySqlConnection.Open();
                    return _mySqlConnection;
                   
                }
            }
        }
        /// <summary>
        ///初始化数据库配置文件设置
        /// </summary>
        private static void InitConfig()
        {
            if (_mySqlConfig == null)
            {
                Console.WriteLine("初始化配置信息");
                _mySqlConfig = new HyMySqlConfig();
                string jsonString = File.ReadAllText("Config/mysql.json", Encoding.Default);

                JObject jsonObject = JObject.Parse(jsonString);
                _mySqlConfig.Server = jsonObject["server"].ToString();
                _mySqlConfig.Port = (string)jsonObject["port"];
                _mySqlConfig.User = (string)jsonObject["user"];
                _mySqlConfig.Password = (string)jsonObject["password"];
                _mySqlConfig.Database = (string)jsonObject["database"];
                _mySqlConfig.ConnectStr = $"server={ _mySqlConfig.Server};port={_mySqlConfig.Port};user={_mySqlConfig.User};password={_mySqlConfig.Password}; database={_mySqlConfig.Database};Allow User Variables=True;";

            }
        }
    }
}
