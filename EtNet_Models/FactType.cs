using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class FactType
  {
   //FactType���Ĭ�Ϲ��췽��
   public FactType ()
   {

   }
   private int id;
   /// <summary>
   ///[FactType]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string typeName;
   /// <summary>
   ///[FactType]�� [typeName]��
   /// </summary>
   public string TypeName
   {
     get{ return typeName; }
     set{ this.typeName=value;}
   }
   private string typeremark;
   /// <summary>
   ///[FactType]�� [typeremark]��
   /// </summary>
   public string Typeremark
   {
     get{ return typeremark; }
     set{ this.typeremark=value;}
   }
  }
}
