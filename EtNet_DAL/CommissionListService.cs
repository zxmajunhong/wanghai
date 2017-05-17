using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[commissionList]������ݷ�����
  /// </summary>
  public class CommissionListService
  {
   /// <summary>
   ///[commissionList]����ӵķ���
   /// </summary>
    public static int addCommissionList(CommissionList commissionlist)
    {
      string sql="insert into commissionList([task],[commission]) values (@task,@commission)";
      SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@task",commissionlist.Task),
        new SqlParameter("@commission",commissionlist.Commission)
      };
      return DBHelper.ExecuteCommand(sql,sp);
    }

   /// <summary>
   ///[commissionList]���޸ĵķ���
   /// </summary>
   public static int updateCommissionListById(CommissionList commissionlist)
   {
     
     string sql="update commissionList set task=@task,commission=@commission where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",commissionlist.Id),
        new SqlParameter("@task",commissionlist.Task),
        new SqlParameter("@commission",commissionlist.Commission)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[commissionList]��ɾ���ķ���
   /// </summary>
   public static int deleteCommissionListById(int id)
   {
     
     string sql="delete from commissionList where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[commissionList]���ѯʵ��ķ���
   /// </summary>
   public static CommissionList getCommissionListById(int id)
   {
     CommissionList commissionlist = null;
     
     string sql="select * from commissionList where id=@id";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
     DataTable dt = DBHelper.GetDataSet(sql,sp);
     if(dt.Rows.Count>0)
     {
        commissionlist = new CommissionList();
        foreach (DataRow dr in dt.Rows)
        {
              commissionlist.Id = Convert.ToInt32(dr["id"]);
              commissionlist.Task = Convert.ToString(dr["task"]);
              commissionlist.Commission = Convert.ToString(dr["commission"]);
        }
     }
     
     return commissionlist;
   }

   /// <summary>
   ///[commissionList]���ѯ���еķ���
   /// </summary>
   public static IList<CommissionList> getCommissionListAll()
   {
     string sql="select * from commissionList";
     return getCommissionListsBySql(sql);
   }
   /// <summary>
   ///����SQL����ȡ����
   /// </summary>
   public static IList<CommissionList> getCommissionListsBySql(string sql)
   {
     IList<CommissionList> list = new List<CommissionList>();
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
          foreach (DataRow dr in dt.Rows)
          {
              CommissionList commissionlist = new CommissionList();
              commissionlist.Id = Convert.ToInt32(dr["id"]);
              commissionlist.Task = Convert.ToString(dr["task"]);
              commissionlist.Commission = Convert.ToString(dr["commission"]);
              list.Add(commissionlist);
          }
     }
     return list;
   }
   /// <summary>
   ///����SQL����ȡʵ��
   /// </summary>
   public static CommissionList getCommissionListBySql(string sql)
   {
     CommissionList commissionlist = null;
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
        commissionlist = new CommissionList();
        foreach (DataRow dr in dt.Rows)
        {
              commissionlist.Id = Convert.ToInt32(dr["id"]);
              commissionlist.Task = Convert.ToString(dr["task"]);
              commissionlist.Commission = Convert.ToString(dr["commission"]);
        }
     }
     return commissionlist;
   }
  }
}
