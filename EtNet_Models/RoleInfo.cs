using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class RoleInfo
  {
   //RoleInfo���Ĭ�Ϲ��췽��
   public RoleInfo ()
   {

   }
   private int roleid;
   /// <summary>
   ///[RoleInfo]������
   /// </summary>
   public int Roleid
   {
     get{ return roleid; }
     set{ this.roleid=value;}
   }
   private string rolenname;
   /// <summary>
   ///[RoleInfo]�� [rolenname]��
   /// </summary>
   public string Rolenname
   {
     get{ return rolenname; }
     set{ this.rolenname=value;}
   }
   private string remark;
   /// <summary>
   ///[RoleInfo]�� [remark]��
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
  }
}
