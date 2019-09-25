using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using System.Data;
using System.Data.SqlClient;

namespace EtNet_DAL
{
    public class LoginDataLimitServices
    {
        public static string GetLimit(int loginID)
        {
            string sql = string.Format("select loginID,dataIds from LoginDataLimit where loginId={0}", loginID);
            DataTable data = DBHelper.GetDataSet(sql);
            if (data.Rows.Count > 0)
            {
                return data.Rows[0]["dataIds"].ToString();
            }
            else
            {
                return null;
            }
        }

        public static string GetRoleId(int loginId)
        {
            string sql = "select roleId from LoginDataLimit where loginID=@loginID";
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@loginID",loginId)
            };

            DataTable data = DBHelper.GetDataSet(sql, param);
            if (data.Rows.Count > 0)
            {
                return data.Rows[0]["roleId"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static bool SetLimit(LoginDataLimit ldl)
        {
            string sqlExits = string.Format("select count(*) from LoginDataLimit where loginId={0}", ldl.LoginId);
            int result = DBHelper.ExecuteScalar(sqlExits);
            string sql = "";
            if (result > 0)
            {
                sql = string.Format("update LoginDataLimit set dataIds='{0}',roleId={1} where loginId={2}", ldl.DataIds, ldl.RoleId, ldl.LoginId);
            }
            else
            {
                sql = string.Format("insert into LoginDataLimit(loginId,dataIds,roleId) values({0},'{1}',{2})", ldl.LoginId, ldl.DataIds, ldl.RoleId);
            }

            return DBHelper.ExecuteCommand(sql) > 0 ? true : false;
        }

        public static string GetUsersByRole(int roleID)
        {
            string sql = "SELECT loginId FROM LoginDataLimit where roleId = @roleId";
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@roleId",roleID)
            };

            DataTable data = DBHelper.GetDataSet(sql, param);
            if (data.Rows.Count > 0)
            {
                StringBuilder userIDs = new StringBuilder();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    userIDs.Append(data.Rows[i]["loginID"]);
                    userIDs.Append(",");
                }
                return userIDs.ToString().TrimEnd(',');
            }
            else
            {
                return "";
            }
        }
    }
}
