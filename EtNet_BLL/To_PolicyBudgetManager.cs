using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class To_PolicyBudgetManager
  {
     public static int addBudget(To_PolicyBudget budget)
     {
       return To_PolicyBudgetService.addBudget(budget);
     }

     public static int updateBudget(To_PolicyBudget budget)   
     {
      return To_PolicyBudgetService.updateBudgetById(budget);
     }

     public static int deleteBudget(int id)
     {
       return To_PolicyBudgetService.deleteBudgetById(id);
     }

     public static To_PolicyBudget getBudgetById(int id)
     {
       return To_PolicyBudgetService.getBudgetById(id);
     }

     public static IList<To_PolicyBudget> getBudgetAll()
     {
       return To_PolicyBudgetService.getBudgetAll();
     }

     public static bool ExitsPolicy(int policyID)
     {
         return To_PolicyBudgetService.ExitsPolicy(policyID);
     }

     public static int UpdateByPolicy(To_PolicyBudget budget)
     {
         return To_PolicyBudgetService.UpdateByPolicy(budget);
     }

     public static To_PolicyBudget GetBudgetByPolicy(int policyID)
     {
         return To_PolicyBudgetService.GetBudgetByPolicy(policyID);
     }
  }
}
