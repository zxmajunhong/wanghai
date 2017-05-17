using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data.SqlClient;
namespace EtNet_BLL
{

    //提示:由于生成时此表没有主键,所以有很多方法无法得知执行条件,请人为手写!
    public class LoginLimitManager
    {
        public static int addLoginLimit(LoginLimit loginlimit)
        {
            return LoginLimitService.addLoginLimit(loginlimit);
        }

        public static int updateLoginLimit(LoginLimit loginlimit)
        {
            return LoginLimitService.updateLoginLimitById(loginlimit);
        }

        public static int deleteLoginLimit()
        {
            return LoginLimitService.deleteLoginLimitById();
        }

        public static LoginLimit getLoginLimitById()
        {
            return LoginLimitService.getLoginLimitById();
        }

        public static IList<LoginLimit> getLoginLimitAll()
        {
            return LoginLimitService.getLoginLimitAll();
        }

        public static IList<LoginLimit> GetRoleLimitByRoleIdAndParentNodeId(int roleId, int parentNodeId)
        {
            string sql = "SELECT a.* FROM LoginLimit a,Menu b WHERE a.NodeId = b.NodeId and b.ParentNodeId=" + parentNodeId + " and a.RoleId = " + roleId + "";
            return LoginLimitService.getLoginLimitsBySql(sql);
        }

        public static IList<LoginLimit> GetParentNodesByRoleId(int roleId)
        {
            string sql = "SELECT a.* FROM LoginLimit a,Menu b WHERE a.NodeId = b.NodeId and b.ParentNodeId='0' and a.RoleId = " + roleId + "";
            return LoginLimitService.getLoginLimitsBySql(sql);
        }

        public static IList<LoginLimit> getAllNodeByRoleId(int roleid)
        {
            string sql = "SELECT a.* FROM LoginLimit a,Menu b WHERE a.NodeId = b.NodeId and a.RoleId = " + roleid + "";
            return LoginLimitService.getLoginLimitsBySql(sql);
        }

        public static bool InsertLoginLimt(string roleid, string nodeid)
        {
            string sql = "INSERT into LoginLimit(RoleId,NodeId) VALUES (@RoleId, @NodeId)";
            sql += " ; SELECT @@IDENTITY";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@RoleId", roleid), 
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

        public static bool DeleteLoginLimit(string roleid, string nodeid)
        {
            string sql = "DELETE from LoginLimit WHERE RoleId = @RoleId and NodeId =@NodeId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoleId", roleid),
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

        public static bool DeleteRoleMenu(string roleid)
        {
            string sql = "DELETE from LoginLimit WHERE RoleId = @RoleId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoleId", roleid)
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
    }
}
