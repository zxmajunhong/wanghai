using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class BudgetManager
  {
     public static int addBudget(Budget budget)
     {
       return BudgetService.addBudget(budget);
     }

     public static int updateBudget(Budget budget)
     {
      return BudgetService.updateBudgetById(budget);
     }

     public static int deleteBudget(int id)
     {
       return BudgetService.deleteBudgetById(id);
     }

     public static Budget getBudgetById(int id)
     {
       return BudgetService.getBudgetById(id);
     }

     public static IList<Budget> getBudgetAll()
     {
       return BudgetService.getBudgetAll();
     }

     public static bool ExitsPolicy(int policyID)
     {
         return BudgetService.ExitsPolicy(policyID);
     }

     public static int UpdateByPolicy(Budget budget)
     {
         return BudgetService.UpdateByPolicy(budget);
     }

     public static Budget GetBudgetByPolicy(int policyID)
     {
         return BudgetService.GetBudgetByPolicy(policyID);
     }
  }
}
