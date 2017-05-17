using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class CommissionListManager
  {
     public static int addCommissionList(CommissionList commissionlist)
     {
       return CommissionListService.addCommissionList(commissionlist);
     }

     public static int updateCommissionList(CommissionList commissionlist)
     {
      return CommissionListService.updateCommissionListById(commissionlist);
     }

     public static int deleteCommissionList(int id)
     {
       return CommissionListService.deleteCommissionListById(id);
     }

     public static CommissionList getCommissionListById(int id)
     {
       return CommissionListService.getCommissionListById(id);
     }

     public static IList<CommissionList> getCommissionListAll()
     {
       return CommissionListService.getCommissionListAll();
     }
  }
}
