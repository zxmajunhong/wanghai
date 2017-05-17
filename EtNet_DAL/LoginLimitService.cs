using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[LoginLimit]表的数据访问类
  /// </summary>
  public class LoginLimitService
  {
   /// <summary>
   ///[LoginLimit]表添加的方法
   /// </summary>
    public static int addLoginLimit(LoginLimit loginlimit)
    {
      string sql="insert into LoginLimit([limitid],[roleid],[nodeid]) values (@limitid,@roleid,@nodeid)";
      SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@limitid",loginlimit.Limitid),
        new SqlParameter("@roleid",loginlimit.Roleid),
        new SqlParameter("@nodeid",loginlimit.Nodeid)
      };
      return DBHelper.ExecuteCommand(sql,sp);
    }

   /// <summary>
   ///[LoginLimit]表修改的方法
   /// </summary>
   public static int updateLoginLimitById(LoginLimit loginlimit)
   {
     /*由于生成时此表没有主键,所以该项方法无法得知执行条件!
     string sql="update LoginLimit set limitid=@limitid,roleid=@roleid,nodeid=@nodeid where ";
     SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@limitid",loginlimit.Limitid),
        new SqlParameter("@roleid",loginlimit.Roleid),
        new SqlParameter("@nodeid",loginlimit.Nodeid)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     */return 0;
   }

   /// <summary>
   ///[LoginLimit]表删除的方法
   /// </summary>
   public static int deleteLoginLimitById( )
   {
     /*由于生成时此表没有主键,所以该项方法无法得知执行条件!
     string sql="delete from LoginLimit where ";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@",)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     */return 0;
   }

   /// <summary>
   ///[LoginLimit]表查询实体的方法
   /// </summary>
   public static LoginLimit getLoginLimitById( )
   {
     LoginLimit loginlimit = null;
     /*由于生成时此表没有主键,所以该项方法无法得知执行条件!
     string sql="select * from LoginLimit where ";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@",)
     };
     DataTable dt = DBHelper.GetDataSet(sql,sp);
     if(dt.Rows.Count>0)
     {
        loginlimit = new LoginLimit();
        foreach (DataRow dr in dt.Rows)
        {
              loginlimit.Limitid = Convert.ToInt32(dr["limitid"]);
              loginlimit.Roleid = Convert.ToInt32(dr["roleid"]);
              loginlimit.Nodeid = Convert.ToInt32(dr["nodeid"]);
        }
     }
     */
     return loginlimit;
   }

   /// <summary>
   ///[LoginLimit]表查询所有的方法
   /// </summary>
   public static IList<LoginLimit> getLoginLimitAll()
   {
     string sql="select * from LoginLimit";
     return getLoginLimitsBySql(sql);
   }
   /// <summary>
   ///根据SQL语句获取集合
   /// </summary>
   public static IList<LoginLimit> getLoginLimitsBySql(string sql)
   {
     IList<LoginLimit> list = new List<LoginLimit>();
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
          foreach (DataRow dr in dt.Rows)
          {
              LoginLimit loginlimit = new LoginLimit();
              loginlimit.Limitid = Convert.ToInt32(dr["limitid"]);
              loginlimit.Roleid = Convert.ToInt32(dr["roleid"]);
              loginlimit.Nodeid = Convert.ToInt32(dr["nodeid"]);
              list.Add(loginlimit);
          }
     }
     return list;
   }
   /// <summary>
   ///根据SQL语句获取实体
   /// </summary>
   public static LoginLimit getLoginLimitBySql(string sql)
   {
     LoginLimit loginlimit = null;
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
        loginlimit = new LoginLimit();
        foreach (DataRow dr in dt.Rows)
        {
              loginlimit.Limitid = Convert.ToInt32(dr["limitid"]);
              loginlimit.Roleid = Convert.ToInt32(dr["roleid"]);
              loginlimit.Nodeid = Convert.ToInt32(dr["nodeid"]);
        }
     }
     return loginlimit;
   }
  }
}
