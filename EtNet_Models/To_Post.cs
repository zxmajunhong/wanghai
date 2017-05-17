using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_Post
  {
   //To_Post表的默认构造方法
   public To_Post ()
   {

   }
   private int id;
   /// <summary>
   ///[To_Post]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string postname;
   /// <summary>
   ///[To_Post]表 [postname]列
   /// </summary>
   public string Postname
   {
     get{ return postname; }
     set{ this.postname=value;}
   }
  }
}
