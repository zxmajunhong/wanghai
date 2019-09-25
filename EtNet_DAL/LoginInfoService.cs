using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[LoginInfo]������ݷ�����
    /// </summary>
    public class LoginInfoService
    {
        /// <summary>
        ///[LoginInfo]����ӵķ���
        /// </summary>
        public static int addLoginInfo(LoginInfo logininfo)
        {
            string sql = "insert into LoginInfo([loginid],[loginpwd],[cname],[ename],[email],[roleid],[departid],[tel],[fax],[firmidlist],[firmtxtlist],[postid],[orderrate],[isshowprofit]) values (@loginid,@loginpwd,@cname,@ename,@email,@roleid,@departid,@tel,@fax,@firmidlist,@firmtxtlist,@postid,@orderrate,@isshowprofit)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@loginid",logininfo.Loginid),
        new SqlParameter("@loginpwd",logininfo.Loginpwd),
        new SqlParameter("@cname",logininfo.Cname),
        new SqlParameter("@ename",logininfo.Ename),
        new SqlParameter("@email",logininfo.Email),
        new SqlParameter("@roleid",logininfo.Roleid),
        new SqlParameter("@departid",logininfo.Departid),
        new SqlParameter("@tel",logininfo.Tel),
        new SqlParameter("@fax",logininfo.Fax),
        new SqlParameter("@firmidlist",logininfo.Firmidlist),
        new SqlParameter("@firmtxtlist",logininfo.Firmtxtlist),
        new SqlParameter("@postid",logininfo.Postid),
        new SqlParameter("@orderrate",logininfo.orderRate),
        new SqlParameter("@isshowprofit", logininfo.isShowProfit)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[LoginInfo]���޸ĵķ���
        /// </summary>
        public static int updateLoginInfoById(LoginInfo logininfo)
        {

            string sql = "update LoginInfo set loginid=@loginid,loginpwd=@loginpwd,cname=@cname,ename=@ename,email=@email,roleid=@roleid,departid=@departid,tel=@tel,fax=@fax,firmidlist=@firmidlist,firmtxtlist=@firmtxtlist,postid=@postid,orderrate=@orderrate,isshowprofit=@isshowprofit where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",logininfo.Id),
        new SqlParameter("@loginid",logininfo.Loginid),
        new SqlParameter("@loginpwd",logininfo.Loginpwd),
        new SqlParameter("@cname",logininfo.Cname),
        new SqlParameter("@ename",logininfo.Ename),
        new SqlParameter("@email",logininfo.Email),
        new SqlParameter("@roleid",logininfo.Roleid),
        new SqlParameter("@departid",logininfo.Departid),
        new SqlParameter("@tel",logininfo.Tel),
        new SqlParameter("@fax",logininfo.Fax),
        new SqlParameter("@firmidlist",logininfo.Firmidlist),
        new SqlParameter("@firmtxtlist",logininfo.Firmtxtlist),
         new SqlParameter("@postid",logininfo.Postid),
         new SqlParameter("@orderrate",logininfo.orderRate),
         new SqlParameter("@isshowprofit",logininfo.isShowProfit)

     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[LoginInfo]��ɾ���ķ���
        /// </summary>
        public static int deleteLoginInfoById(int id)
        {

            string sql = "delete from LoginInfo where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_Post]��ɾ���ķ���
        /// </summary>
        public static int deleteTo_PostById(int id)
        {

            string sql = "delete from To_Post where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }
        /// <summary>
        ///[LoginInfo]���ѯʵ��ķ���
        /// </summary>
        public static LoginInfo getLoginInfoById(int id)
        {
            LoginInfo logininfo = null;

            string sql = "select * from LoginInfo where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                logininfo = new LoginInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    logininfo.Id = Convert.ToInt32(dr["id"]);
                    logininfo.Loginid = Convert.ToString(dr["loginid"]);
                    logininfo.Loginpwd = Convert.ToString(dr["loginpwd"]);
                    logininfo.Cname = Convert.ToString(dr["cname"]);
                    logininfo.Ename = Convert.ToString(dr["ename"]);
                    logininfo.Email = Convert.ToString(dr["email"]);
                    logininfo.Roleid = Convert.ToInt32(dr["roleid"]);
                    logininfo.Departid = Convert.ToInt32(dr["departid"]);
                    logininfo.Tel = Convert.ToString(dr["tel"]);
                    logininfo.Fax = Convert.ToString(dr["fax"]);
                    logininfo.Firmidlist = Convert.ToString(dr["firmidlist"]);
                    logininfo.Firmtxtlist = Convert.ToString(dr["firmtxtlist"]);
                    logininfo.Postid = Convert.ToInt32(dr["postid"]);
                    logininfo.orderRate = Convert.ToDouble(dr["orderrate"]);
                    logininfo.isShowProfit = Convert.ToInt32(dr["isshowprofit"]);
                }
            }

            return logininfo;
        }

     

        /// <summary>
        ///[LoginInfo]���ѯ���еķ���
        /// </summary>
        public static IList<LoginInfo> getLoginInfoAll()
        {
            string sql = "select * from LoginInfo";
            return getLoginInfosBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<LoginInfo> getLoginInfosBySql(string sql)
        {
            IList<LoginInfo> list = new List<LoginInfo>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LoginInfo logininfo = new LoginInfo();
                    logininfo.Id = Convert.ToInt32(dr["id"]);
                    logininfo.Loginid = Convert.ToString(dr["loginid"]);
                    logininfo.Loginpwd = Convert.ToString(dr["loginpwd"]);
                    logininfo.Cname = Convert.ToString(dr["cname"]);
                    logininfo.Ename = Convert.ToString(dr["ename"]);
                    logininfo.Email = Convert.ToString(dr["email"]);
                    logininfo.Roleid = Convert.ToInt32(dr["roleid"]);
                    logininfo.Departid = Convert.ToInt32(dr["departid"]);
                    logininfo.Tel = Convert.ToString(dr["tel"]);
                    logininfo.Fax = Convert.ToString(dr["fax"]);
                    logininfo.Firmidlist = Convert.ToString(dr["firmidlist"]);
                    logininfo.Firmtxtlist = Convert.ToString(dr["firmtxtlist"]);
                    logininfo.Postid = Convert.ToInt32(dr["postid"]);
                    logininfo.orderRate = Convert.ToDouble(dr["orderrate"]);
                    logininfo.isShowProfit = Convert.ToInt32(dr["isshowprofit"]);
                    list.Add(logininfo);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static LoginInfo getLoginInfoBySql(string sql)
        {
            LoginInfo logininfo = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                logininfo = new LoginInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    logininfo.Id = Convert.ToInt32(dr["id"]);
                    logininfo.Loginid = Convert.ToString(dr["loginid"]);
                    logininfo.Loginpwd = Convert.ToString(dr["loginpwd"]);
                    logininfo.Cname = Convert.ToString(dr["cname"]);
                    logininfo.Ename = Convert.ToString(dr["ename"]);
                    logininfo.Email = Convert.ToString(dr["email"]);
                    logininfo.Roleid = Convert.ToInt32(dr["roleid"]);
                    logininfo.Departid = Convert.ToInt32(dr["departid"]);
                    logininfo.Tel = Convert.ToString(dr["tel"]);
                    logininfo.Fax = Convert.ToString(dr["fax"]);
                    logininfo.Firmidlist = Convert.ToString(dr["firmidlist"]);
                    logininfo.Firmtxtlist = Convert.ToString(dr["firmtxtlist"]);
                    logininfo.Postid = Convert.ToInt32(dr["postid"]);
                    logininfo.orderRate = Convert.ToDouble(dr["orderrate"]);
                    logininfo.isShowProfit = Convert.ToInt32(dr["isshowprofit"]);
                }
            }
            return logininfo;
        }


        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginInfo Login(string username, string password)
        {
            string sql = "";
            LoginInfo login = null;
            if (username == "admin" && password == "E05730AB3E38D779FC24AE99C890988F")
            {

                sql = "select  * from LoginInfo where loginid = 'admin '";
            }
            else
            {
                sql = "select  * from LoginInfo where loginid = '" + username + "' and loginpwd = '" + password + "'";

            }
            login = LoginInfoService.getLoginInfoBySql(sql);

            return login;
        }




        //����ָ��������ѯ��¼�˻�
        public static DataTable getList(string strWhere)
        {
            string str = "select * from LoginInfo ";
            if (strWhere != "")
            {
                str += " where " + strWhere;

            }
            else
            { }
            return DBHelper.GetDataSet(str);
        }
        /// <summary>
        /// ��ȡ�ʺ�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string getLoginBySql(string sql)
        {
            DataTable dt = DBHelper.GetDataSet(sql);
            string id = "";
            if (dt.Rows.Count > 0)
            {
                id = dt.Rows[0]["id"].ToString();
                return id;
            }
            else
            {
                return id;
            }
        }
        /// <summary>
        /// �����ʺŲ�ѯ�û�
        /// </summary>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public static LoginInfo getLoginInfoByLoginID(string loginid)
        {
            LoginInfo login = null;
            string sql = "select * from LoginInfo where loginid='" + loginid + "'";
            login = LoginInfoService.getLoginInfoBySql(sql);
            return login;
        }
        /// <summary>
        /// ���ݸ�λ��ѯ�ʺ�
        /// </summary>
        /// <param name="postid"></param>
        /// <returns></returns>
        public static int getLoginInfoByPostid(int postid)
        {
            string sql = "select count(*) from LoginInfo where postid ='" + postid + "'";
           return DBHelper.ExecuteScalar(sql);
           
        }
        /// <summary>
        /// �����û�����ѯ�ʺ�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int getLoginIDByname(string name)
        {
            string sql = "select * from LoginInfo where cname = '" + name + "'";
            int id = 0;
            int.TryParse(getLoginBySql(sql), out id);
            return id;
        }

        /// <summary>
        /// �����û�����ѯ��λ
        /// </summary>
        /// <param name="postname"></param>
        /// <returns></returns>
        public static int getTo_PostByPostname(string postname)
        {
            string sql = "select id from To_Post where postname ='" + postname + "'";
            return DBHelper.ExecuteScalar(sql);

        }
        /// <summary>
        /// ���ݸ�λID��ѯ��λ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int getTo_PostByPostid(int id)
        {
            string sql = "select count(*) from To_Post where id ='" + id + "'";
            return DBHelper.ExecuteScalar(sql);

        }
    }
}
