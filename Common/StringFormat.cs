using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class StringFormat
    {
        /// <summary>
        /// 判断一个字符串是否是整形
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsInteger(string source)
        {
            if (source == null || source == "")
            {
                return false;
            }

            if (Regex.IsMatch(source, "^((\\+)\\d)?\\d*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断一个数是否正整数(positive integer )
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPosiInteger(string str)
        {
            try
            {
                if (IsInteger(str))
                {
                    int i = int.Parse(str);
                    if (i > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str">要拆分的字符串</param>
        /// <param name="separator">切割符（如：','）</param>
        /// <returns></returns>
        public static string[] ReturenSplit(string str, char separator)
        {
            string[] stringList = new string[] { };
            if (str.IndexOf(",") != -1)
            {
                stringList = str.Split(separator);
            }
            return stringList;
        }
        public static string ReturenStringBySplit(string[] str, char separator)
        {
            string stringList = "";
            if (str.Length > 0)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    stringList += str[i] + separator;
                }
            }
            return stringList;
        }

        public static string ReturnRomeLastWord(string str, char separator)
        {
            string output = str;
            if (str.Length > 1)
            {
                int len = str.Length;
                if (str.LastIndexOf(separator) == len - 1)
                {
                    output = str.Substring(0, str.LastIndexOf(separator));
                }
            }
            return output;
        }

        public static Byte[] StringToByte(String s)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(s);
            return Encoding.UTF8.GetBytes(s);
        }
        public static String ByteToString(Byte[] b) 
        {
            return Encoding.UTF8.GetString(b);
        }
    }



}
