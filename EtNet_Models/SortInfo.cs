using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class SortInfo
  {
   //SortInfo表的默认构造方法
   public SortInfo ()
   {

   }
   private int sortid;
   /// <summary>
   ///[SortInfo]表主键
   /// [NoticeInfo]表的主键表
   /// 原列名[sortid]
   /// 原类型[int]
   /// 外键表[NoticeInfo]
   /// 关联列[sortid]
   /// </summary>
   public int Sortid
   {
     get{ return sortid; }
     set{ this.sortid=value;}
   }
   private string sortname;
   /// <summary>
   ///[SortInfo]表 [sortname]列
   /// </summary>
   public string Sortname
   {
     get{ return sortname; }
     set{ this.sortname=value;}
   }
  }
}
