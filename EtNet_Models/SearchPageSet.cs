using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class SearchPageSet
  {
   //SearchPageSet���Ĭ�Ϲ��췽��
   public SearchPageSet ()
   {

   }
   private int id;
   /// <summary>
   ///[SearchPageSet]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int ownersid;
   /// <summary>
   ///[SearchPageSet]�� [ownersid]��
   /// </summary>
   public int Ownersid
   {
     get{ return ownersid; }
     set{ this.ownersid=value;}
   }
   private string pagenum;
   /// <summary>
   ///[SearchPageSet]�� [pagenum]��
   /// </summary>
   public string Pagenum
   {
     get{ return pagenum; }
     set{ this.pagenum=value;}
   }
   private int pageitem;
   /// <summary>
   ///[SearchPageSet]�� [pageitem]��
   /// </summary>
   public int Pageitem
   {
     get{ return pageitem; }
     set{ this.pageitem=value;}
   }
   private int pagecount;
   /// <summary>
   ///[SearchPageSet]�� [pagecount]��
   /// </summary>
   public int Pagecount
   {
     get{ return pagecount; }
     set{ this.pagecount=value;}
   }
  }
}
