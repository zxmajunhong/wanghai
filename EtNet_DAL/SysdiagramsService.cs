using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[sysdiagrams]������ݷ�����
  /// </summary>
  public class SysdiagramsService
  {
   /// <summary>
   ///[sysdiagrams]����ӵķ���
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
   ///[sysdiagrams]���޸ĵķ���
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
   ///[sysdiagrams]��ɾ���ķ���
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
   ///[sysdiagrams]���ѯʵ��ķ���
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
   ///[sysdiagrams]���ѯ���еķ���
   /// </summary>
   public static IList<Sysdiagrams> getSysdiagramsAll()
   {
     string sql="select * from sysdiagrams";
     return getSysdiagramssBySql(sql);
   }
   /// <summary>
   ///����SQL����ȡ����
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
   ///����SQL����ȡʵ��
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
