using System;
using System.Configuration;
namespace DbAccess
{
    public class PubConstant
    {        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionStringChatting
        {           
            get 
            {
                return GetConnectionString("ConnectionString");
            }
        }
        public static string ConnectionStringMarket
        {
            get
            {
                return GetConnectionString("ConnectionStringMarket");
            }
        }
        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[configName].ConnectionString.ToString();
            return connectionString;
        }
    }
}
