using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class ComType
  {
   //ComType���Ĭ�Ϲ��췽��
   public ComType ()
   {

   }
   private int id;
   /// <summary>
   ///[ComType]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string typeName;
   /// <summary>
   ///[ComType]�� [typeName]��
   /// </summary>
   public string TypeName
   {
     get{ return typeName; }
     set{ this.typeName=value;}
   }
   private string typeremark;
   /// <summary>
   ///[ComType]�� [typeremark]��
   /// </summary>
   public string Typeremark
   {
     get{ return typeremark; }
     set{ this.typeremark=value;}
   }
  }
}
