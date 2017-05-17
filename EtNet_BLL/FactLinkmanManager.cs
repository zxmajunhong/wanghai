using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using System.Data;
using EtNet_Models;
namespace EtNet_BLL
{


  public class FactLinkmanManager
  {
     public static int addFactLinkman(FactLinkman factlinkman)
     {
       return FactLinkmanService.addFactLinkman(factlinkman);
     }

     public static int updateFactLinkman(FactLinkman factlinkman)
     {
      return FactLinkmanService.updateFactLinkmanById(factlinkman);
     }

     public static int deleteFactLinkman(int id)
     {
       return FactLinkmanService.deleteFactLinkmanById(id);
     }

     public static FactLinkman getFactLinkmanById(int id)
     {
       return FactLinkmanService.getFactLinkmanById(id);
     }

     public static IList<FactLinkman> getFactLinkmanAll()
     {
       return FactLinkmanService.getFactLinkmanAll();
     }

     public static DataTable getList(int id)
     {
         return FactLinkmanService.getList(id);
     }

     public static int deleteFactLinkmanByfactId(int id)
     {
         return FactLinkmanService.deleteFactLinkmanByfactId(id);
     }

     public static IList<FactLinkman> getFactLinkmanByFactId(int factId)
     {
         return FactLinkmanService.getFactLinkmanByFactId(factId);
     }
  }
}
