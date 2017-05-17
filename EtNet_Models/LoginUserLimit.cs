using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class LoginUserLimit
  {
   //LoginUserLimit表的默认构造方法
   public LoginUserLimit ()
   {

   }
   private int limitid;
   /// <summary>
   ///[LoginUserLimit]表主键
   /// </summary>
   public int Limitid
   {
     get{ return limitid; }
     set{ this.limitid=value;}
   }
   private string loginid;
   /// <summary>
   ///[LoginUserLimit]表 [loginid]列
   /// </summary>
   public string Loginid
   {
     get{ return loginid; }
     set{ this.loginid=value;}
   }
   private Menu nodeid;
   /// <summary>
   ///[LoginUserLimit]表外键
   ///原列名[nodeid]
   ///原类型[int]
   ///主键表[Menu]
   ///关联列[nodeid]
   /// </summary>
   public Menu Nodeid
   {
     get{ return nodeid; }
     set{ this.nodeid=value;}
   }
  }
}
