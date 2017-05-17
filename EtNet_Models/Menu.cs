using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Menu
  {
   //Menu表的默认构造方法
   public Menu ()
   {

   }
   private int nodeid;
   /// <summary>
   ///[Menu]表主键
   /// [LoginUserLimit]表的主键表
   /// 原列名[nodeid]
   /// 原类型[int]
   /// 外键表[LoginUserLimit]
   /// 关联列[nodeid]
   /// </summary>
   public int Nodeid
   {
     get{ return nodeid; }
     set{ this.nodeid=value;}
   }
   private string name;
   /// <summary>
   ///[Menu]表 [name]列
   /// </summary>
   public string Name
   {
     get{ return name; }
     set{ this.name=value;}
   }
   private string url;
   /// <summary>
   ///[Menu]表 [url]列
   /// </summary>
   public string Url
   {
     get{ return url; }
     set{ this.url=value;}
   }
   private int nodesort;
   /// <summary>
   ///[Menu]表 [nodesort]列
   /// </summary>
   public int Nodesort
   {
     get{ return nodesort; }
     set{ this.nodesort=value;}
   }
   private int parentnodeid;
   /// <summary>
   ///[Menu]表 [parentnodeid]列
   /// </summary>
   public int Parentnodeid
   {
     get{ return parentnodeid; }
     set{ this.parentnodeid=value;}
   }
  }
}
