using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace EtNet_BLL
{
    public class CodeMD5
    {
        /// <summary>
        /// 使用正常MD5加密
        /// </summary>
        /// <param name="s">待加密数据</param>
        /// <returns></returns>
        public static string GetMD5(string s)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5").ToUpper();
        }
        /// <summary>
        /// 与ASP兼容的MD5加密算法
        /// </summary>
        /// <param name="s">待加密数据</param> 
        /// <param name="_input_charset">编码</param>
        /// <returns></returns>
        public static string GetMD5(string s, string _input_charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }
    }
}
