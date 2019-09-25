using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[Parameter]表的数据访问类
  /// </summary>
  public class ParameterService
  {
   /// <summary>
   ///[Parameter]表添加的方法
   /// </summary>
    public static int addParameter(Parameter parameter)
    {
        string sql = "insert into Parameter([rate],[freeDay],[conRatio],[brokeRatio],[brokeTaxRatio],[serviceRatio],[otherRatio],[commission],[serviceTaxRatio]) values (@rate,@freeDay,@conRatio,@brokeRatio,@brokeTaxRatio,@serviceRatio,@otherRatio,@commission,@serviceTaxRatio)";
      SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@rate",parameter.Rate),
        new SqlParameter("@freeDay",parameter.FreeDay),
        new SqlParameter("@conRatio",parameter.ConRatio),
        new SqlParameter("@brokeRatio",parameter.BrokeRatio),
        new SqlParameter("@brokeTaxRatio",parameter.BrokeTaxRatio),
        new SqlParameter("@serviceRatio",parameter.ServiceRatio),
        new SqlParameter("@otherRatio",parameter.OtherRatio),
        new SqlParameter("@commission",parameter.Commission),
        new SqlParameter("@serviceTaxRatio",parameter.ServiceTaxRatio)
      };
      return DBHelper.ExecuteCommand(sql,sp);
    }

   /// <summary>
   ///[Parameter]表修改的方法
   /// </summary>
   public static int updateParameterById(Parameter parameter)
   {

       string sql = "update Parameter set rate=@rate,freeDay=@freeDay,conRatio=@conRatio,brokeRatio=@brokeRatio,brokeTaxRatio=@brokeTaxRatio,serviceRatio=@serviceRatio,otherRatio=@otherRatio,commission=@commission,serviceTaxRatio=@serviceTaxRatio where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",parameter.Id),
        new SqlParameter("@rate",parameter.Rate),
        new SqlParameter("@freeDay",parameter.FreeDay),
        new SqlParameter("@conRatio",parameter.ConRatio),
        new SqlParameter("@brokeRatio",parameter.BrokeRatio),
        new SqlParameter("@brokeTaxRatio",parameter.BrokeTaxRatio),
        new SqlParameter("@serviceRatio",parameter.ServiceRatio),
        new SqlParameter("@otherRatio",parameter.OtherRatio),
        new SqlParameter("@commission",parameter.Commission),
        new SqlParameter("@serviceTaxRatio",parameter.ServiceTaxRatio)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[Parameter]表删除的方法
   /// </summary>
   public static int deleteParameterById(int id)
   {
     
     string sql="delete from Parameter where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[Parameter]表查询实体的方法
   /// </summary>
   public static Parameter getParameterById(int id)
   {
     Parameter parameter = null;
     
     string sql="select * from Parameter where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
     DataTable dt = DBHelper.GetDataSet(sql,sp);
     if(dt.Rows.Count>0)
     {
        parameter = new Parameter();
        foreach (DataRow dr in dt.Rows)
        {
              parameter.Id = Convert.ToInt32(dr["id"]);
              parameter.Rate = Convert.ToString(dr["rate"]);
              parameter.FreeDay = Convert.ToInt32(dr["freeDay"]);
              parameter.ConRatio = Convert.ToString(dr["conRatio"]);
              parameter.BrokeRatio = Convert.ToString(dr["brokeRatio"]);
              parameter.BrokeTaxRatio = Convert.ToString(dr["brokeTaxRatio"]);
              parameter.ServiceRatio = Convert.ToString(dr["serviceRatio"]);
              parameter.OtherRatio = Convert.ToString(dr["otherRatio"]);
              parameter.Commission = Convert.ToInt32(dr["commission"]);
              parameter.ServiceTaxRatio = dr["serviceTaxRatio"].ToString();
        }
     }
     
     return parameter;
   }

   /// <summary>
   ///[Parameter]表查询所有的方法
   /// </summary>
   public static IList<Parameter> getParameterAll()
   {
     string sql="select * from Parameter";
     return getParametersBySql(sql);
   }
   /// <summary>
   ///根据SQL语句获取集合
   /// </summary>
   public static IList<Parameter> getParametersBySql(string sql)
   {
     IList<Parameter> list = new List<Parameter>();
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
          foreach (DataRow dr in dt.Rows)
          {
              Parameter parameter = new Parameter();
              parameter.Id = Convert.ToInt32(dr["id"]);
              parameter.Rate = Convert.ToString(dr["rate"]);
              parameter.FreeDay = Convert.ToInt32(dr["freeDay"]);
              parameter.ConRatio = Convert.ToString(dr["conRatio"]);
              parameter.BrokeRatio = Convert.ToString(dr["brokeRatio"]);
              parameter.BrokeTaxRatio = Convert.ToString(dr["brokeTaxRatio"]);
              parameter.ServiceRatio = Convert.ToString(dr["serviceRatio"]);
              parameter.OtherRatio = Convert.ToString(dr["otherRatio"]);
              parameter.Commission = Convert.ToInt32(dr["commission"]);
              parameter.ServiceTaxRatio = dr["serviceTaxRatio"].ToString();
              list.Add(parameter);
          }
     }
     return list;
   }
   /// <summary>
   ///根据SQL语句获取实体
   /// </summary>
   public static Parameter getParameterBySql(string sql)
   {
     Parameter parameter = null;
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
        parameter = new Parameter();
        foreach (DataRow dr in dt.Rows)
        {
              parameter.Id = Convert.ToInt32(dr["id"]);
              parameter.Rate = Convert.ToString(dr["rate"]);
              parameter.FreeDay = Convert.ToInt32(dr["freeDay"]);
              parameter.ConRatio = Convert.ToString(dr["conRatio"]);
              parameter.BrokeRatio = Convert.ToString(dr["brokeRatio"]);
              parameter.BrokeTaxRatio = Convert.ToString(dr["brokeTaxRatio"]);
              parameter.ServiceRatio = Convert.ToString(dr["serviceRatio"]);
              parameter.OtherRatio = Convert.ToString(dr["otherRatio"]);
              parameter.Commission = Convert.ToInt32(dr["commission"]);
              parameter.ServiceTaxRatio = dr["serviceTaxRatio"].ToString();
        }
     }
     return parameter;
   }
  }
}
