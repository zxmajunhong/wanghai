using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class LoginOperationLimit
  {
   //LoginOperationLimit表的默认构造方法
   public LoginOperationLimit ()
   {

   }
   private int id;
   /// <summary>
   ///[LoginOperationLimit]表主键
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string limitIds;
   /// <summary>
   ///[LoginOperationLimit]表 [limitIds]列
   /// </summary>
   public string LimitIds
   {
     get{ return limitIds; }
     set{ this.limitIds=value;}
   }
   private string limitType;
   /// <summary>
   ///[LoginOperationLimit]表 [limitType]列
   /// </summary>
   public string LimitType
   {
     get{ return limitType; }
     set{ this.limitType=value;}
   }
   private string limitremark;
   /// <summary>
   ///[LoginOperationLimit]表 [limitremark]列
   /// </summary>
   public string Limitremark
   {
     get{ return limitremark; }
     set{ this.limitremark=value;}
   }
  }
}
