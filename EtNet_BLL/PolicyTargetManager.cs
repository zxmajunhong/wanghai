using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class PolicyTargetManager
  {
     public static int addPolicyTarget(PolicyTarget policytarget)
     {
       return PolicyTargetService.addPolicyTarget(policytarget);
     }

     public static int updatePolicyTarget(PolicyTarget policytarget)
     {
      return PolicyTargetService.updatePolicyTargetById(policytarget);
     }

     public static int deletePolicyTarget(int id)
     {
       return PolicyTargetService.deletePolicyTargetById(id);
     }

     public static PolicyTarget getPolicyTargetById(int id)
     {
       return PolicyTargetService.getPolicyTargetById(id);
     }

     public static IList<PolicyTarget> getPolicyTargetAll()
     {
       return PolicyTargetService.getPolicyTargetAll();
     }

     public static int DeleteByPolicy(int policyID)
     {
         return PolicyTargetService.DeleteByPolicy(policyID);
     }

     public static IList<PolicyTarget> GetListByPolicy(int policyID)
     {
         return PolicyTargetService.GetListByPolicy(policyID);
     }
  }
}
