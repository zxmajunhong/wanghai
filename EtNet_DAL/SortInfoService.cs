using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[SortInfo]������ݷ�����
  /// </summary>
  public class SortInfoService
  {
   /// <summary>
   ///[SortInfo]����ӵķ���
   /// </summary>
    public static int addSortInfo(SortInfo sortinfo)
    {
      string sql="insert into SortInfo([sortname]) values (@sortname)";
      SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@sortname",sortinfo.Sortname)
      };
      return DBHelper.ExecuteCommand(sql,sp);
    }

   /// <summary>
   ///[SortInfo]���޸ĵķ���
   /// </summary>
   public static int updateSortInfoById(SortInfo sortinfo)
   {
     
     string sql="update SortInfo set sortname=@sortname where sortid=@sortid";
     SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@sortid",sortinfo.Sortid),
        new SqlParameter("@sortname",sortinfo.Sortname)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[SortInfo]��ɾ���ķ���
   /// </summary>
   public static int deleteSortInfoById(int sortid)
   {
     
     string sql="delete from SortInfo where sortid=@sortid";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@sortid",sortid)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[SortInfo]���ѯʵ��ķ���
   /// </summary>
   public static SortInfo getSortInfoById(int sortid)
   {
     SortInfo sortinfo = null;
     
     string sql="select * from SortInfo where sortid=@sortid";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@sortid",sortid)
     };
     DataTable dt = DBHelper.GetDataSet(sql,sp);
     if(dt.Rows.Count>0)
     {
        sortinfo = new SortInfo();
        foreach (DataRow dr in dt.Rows)
        {
              sortinfo.Sortid = Convert.ToInt32(dr["sortid"]);
              sortinfo.Sortname = Convert.ToString(dr["sortname"]);
        }
     }
     
     return sortinfo;
   }

   /// <summary>
   ///[SortInfo]���ѯ���еķ���
   /// </summary>
   public static IList<SortInfo> getSortInfoAll()
   {
     string sql="select * from SortInfo";
     return getSortInfosBySql(sql);
   }
   /// <summary>
   ///����SQL����ȡ����
   /// </summary>
   public static IList<SortInfo> getSortInfosBySql(string sql)
   {
     IList<SortInfo> list = new List<SortInfo>();
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
          foreach (DataRow dr in dt.Rows)
          {
              SortInfo sortinfo = new SortInfo();
              sortinfo.Sortid = Convert.ToInt32(dr["sortid"]);
              sortinfo.Sortname = Convert.ToString(dr["sortname"]);
              list.Add(sortinfo);
          }
     }
     return list;
   }
   /// <summary>
   ///����SQL����ȡʵ��
   /// </summary>
   public static SortInfo getSortInfoBySql(string sql)
   {
     SortInfo sortinfo = null;
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
        sortinfo = new SortInfo();
        foreach (DataRow dr in dt.Rows)
        {
              sortinfo.Sortid = Convert.ToInt32(dr["sortid"]);
              sortinfo.Sortname = Convert.ToString(dr["sortname"]);
        }
     }
     return sortinfo;
   }


   /// <summary>
   /// ��ѯ�������͵�����,���idΪ�գ���ѯȫ��������
   /// </summary>
   public static DataTable SortTbl(string id)
   {
       string strSql = "select * from SortInfo ";
       if (id != "")
       {
           strSql += " where sortid = " + id;
       }
       else
       { }
       DataTable dt = DBHelper.GetDataSet(strSql);
       return dt;

   }








  }
}
