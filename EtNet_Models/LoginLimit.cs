using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class LoginLimit
  {
   //LoginLimit表的默认构造方法
   public LoginLimit ()
   {

   }
   private int limitid;
   /// <summary>
   ///[LoginLimit]表 [limitid]列
   /// </summary>
   public int Limitid
   {
     get{ return limitid; }
     set{ this.limitid=value;}
   }
   private int roleid;
   /// <summary>
   ///[LoginLimit]表 [roleid]列
   /// </summary>
   public int Roleid
   {
     get{ return roleid; }
     set{ this.roleid=value;}
   }
   private int nodeid;
   /// <summary>
   ///[LoginLimit]表 [nodeid]列
   /// </summary>
   public int Nodeid
   {
     get{ return nodeid; }
     set{ this.nodeid=value;}
   }
  }
}
