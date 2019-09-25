using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class CusBankManager
  {
     public static int addCusBank(CusBank cusbank)
     {
       return CusBankService.addCusBank(cusbank);
     }

     public static int updateCusBank(CusBank cusbank)
     {
      return CusBankService.updateCusBankById(cusbank);
     }

     public static int deleteCusBank(int id)
     {
       return CusBankService.deleteCusBankById(id);
     }

     public static CusBank getCusBankById(int id)
     {
       return CusBankService.getCusBankById(id);
     }

     public static IList<CusBank> getCusBankAll()
     {
       return CusBankService.getCusBankAll();
     }

     public static IList<CusBank> getCusBankByCusId(int cusId)
     {
         return CusBankService.getCusBankByCusId(cusId);
     }

     public static System.Data.DataTable getList(int id)
     {
         return CusBankService.getList(id);
     }

     public static int deleteCusBankByCusId(int id)
     {
         return CusBankService.deleteCusBankByCusId(id);
     }


  }
}
