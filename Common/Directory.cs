using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
namespace Common
{
    /// <summary>
    /// 文件夹及文件操作类
    /// </summary>
    public class Directory
    {
        /// <summary>
        /// 获取文件件大小
        /// </summary>
        /// <param name="path">文件夹路径(Content/images)</param>
        /// <param name="unit">转换单位(M,KB,Byte)</param>
        /// <returns></returns>

        public static float DirectorySize(string path, string unit = "M")
        {
            float re = DirectorySize(HttpContext.Current.Server.MapPath("/" + path));
            if (unit.ToLower() == "m")
            {
                re = float.Parse((re / 1024 / 1024).ToString("#0.00"));
            }
            if (unit.ToLower() == "kb")
            {
                re = float.Parse((re / 1024).ToString("#0.00"));
            }
            return re;
        }
        private static float DirectorySize(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            float sumSize = 0;
            foreach (FileSystemInfo fsInfo in dirInfo.GetFileSystemInfos())
            {
                if (fsInfo.Attributes.ToString().ToLower() == "directory")
                {
                    sumSize += DirectorySize(fsInfo.FullName);
                }
                else
                {
                    FileInfo fiInfo = new FileInfo(fsInfo.FullName);
                    sumSize += fiInfo.Length;
                }
            }
            return sumSize;
        }
    }
}
