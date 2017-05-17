using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class LoginInfoManager
    {
        public static int addLoginInfo(LoginInfo logininfo)
        {
            return LoginInfoService.addLoginInfo(logininfo);
        }

        public static int updateLoginInfo(LoginInfo logininfo)
        {
            return LoginInfoService.updateLoginInfoById(logininfo);
        }

        public static int deleteLoginInfo(int id)
        {
            return LoginInfoService.deleteLoginInfoById(id);
        }

        public static int deleteTo_PostById(int id)
        {
            return LoginInfoService.deleteTo_PostById(id);
        }
        public static LoginInfo getLoginInfoById(int id)
        {
            return LoginInfoService.getLoginInfoById(id);
        }

        public static IList<LoginInfo> getLoginInfoAll()
        {
            return LoginInfoService.getLoginInfoAll();
        }

        public static LoginInfo Login(string username, string password)
        {
            return LoginInfoService.Login(username, password);
        }

        public static System.Data.DataTable getList(string str)
        {
            return LoginInfoService.getList(str);
        }

        public static int getLoginNewId()
        {
            string sql = "select Max(id) as id from LoginInfo";
            return Convert.ToInt32(LoginInfoService.getLoginBySql(sql));
        }

        public static LoginInfo getLoginInfoByLoginID(string loginid)
        {
            return LoginInfoService.getLoginInfoByLoginID(loginid);
        }

        public static IList<LoginInfo> getLoginInfoByDeptId(int departid)
        {
            string sql = "select * from LoginInfo where DepartId=" + departid + "";
            return LoginInfoService.getLoginInfosBySql(sql);
        }

        /// <summary>
        /// 根据部门id集合得到对应人员
        /// </summary>
        /// <param name="departids"></param>
        /// <returns></returns>
        public static IList<LoginInfo> getLoginInfoBydepatids(string departids)
        {
            string sql = "select * from LoginInfo where DepartId in (" + departids + ")";
            return LoginInfoService.getLoginInfosBySql(sql);
        }
        public static int getLoginInfoByPostid(int postid)
        {
            return LoginInfoService.getLoginInfoByPostid(postid);

        }

        public static int getLoginIDByname(string name)
        {
            return LoginInfoService.getLoginIDByname(name);
        }
        public static int getTo_PostByPostname(string postname)
        {
            return LoginInfoService.getTo_PostByPostname(postname);

        }
        public static int getTo_PostByid(int id)
        {
            return LoginInfoService.getLoginInfoByPostid(id);

        }
    }
}
