using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[To_Post]表的数据访问类
  /// </summary>
  public class To_PostService
  {
   /// <summary>
   ///[To_Post]表添加的方法
   /// </summary>
    public static int addTo_Post(To_Post to_post)
    {
      string sql="insert into To_Post([postname]) values (@postname)";
      SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@postname",to_post.Postname)
      };
      return DBHelper.ExecuteCommand(sql,sp);
    }

   /// <summary>
   ///[To_Post]表修改的方法
   /// </summary>
   public static int updateTo_PostById(To_Post to_post)
   {
     
     string sql="update To_Post set postname=@postname where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",to_post.Id),
        new SqlParameter("@postname",to_post.Postname)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[To_Post]表删除的方法
   /// </summary>
   public static int deleteTo_PostById(int id)
   {
     
     string sql="delete from To_Post where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[To_Post]表查询实体的方法
   /// </summary>
   public static To_Post getTo_PostById(int id)
   {
     To_Post to_post = null;
     
     string sql="select * from To_Post where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
     DataTable dt = DBHelper.GetDataSet(sql,sp);
     if(dt.Rows.Count>0)
     {
        to_post = new To_Post();
        foreach (DataRow dr in dt.Rows)
        {
              to_post.Id = Convert.ToInt32(dr["id"]);
              to_post.Postname = Convert.ToString(dr["postname"]);
        }
     }
     
     return to_post;
   }

   /// <summary>
   ///[To_Post]表查询所有的方法
   /// </summary>
   public static IList<To_Post> getTo_PostAll()
   {
     string sql="select * from To_Post";
     return getTo_PostsBySql(sql);
   }
   /// <summary>
   ///根据SQL语句获取集合
   /// </summary>
   public static IList<To_Post> getTo_PostsBySql(string sql)
   {
     IList<To_Post> list = new List<To_Post>();
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
          foreach (DataRow dr in dt.Rows)
          {
              To_Post to_post = new To_Post();
              to_post.Id = Convert.ToInt32(dr["id"]);
              to_post.Postname = Convert.ToString(dr["postname"]);
              list.Add(to_post);
          }
     }
     return list;
   }
   /// <summary>
   ///根据SQL语句获取实体
   /// </summary>
   public static To_Post getTo_PostBySql(string sql)
   {
     To_Post to_post = null;
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
        to_post = new To_Post();
        foreach (DataRow dr in dt.Rows)
        {
              to_post.Id = Convert.ToInt32(dr["id"]);
              to_post.Postname = Convert.ToString(dr["postname"]);
        }
     }
     return to_post;
   }

   public static int getLoginInfoByPostname(string postname)
   {
       string sql = "select count(*) from To_Post where postname ='" + postname + "'";
       //int num = Convert.ToInt32(sql);
       return DBHelper.ExecuteScalar(sql);
        
   }
  }
}
