using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class LoginOperationLimit
  {
   //LoginOperationLimit���Ĭ�Ϲ��췽��
   public LoginOperationLimit ()
   {

   }
   private int id;
   /// <summary>
   ///[LoginOperationLimit]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string limitIds;
   /// <summary>
   ///[LoginOperationLimit]�� [limitIds]��
   /// </summary>
   public string LimitIds
   {
     get{ return limitIds; }
     set{ this.limitIds=value;}
   }
   private string limitType;
   /// <summary>
   ///[LoginOperationLimit]�� [limitType]��
   /// </summary>
   public string LimitType
   {
     get{ return limitType; }
     set{ this.limitType=value;}
   }
   private string limitremark;
   /// <summary>
   ///[LoginOperationLimit]�� [limitremark]��
   /// </summary>
   public string Limitremark
   {
     get{ return limitremark; }
     set{ this.limitremark=value;}
   }
  }
}
