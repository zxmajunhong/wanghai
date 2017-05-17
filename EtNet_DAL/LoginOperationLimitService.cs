using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[LoginOperationLimit]������ݷ�����
    /// </summary>
    public class LoginOperationLimitService
    {
        /// <summary>
        ///[LoginOperationLimit]����ӵķ���
        /// </summary>
        public static int addLoginOperationLimit(LoginOperationLimit loginoperationlimit)
        {
            string sql = "insert into LoginOperationLimit([limitIds],[limitType],[limitremark]) values (@limitIds,@limitType,@limitremark)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@limitIds",loginoperationlimit.LimitIds),
        new SqlParameter("@limitType",loginoperationlimit.LimitType),
        new SqlParameter("@limitremark",loginoperationlimit.Limitremark)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[LoginOperationLimit]���޸ĵķ���
        /// </summary>
        public static int updateLoginOperationLimitById(LoginOperationLimit loginoperationlimit)
        {

            string sql = "update LoginOperationLimit set limitIds=@limitIds,limitType=@limitType,limitremark=@limitremark where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",loginoperationlimit.Id),
        new SqlParameter("@limitIds",loginoperationlimit.LimitIds),
        new SqlParameter("@limitType",loginoperationlimit.LimitType),
        new SqlParameter("@limitremark",loginoperationlimit.Limitremark)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[LoginOperationLimit]��ɾ���ķ���
        /// </summary>
        public static int deleteLoginOperationLimitById(int id)
        {

            string sql = "delete from LoginOperationLimit where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[LoginOperationLimit]���ѯʵ��ķ���
        /// </summary>
        public static LoginOperationLimit getLoginOperationLimitById(int id)
        {
            LoginOperationLimit loginoperationlimit = null;

            string sql = "select * from LoginOperationLimit where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                loginoperationlimit = new LoginOperationLimit();
                foreach (DataRow dr in dt.Rows)
                {
                    loginoperationlimit.Id = Convert.ToInt32(dr["id"]);
                    loginoperationlimit.LimitIds = Convert.ToString(dr["limitIds"]);
                    loginoperationlimit.LimitType = Convert.ToString(dr["limitType"]);
                    loginoperationlimit.Limitremark = Convert.ToString(dr["limitremark"]);
                }
            }

            return loginoperationlimit;
        }

        /// <summary>
        ///[LoginOperationLimit]���ѯ���еķ���
        /// </summary>
        public static IList<LoginOperationLimit> getLoginOperationLimitAll()
        {
            string sql = "select * from LoginOperationLimit";
            return getLoginOperationLimitsBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<LoginOperationLimit> getLoginOperationLimitsBySql(string sql)
        {
            IList<LoginOperationLimit> list = new List<LoginOperationLimit>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LoginOperationLimit loginoperationlimit = new LoginOperationLimit();
                    loginoperationlimit.Id = Convert.ToInt32(dr["id"]);
                    loginoperationlimit.LimitIds = Convert.ToString(dr["limitIds"]);
                    loginoperationlimit.LimitType = Convert.ToString(dr["limitType"]);
                    loginoperationlimit.Limitremark = Convert.ToString(dr["limitremark"]);
                    list.Add(loginoperationlimit);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static LoginOperationLimit getLoginOperationLimitBySql(string sql)
        {
            LoginOperationLimit loginoperationlimit = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                loginoperationlimit = new LoginOperationLimit();
                foreach (DataRow dr in dt.Rows)
                {
                    loginoperationlimit.Id = Convert.ToInt32(dr["id"]);
                    loginoperationlimit.LimitIds = Convert.ToString(dr["limitIds"]);
                    loginoperationlimit.LimitType = Convert.ToString(dr["limitType"]);
                    loginoperationlimit.Limitremark = Convert.ToString(dr["limitremark"]);
                }
            }
            return loginoperationlimit;
        }

        public static LoginOperationLimit getLoginOperationLimitByType(string type)
        {
            string sql = " select * from LoginOperationLimit where limitType = " + type;
            return getLoginOperationLimitBySql(sql);

        }
    }
}
