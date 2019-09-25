using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class RatioManager
  {
     public static int addRatio(Ratio ratio)
     {
       return RatioService.addRatio(ratio);
     }

     public static int updateRatio(Ratio ratio)
     {
      return RatioService.updateRatioById(ratio);
     }

     public static int deleteRatio(int id)
     {
       return RatioService.deleteRatioById(id);
     }

     public static Ratio getRatioById(int id)
     {
       return RatioService.getRatioById(id);
     }

     public static IList<Ratio> getRatioAll()
     {
       return RatioService.getRatioAll();
     }

     public static IList<Ratio> getRatioTop1()
     {
         return RatioService.getTop1();
     }
  }
}
