using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class FactTypeManager
  {
     public static int addFactType(FactType facttype)
     {
       return FactTypeService.addFactType(facttype);
     }

     public static int updateFactType(FactType facttype)
     {
      return FactTypeService.updateFactTypeById(facttype);
     }

     public static int deleteFactType(int id)
     {
       return FactTypeService.deleteFactTypeById(id);
     }

     public static FactType getFactTypeById(int id)
     {
       return FactTypeService.getFactTypeById(id);
     }

     public static IList<FactType> getFactTypeAll()
     {
       return FactTypeService.getFactTypeAll();
     }

     public static int getFactTypeBytypename(string typename)
     {
         return FactTypeService.getFactTypeBytypename(typename);
     }
  }
}
