using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class LoginLimit
  {
   //LoginLimit���Ĭ�Ϲ��췽��
   public LoginLimit ()
   {

   }
   private int limitid;
   /// <summary>
   ///[LoginLimit]�� [limitid]��
   /// </summary>
   public int Limitid
   {
     get{ return limitid; }
     set{ this.limitid=value;}
   }
   private int roleid;
   /// <summary>
   ///[LoginLimit]�� [roleid]��
   /// </summary>
   public int Roleid
   {
     get{ return roleid; }
     set{ this.roleid=value;}
   }
   private int nodeid;
   /// <summary>
   ///[LoginLimit]�� [nodeid]��
   /// </summary>
   public int Nodeid
   {
     get{ return nodeid; }
     set{ this.nodeid=value;}
   }
  }
}
