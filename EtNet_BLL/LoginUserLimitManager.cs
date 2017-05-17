using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data.SqlClient;
namespace EtNet_BLL
{


    public class LoginUserLimitManager
    {
        public static int addLoginUserLimit(LoginUserLimit loginuserlimit)
        {
            return LoginUserLimitService.addLoginUserLimit(loginuserlimit);
        }

        public static int updateLoginUserLimit(LoginUserLimit loginuserlimit)
        {
            return LoginUserLimitService.updateLoginUserLimitById(loginuserlimit);
        }

        public static int deleteLoginUserLimit(int limitid)
        {
            return LoginUserLimitService.deleteLoginUserLimitById(limitid);
        }

        public static LoginUserLimit getLoginUserLimitById(int limitid)
        {
            return LoginUserLimitService.getLoginUserLimitById(limitid);
        }

        public static IList<LoginUserLimit> getLoginUserLimitAll()
        {
            return LoginUserLimitService.getLoginUserLimitAll();
        }

        public static IList<LoginUserLimit> getParentNodesById(int id)
        {
            string sql = "SELECT a.* FROM LoginUserLimit a,Menu b WHERE a.NodeId = b.NodeId and b.ParentNodeId='0' and a.loginId = " + id + "";
            return LoginUserLimitService.getLoginUserLimitsBySql(sql);//LoginLimitService.getLoginLimitsBySql(sql);
        }

        public static IList<LoginUserLimit> GetUserLimitByIdAndParentNodeId(int id, int parentNodeId)
        {
            string sql = "SELECT a.* FROM LoginUserLimit a,Menu b WHERE a.NodeId = b.NodeId and b.ParentNodeId=" + parentNodeId + " and a.loginId = " + id + "";
            return LoginUserLimitService.getLoginUserLimitsBySql(sql);
        }

        public static IList<LoginUserLimit> getAllNodeById(int id)
        {
            string sql = "SELECT a.* FROM LoginUserLimit a,Menu b WHERE a.NodeId = b.NodeId and a.loginId = " + id + "";
            return LoginUserLimitService.getLoginUserLimitsBySql(sql);//LoginLimitService.getLoginLimitsBySql(sql);
        }


        public static bool InsertUserLimt(string id, string nodeid)
        {
            string sql = "INSERT into LoginUserLimit(loginId,NodeId) VALUES (@LoginId, @NodeId)";
            sql += " ; SELECT @@IDENTITY";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@LoginId", id), 
				new SqlParameter("@NodeId", nodeid)
			};
            int result = DBHelper.ExecuteCommand(sql, para);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteUserLimit(string id, string nodeid)
        {
            string sql = "DELETE from LoginUserLimit WHERE loginId = @LoginId and NodeId =@NodeId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId", id),
                new SqlParameter("@NodeId", nodeid)
            };
            int count = DBHelper.ExecuteCommand(sql, para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void InsertLoginLimt(int id, int roleid)
        {
            string sql = "insert into LoginUserLimit (loginid,nodeid) select " + id + " ,nodeid from LoginLimit where roleid = " + roleid;
            int count = DBHelper.ExecuteCommand(sql);
        }

        public static bool DeleteLoginLimitByUser(int userId)
        {
            string sql = "DELETE from LoginUserLimit WHERE loginId = @LoginId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId", userId)
            };
            int count = DBHelper.ExecuteCommand(sql, para);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static int GetLimitCount(int id)
        {
            string sql = "select count(*) from LoginUserLimit where loginid = " + id;
            return DBHelper.ExecuteScalar(sql);
        }
    }
}
