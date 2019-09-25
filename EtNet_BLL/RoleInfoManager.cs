using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class RoleInfoManager
  {
     public static int addRoleInfo(RoleInfo roleinfo)
     {
       return RoleInfoService.addRoleInfo(roleinfo);
     }

     public static int updateRoleInfo(RoleInfo roleinfo)
     {
      return RoleInfoService.updateRoleInfoById(roleinfo);
     }

     public static int deleteRoleInfo(int roleid)
     {
       return RoleInfoService.deleteRoleInfoById(roleid);
     }

     public static RoleInfo getRoleInfoById(int roleid)
     {
       return RoleInfoService.getRoleInfoById(roleid);
     }

     public static IList<RoleInfo> getRoleInfoAll()
     {
       return RoleInfoService.getRoleInfoAll();
     }

      /// <summary>
      /// ��ӽ�ɫ����ȡID
      /// </summary>
      /// <param name="roleInfo"></param>
      /// <returns>��ɫID</returns>
     public static int AddRole(RoleInfo roleInfo)
     {
         return RoleInfoService.AddRole(roleInfo);
     }
  }
}
