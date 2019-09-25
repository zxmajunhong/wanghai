using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[sysdiagrams]表的数据访问类
  /// </summary>
  public class SysdiagramsService
  {
   /// <summary>
   ///[sysdiagrams]表添加的方法
   /// </summary>
    public static int addSysdiagrams(Sysdiagrams sysdiagrams)
    {
      string sql="insert into sysdiagrams([name],[principal_id],[version],[definition]) values (@name,@principal_id,@version,@definition)";
      SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@name",sysdiagrams.Name),
        new SqlParameter("@principal_id",sysdiagrams.Principal_id),
        new SqlParameter("@version",sysdiagrams.Version),
        new SqlParameter("@definition",sysdiagrams.Definition)
      };
      return DBHelper.ExecuteCommand(sql,sp);
    }

   /// <summary>
   ///[sysdiagrams]表修改的方法
   /// </summary>
   public static int updateSysdiagramsById(Sysdiagrams sysdiagrams)
   {
     
     string sql="update sysdiagrams set name=@name,principal_id=@principal_id,version=@version,definition=@definition where diagram_id=@diagram_id";
     SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@name",sysdiagrams.Name),
        new SqlParameter("@principal_id",sysdiagrams.Principal_id),
        new SqlParameter("@diagram_id",sysdiagrams.Diagram_id),
        new SqlParameter("@version",sysdiagrams.Version),
        new SqlParameter("@definition",sysdiagrams.Definition)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[sysdiagrams]表删除的方法
   /// </summary>
   public static int deleteSysdiagramsById(int diagram_id)
   {
     
     string sql="delete from sysdiagrams where diagram_id=@diagram_id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@diagram_id",diagram_id)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[sysdiagrams]表查询实体的方法
   /// </summary>
   public static Sysdiagrams getSysdiagramsById(int diagram_id)
   {
     Sysdiagrams sysdiagrams = null;
     
     string sql="select * from sysdiagrams where diagram_id=@diagram_id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@diagram_id",diagram_id)
     };
     DataTable dt = DBHelper.GetDataSet(sql,sp);
     if(dt.Rows.Count>0)
     {
        sysdiagrams = new Sysdiagrams();
        foreach (DataRow dr in dt.Rows)
        {
              sysdiagrams.Name = Convert.ToString(dr["name"]);
              sysdiagrams.Principal_id = Convert.ToInt32(dr["principal_id"]);
              sysdiagrams.Diagram_id = Convert.ToInt32(dr["diagram_id"]);
              sysdiagrams.Version = Convert.ToInt32(dr["version"]);
              sysdiagrams.Definition = (byte[])dr["definition"];
        }
     }
     
     return sysdiagrams;
   }

   /// <summary>
   ///[sysdiagrams]表查询所有的方法
   /// </summary>
   public static IList<Sysdiagrams> getSysdiagramsAll()
   {
     string sql="select * from sysdiagrams";
     return getSysdiagramssBySql(sql);
   }
   /// <summary>
   ///根据SQL语句获取集合
   /// </summary>
   public static IList<Sysdiagrams> getSysdiagramssBySql(string sql)
   {
     IList<Sysdiagrams> list = new List<Sysdiagrams>();
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
          foreach (DataRow dr in dt.Rows)
          {
              Sysdiagrams sysdiagrams = new Sysdiagrams();
              sysdiagrams.Name = Convert.ToString(dr["name"]);
              sysdiagrams.Principal_id = Convert.ToInt32(dr["principal_id"]);
              sysdiagrams.Diagram_id = Convert.ToInt32(dr["diagram_id"]);
              sysdiagrams.Version = Convert.ToInt32(dr["version"]);
              sysdiagrams.Definition = (byte[])dr["definition"];
              list.Add(sysdiagrams);
          }
     }
     return list;
   }
   /// <summary>
   ///根据SQL语句获取实体
   /// </summary>
   public static Sysdiagrams getSysdiagramsBySql(string sql)
   {
     Sysdiagrams sysdiagrams = null;
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
        sysdiagrams = new Sysdiagrams();
        foreach (DataRow dr in dt.Rows)
        {
              sysdiagrams.Name = Convert.ToString(dr["name"]);
              sysdiagrams.Principal_id = Convert.ToInt32(dr["principal_id"]);
              sysdiagrams.Diagram_id = Convert.ToInt32(dr["diagram_id"]);
              sysdiagrams.Version = Convert.ToInt32(dr["version"]);
              sysdiagrams.Definition = (byte[])dr["definition"];
        }
     }
     return sysdiagrams;
   }
  }
}
