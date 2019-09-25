using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class To_PolicyTargetManager
  {
     public static int addTo_PolicyTarget(To_PolicyTarget To_PolicyTarget)
     {
       return To_PolicyTargetService.addTo_PolicyTarget(To_PolicyTarget);
     }

     public static int updateTo_PolicyTarget(To_PolicyTarget To_PolicyTarget)
     {
      return To_PolicyTargetService.updateTo_PolicyTargetById(To_PolicyTarget);
     }

     public static int deleteTo_PolicyTarget(int id)
     {
       return To_PolicyTargetService.deleteTo_PolicyTargetById(id);
     }

     public static To_PolicyTarget getTo_PolicyTargetById(int id)
     {
       return To_PolicyTargetService.getTo_PolicyTargetById(id);
     }

     public static IList<To_PolicyTarget> getTo_PolicyTargetAll()
     {
       return To_PolicyTargetService.getTo_PolicyTargetAll();
     }

     public static int DeleteByPolicy(int policyID)
     {
         return To_PolicyTargetService.DeleteByPolicy(policyID);
     }

     public static IList<To_PolicyTarget> GetListByPolicy(int policyID)
     {
         return To_PolicyTargetService.GetListByPolicy(policyID);
     }
  }
}
