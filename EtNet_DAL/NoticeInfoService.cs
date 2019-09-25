using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

  /// <summary>
  ///[NoticeInfo]表的数据访问类
  /// </summary>
  public class NoticeInfoService
  {
   /// <summary>
   ///[NoticeInfo]表添加的方法
   /// </summary>
    public static int addNoticeInfo(NoticeInfo noticeinfo)
    {
      string sql="insert into NoticeInfo([title],[sortid],[ifpublic],[fromuser],[begintime],[endtime],[attribute],[accressory],[context]) values (@title,@sortid,@ifpublic,@fromuser,@begintime,@endtime,@attribute,@accressory,@context)";
      SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@title",noticeinfo.Title),
        new SqlParameter("@sortid",noticeinfo.Sortid.Sortid),
        new SqlParameter("@ifpublic",noticeinfo.Ifpublic),
        new SqlParameter("@fromuser",noticeinfo.Fromuser),
        new SqlParameter("@begintime",noticeinfo.Begintime),
        new SqlParameter("@endtime",noticeinfo.Endtime),
        new SqlParameter("@attribute",noticeinfo.Attribute),
        new SqlParameter("@accressory",noticeinfo.Accressory),
        new SqlParameter("@context",noticeinfo.Context)
      };
      return DBHelper.ExecuteCommand(sql,sp);
    }

   /// <summary>
   ///[NoticeInfo]表修改的方法
   /// </summary>
   public static int updateNoticeInfoById(NoticeInfo noticeinfo)
   {
     
     string sql="update NoticeInfo set title=@title,sortid=@sortid,ifpublic=@ifpublic,fromuser=@fromuser,begintime=@begintime,endtime=@endtime,attribute=@attribute,accressory=@accressory,context=@context where noticeid=@noticeid";
     SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@noticeid",noticeinfo.Noticeid),
        new SqlParameter("@title",noticeinfo.Title),
        new SqlParameter("@sortid",noticeinfo.Sortid.Sortid),
        new SqlParameter("@ifpublic",noticeinfo.Ifpublic),
        new SqlParameter("@fromuser",noticeinfo.Fromuser),
        new SqlParameter("@begintime",noticeinfo.Begintime),
        new SqlParameter("@endtime",noticeinfo.Endtime),
        new SqlParameter("@attribute",noticeinfo.Attribute),
        new SqlParameter("@accressory",noticeinfo.Accressory),
        new SqlParameter("@context",noticeinfo.Context)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[NoticeInfo]表删除的方法
   /// </summary>
   public static int deleteNoticeInfoById(int noticeid)
   {
     
     string sql="delete from NoticeInfo where noticeid=@noticeid";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@noticeid",noticeid)
     };
     return DBHelper.ExecuteCommand(sql,sp);
     
   }

   /// <summary>
   ///[NoticeInfo]表查询实体的方法
   /// </summary>
   public static NoticeInfo getNoticeInfoById(int noticeid)
   {
     NoticeInfo noticeinfo = null;
     
     string sql="select * from NoticeInfo where noticeid=@noticeid";
     SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@noticeid",noticeid)
     };
     DataTable dt = DBHelper.GetDataSet(sql,sp);
     if(dt.Rows.Count>0)
     {
        noticeinfo = new NoticeInfo();
        foreach (DataRow dr in dt.Rows)
        {
              noticeinfo.Noticeid = Convert.ToInt32(dr["noticeid"]);
              noticeinfo.Title = Convert.ToString(dr["title"]);
              noticeinfo.Sortid = SortInfoService.getSortInfoById((int)dr["sortid"]);
              noticeinfo.Ifpublic = Convert.ToInt32(dr["ifpublic"]);
              noticeinfo.Fromuser = Convert.ToString(dr["fromuser"]);
              noticeinfo.Begintime = Convert.ToDateTime(dr["begintime"]);
              noticeinfo.Endtime = Convert.ToDateTime(dr["endtime"]);
              noticeinfo.Attribute = Convert.ToInt32(dr["attribute"]);
              noticeinfo.Accressory = Convert.ToString(dr["accressory"]);
              noticeinfo.Context = Convert.ToString(dr["context"]);
        }
     }
     
     return noticeinfo;
   }

   /// <summary>
   ///[NoticeInfo]表查询所有的方法
   /// </summary>
   public static IList<NoticeInfo> getNoticeInfoAll()
   {
     string sql="select * from NoticeInfo";
     return getNoticeInfosBySql(sql);
   }
   /// <summary>
   ///根据SQL语句获取集合
   /// </summary>
   public static IList<NoticeInfo> getNoticeInfosBySql(string sql)
   {
     IList<NoticeInfo> list = new List<NoticeInfo>();
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
          foreach (DataRow dr in dt.Rows)
          {
              NoticeInfo noticeinfo = new NoticeInfo();
              noticeinfo.Noticeid = Convert.ToInt32(dr["noticeid"]);
              noticeinfo.Title = Convert.ToString(dr["title"]);
              noticeinfo.Sortid = SortInfoService.getSortInfoById((int)dr["sortid"]);
              noticeinfo.Ifpublic = Convert.ToInt32(dr["ifpublic"]);
              noticeinfo.Fromuser = Convert.ToString(dr["fromuser"]);
              noticeinfo.Begintime = Convert.ToDateTime(dr["begintime"]);
              noticeinfo.Endtime = Convert.ToDateTime(dr["endtime"]);
              noticeinfo.Attribute = Convert.ToInt32(dr["attribute"]);
              noticeinfo.Accressory = Convert.ToString(dr["accressory"]);
              noticeinfo.Context = Convert.ToString(dr["context"]);
              list.Add(noticeinfo);
          }
     }
     return list;
   }
   /// <summary>
   ///根据SQL语句获取实体
   /// </summary>
   public static NoticeInfo getNoticeInfoBySql(string sql)
   {
     NoticeInfo noticeinfo = null;
     DataTable dt = DBHelper.GetDataSet(sql);
     if(dt.Rows.Count>0)
     {
        noticeinfo = new NoticeInfo();
        foreach (DataRow dr in dt.Rows)
        {
              noticeinfo.Noticeid = Convert.ToInt32(dr["noticeid"]);
              noticeinfo.Title = Convert.ToString(dr["title"]);
              noticeinfo.Sortid = SortInfoService.getSortInfoById((int)dr["sortid"]);
              noticeinfo.Ifpublic = Convert.ToInt32(dr["ifpublic"]);
              noticeinfo.Fromuser = Convert.ToString(dr["fromuser"]);
              noticeinfo.Begintime = Convert.ToDateTime(dr["begintime"]);
              noticeinfo.Endtime = Convert.ToDateTime(dr["endtime"]);
              noticeinfo.Attribute = Convert.ToInt32(dr["attribute"]);
              noticeinfo.Accressory = Convert.ToString(dr["accressory"]);
              noticeinfo.Context = Convert.ToString(dr["context"]);
        }
     }
     return noticeinfo;
   }



   public static DataTable getlist(string strfileds, string strwhere)
   {
       string sql = "select ";
       if (strfileds != "")
       {
           sql += strfileds;
       }
       else
       { 
         sql += " * ";
       }
       sql += " from NoticeInfo";
       if(strwhere != "")
       {
           sql += " where " + strwhere;
       }

       DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(sql);
       return tbl;


   }


  }
}
