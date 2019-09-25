using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class FactType
  {
   //FactType表的默认构造方法
   public FactType ()
   {

   }
   private int id;
   /// <summary>
   ///[FactType]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string typeName;
   /// <summary>
   ///[FactType]表 [typeName]列
   /// </summary>
   public string TypeName
   {
     get{ return typeName; }
     set{ this.typeName=value;}
   }
   private string typeremark;
   /// <summary>
   ///[FactType]表 [typeremark]列
   /// </summary>
   public string Typeremark
   {
     get{ return typeremark; }
     set{ this.typeremark=value;}
   }
  }
}
