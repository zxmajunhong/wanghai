using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[LoginUserLimit]������ݷ�����
    /// </summary>
    public class LoginUserLimitService
    {
        /// <summary>
        ///[LoginUserLimit]����ӵķ���
        /// </summary>
        public static int addLoginUserLimit(LoginUserLimit loginuserlimit)
        {
            string sql = "insert into LoginUserLimit([loginid],[nodeid]) values (@loginid,@nodeid)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@loginid",loginuserlimit.Loginid),
        new SqlParameter("@nodeid",loginuserlimit.Nodeid.Nodeid)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[LoginUserLimit]���޸ĵķ���
        /// </summary>
        public static int updateLoginUserLimitById(LoginUserLimit loginuserlimit)
        {

            string sql = "update LoginUserLimit set loginid=@loginid,nodeid=@nodeid where limitid=@limitid";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@limitid",loginuserlimit.Limitid),
        new SqlParameter("@loginid",loginuserlimit.Loginid),
        new SqlParameter("@nodeid",loginuserlimit.Nodeid.Nodeid)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[LoginUserLimit]��ɾ���ķ���
        /// </summary>
        public static int deleteLoginUserLimitById(int limitid)
        {

            string sql = "delete from LoginUserLimit where limitid=@limitid";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@limitid",limitid)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[LoginUserLimit]���ѯʵ��ķ���
        /// </summary>
        public static LoginUserLimit getLoginUserLimitById(int limitid)
        {
            LoginUserLimit loginuserlimit = null;

            string sql = "select * from LoginUserLimit where limitid=@limitid";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@limitid",limitid)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                loginuserlimit = new LoginUserLimit();
                foreach (DataRow dr in dt.Rows)
                {
                    loginuserlimit.Limitid = Convert.ToInt32(dr["limitid"]);
                    loginuserlimit.Loginid = Convert.ToString(dr["loginid"]);
                    loginuserlimit.Nodeid = MenuService.getMenuById((int)dr["nodeid"]);
                }
            }

            return loginuserlimit;
        }

        /// <summary>
        ///[LoginUserLimit]���ѯ���еķ���
        /// </summary>
        public static IList<LoginUserLimit> getLoginUserLimitAll()
        {
            string sql = "select * from LoginUserLimit";
            return getLoginUserLimitsBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<LoginUserLimit> getLoginUserLimitsBySql(string sql)
        {
            IList<LoginUserLimit> list = new List<LoginUserLimit>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LoginUserLimit loginuserlimit = new LoginUserLimit();
                    loginuserlimit.Limitid = Convert.ToInt32(dr["limitid"]);
                    loginuserlimit.Loginid = Convert.ToString(dr["loginid"]);
                    loginuserlimit.Nodeid = MenuService.getMenuById((int)dr["nodeid"]);
                    list.Add(loginuserlimit);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static LoginUserLimit getLoginUserLimitBySql(string sql)
        {
            LoginUserLimit loginuserlimit = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                loginuserlimit = new LoginUserLimit();
                foreach (DataRow dr in dt.Rows)
                {
                    loginuserlimit.Limitid = Convert.ToInt32(dr["limitid"]);
                    loginuserlimit.Loginid = Convert.ToString(dr["loginid"]);
                    loginuserlimit.Nodeid = MenuService.getMenuById((int)dr["nodeid"]);
                }
            }
            return loginuserlimit;
        }

        public static int GetLimitCount(int id)
        {
            string sql = "select count(*) from LoginUserLimit where loginid = " + id;
            return DBHelper.ExecuteScalar(sql);
        }
    }
}
