using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class CusType
  {
   //CusType���Ĭ�Ϲ��췽��
   public CusType ()
   {

   }
   private int id;
   /// <summary>
   ///[CusType]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string typeName;
   /// <summary>
   ///[CusType]�� [typeName]��
   /// </summary>
   public string TypeName
   {
     get{ return typeName; }
     set{ this.typeName=value;}
   }
   private string typeremark;
   /// <summary>
   ///[CusType]�� [typeremark]��
   /// </summary>
   public string Typeremark
   {
     get{ return typeremark; }
     set{ this.typeremark=value;}
   }
  }
}
