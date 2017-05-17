using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class RoleInfo
  {
   //RoleInfo表的默认构造方法
   public RoleInfo ()
   {

   }
   private int roleid;
   /// <summary>
   ///[RoleInfo]表主键
   /// </summary>
   public int Roleid
   {
     get{ return roleid; }
     set{ this.roleid=value;}
   }
   private string rolenname;
   /// <summary>
   ///[RoleInfo]表 [rolenname]列
   /// </summary>
   public string Rolenname
   {
     get{ return rolenname; }
     set{ this.rolenname=value;}
   }
   private string remark;
   /// <summary>
   ///[RoleInfo]表 [remark]列
   /// </summary>
   public string Remark
   {
     get{ return remark; }
     set{ this.remark=value;}
   }
  }
}
