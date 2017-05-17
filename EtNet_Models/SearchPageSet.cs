using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class SearchPageSet
  {
   //SearchPageSet表的默认构造方法
   public SearchPageSet ()
   {

   }
   private int id;
   /// <summary>
   ///[SearchPageSet]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int ownersid;
   /// <summary>
   ///[SearchPageSet]表 [ownersid]列
   /// </summary>
   public int Ownersid
   {
     get{ return ownersid; }
     set{ this.ownersid=value;}
   }
   private string pagenum;
   /// <summary>
   ///[SearchPageSet]表 [pagenum]列
   /// </summary>
   public string Pagenum
   {
     get{ return pagenum; }
     set{ this.pagenum=value;}
   }
   private int pageitem;
   /// <summary>
   ///[SearchPageSet]表 [pageitem]列
   /// </summary>
   public int Pageitem
   {
     get{ return pageitem; }
     set{ this.pageitem=value;}
   }
   private int pagecount;
   /// <summary>
   ///[SearchPageSet]表 [pagecount]列
   /// </summary>
   public int Pagecount
   {
     get{ return pagecount; }
     set{ this.pagecount=value;}
   }
  }
}
