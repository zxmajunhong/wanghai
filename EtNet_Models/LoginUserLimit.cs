using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class LoginUserLimit
  {
   //LoginUserLimit���Ĭ�Ϲ��췽��
   public LoginUserLimit ()
   {

   }
   private int limitid;
   /// <summary>
   ///[LoginUserLimit]������
   /// </summary>
   public int Limitid
   {
     get{ return limitid; }
     set{ this.limitid=value;}
   }
   private string loginid;
   /// <summary>
   ///[LoginUserLimit]�� [loginid]��
   /// </summary>
   public string Loginid
   {
     get{ return loginid; }
     set{ this.loginid=value;}
   }
   private Menu nodeid;
   /// <summary>
   ///[LoginUserLimit]�����
   ///ԭ����[nodeid]
   ///ԭ����[int]
   ///������[Menu]
   ///������[nodeid]
   /// </summary>
   public Menu Nodeid
   {
     get{ return nodeid; }
     set{ this.nodeid=value;}
   }
  }
}
