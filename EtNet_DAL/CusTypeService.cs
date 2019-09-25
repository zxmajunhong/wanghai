using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[CusType]表的数据访问类
  /// </summary>
  public class CusTypeService
  {
   /// <summary>
   ///[CusType]表添加的方法
   /// </summary>
    public static int addCusType(CusType custype)
    {
      string sql="insert into CusType([typeName],[typeremark]) values (@typeName,@typeremark)";
      SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@typeName",custype.TypeName),
        new SqlParameter("@typeremark",custype.Typeremark)
      };
      return DBHelper.ExecuteCommand(sql,sp);
    }

   /// <summary>
   ///[CusType]表修改的方法
   /// </summary>
   public static int updateCusTypeById(CusType custype)
   {
     
     string sql="update CusType set typeName=@typeName,typeremark=@typeremark where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",custype.Id),
        new SqlParameter("@typeName",custype.TypeName),
        new SqlParameter("@typeremark",custype.Typeremark)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[CusType]表删除的方法
   /// </summary>
   public static int deleteCusTypeById(int id)
   {
     
     string sql="delete from CusType where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }
   /// <summary>
   ///[CusTypeName]表查询实体的方法
   /// </summary
   public static int getCusTypeBytypename(string typename)
   { 
   string sql="select count(*) from CusType where typeName='"+typename+"'";
   return DBHelper.ExecuteScalar(sql);
   }
   /// <summary>
   ///[CusType]表查询实体的方法
   /// </summary>
   public static CusType getCusTypeById(int id)
   {
     CusType custype = null;
     
     string sql="select * from CusType where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
     DataTable dt = DBHelper.GetDataSet(sql,sp);
     if(dt.Rows.Count>0)
     {
        custype = new CusType();
        foreach (DataRow dr in dt.Rows)
        {
              custype.Id = Convert.ToInt32(dr["id"]);
              custype.TypeName = Convert.ToString(dr["typeName"]);
              custype.Typeremark = Convert.ToString(dr["typeremark"]);
        }
     }
     
     return custype;
   }

   /// <summary>
   ///[CusType]表查询所有的方法
   /// </summary>
   public static IList<CusType> getCusTypeAll()
   {
     string sql="select * from CusType";
     return getCusTypesBySql(sql);
   }
   /// <summary>
   ///根据SQL语句获取集合
   /// </summary>
   public static IList<CusType> getCusTypesBySql(string sql)
   {
     IList<CusType> list = new List<CusType>();
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
          foreach (DataRow dr in dt.Rows)
          {
              CusType custype = new CusType();
              custype.Id = Convert.ToInt32(dr["id"]);
              custype.TypeName = Convert.ToString(dr["typeName"]);
              custype.Typeremark = Convert.ToString(dr["typeremark"]);
              list.Add(custype);
          }
     }
     return list;
   }
   /// <summary>
   ///根据SQL语句获取实体
   /// </summary>
   public static CusType getCusTypeBySql(string sql)
   {
     CusType custype = null;
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
        custype = new CusType();
        foreach (DataRow dr in dt.Rows)
        {
              custype.Id = Convert.ToInt32(dr["id"]);
              custype.TypeName = Convert.ToString(dr["typeName"]);
              custype.Typeremark = Convert.ToString(dr["typeremark"]);
        }
     }
     return custype;
   }
  }
}
