using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[RoleInfo]表的数据访问类
  /// </summary>
  public class RoleInfoService
  {
   /// <summary>
   ///[RoleInfo]表添加的方法
   /// </summary>
    public static int addRoleInfo(RoleInfo roleinfo)
    {
      string sql="insert into RoleInfo([rolenname],[remark]) values (@rolenname,@remark)";
      SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@rolenname",roleinfo.Rolenname),
        new SqlParameter("@remark",roleinfo.Remark)
      };
      return DBHelper.ExecuteCommand(sql,sp);
    }

    public static int AddRole(RoleInfo roleInfo)
    {
        string sql = "insert into RoleInfo([rolenname],[remark]) values (@rolenname,@remark);select @@IDENTITY";
        using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
        {
            conn.Open();
            SqlParameter[] sp = new SqlParameter[]
              {
                new SqlParameter("@rolenname",roleInfo.Rolenname),
                new SqlParameter("@remark",roleInfo.Remark)
              };
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(sp);
            object result = cmd.ExecuteScalar();
            return result == null ? 0 : Convert.ToInt32(result);
        }
    }

   /// <summary>
   ///[RoleInfo]表修改的方法
   /// </summary>
   public static int updateRoleInfoById(RoleInfo roleinfo)
   {
     
     string sql="update RoleInfo set rolenname=@rolenname,remark=@remark where roleid=@roleid";
     SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@roleid",roleinfo.Roleid),
        new SqlParameter("@rolenname",roleinfo.Rolenname),
        new SqlParameter("@remark",roleinfo.Remark)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[RoleInfo]表删除的方法
   /// </summary>
   public static int deleteRoleInfoById(int roleid)
   {
     
     string sql="delete from RoleInfo where roleid=@roleid";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@roleid",roleid)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[RoleInfo]表查询实体的方法
   /// </summary>
   public static RoleInfo getRoleInfoById(int roleid)
   {
     RoleInfo roleinfo = null;
     
     string sql="select * from RoleInfo where roleid=@roleid";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@roleid",roleid)
     };
     DataTable dt = DBHelper.GetDataSet(sql,sp);
     if(dt.Rows.Count>0)
     {
        roleinfo = new RoleInfo();
        foreach (DataRow dr in dt.Rows)
        {
              roleinfo.Roleid = Convert.ToInt32(dr["roleid"]);
              roleinfo.Rolenname = Convert.ToString(dr["rolenname"]);
              roleinfo.Remark = Convert.ToString(dr["remark"]);
        }
     }
     
     return roleinfo;
   }

   /// <summary>
   ///[RoleInfo]表查询所有的方法
   /// </summary>
   public static IList<RoleInfo> getRoleInfoAll()
   {
     string sql="select * from RoleInfo";
     return getRoleInfosBySql(sql);
   }
   /// <summary>
   ///根据SQL语句获取集合
   /// </summary>
   public static IList<RoleInfo> getRoleInfosBySql(string sql)
   {
     IList<RoleInfo> list = new List<RoleInfo>();
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
          foreach (DataRow dr in dt.Rows)
          {
              RoleInfo roleinfo = new RoleInfo();
              roleinfo.Roleid = Convert.ToInt32(dr["roleid"]);
              roleinfo.Rolenname = Convert.ToString(dr["rolenname"]);
              roleinfo.Remark = Convert.ToString(dr["remark"]);
              list.Add(roleinfo);
          }
     }
     return list;
   }
   /// <summary>
   ///根据SQL语句获取实体
   /// </summary>
   public static RoleInfo getRoleInfoBySql(string sql)
   {
     RoleInfo roleinfo = null;
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
        roleinfo = new RoleInfo();
        foreach (DataRow dr in dt.Rows)
        {
              roleinfo.Roleid = Convert.ToInt32(dr["roleid"]);
              roleinfo.Rolenname = Convert.ToString(dr["rolenname"]);
              roleinfo.Remark = Convert.ToString(dr["remark"]);
        }
     }
     return roleinfo;
   }
  }
}
