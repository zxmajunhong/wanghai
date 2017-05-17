using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class CusTypeManager
  {
     public static int addCusType(CusType custype)
     {
       return CusTypeService.addCusType(custype);
     }

     public static int updateCusType(CusType custype)
     {
      return CusTypeService.updateCusTypeById(custype);
     }

     public static int deleteCusType(int id)
     {
       return CusTypeService.deleteCusTypeById(id);
     }

     public static CusType getCusTypeById(int id)
     {
       return CusTypeService.getCusTypeById(id);
     }
     public static int getCusTypeBytypename(string typename)
     {
         return CusTypeService.getCusTypeBytypename(typename);
     }
     public static IList<CusType> getCusTypeAll()
     {
       return CusTypeService.getCusTypeAll();
     }
  }
}
