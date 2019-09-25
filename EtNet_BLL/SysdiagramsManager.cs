using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class SysdiagramsManager
  {
     public static int addSysdiagrams(Sysdiagrams sysdiagrams)
     {
       return SysdiagramsService.addSysdiagrams(sysdiagrams);
     }

     public static int updateSysdiagrams(Sysdiagrams sysdiagrams)
     {
      return SysdiagramsService.updateSysdiagramsById(sysdiagrams);
     }

     public static int deleteSysdiagrams(int diagram_id)
     {
       return SysdiagramsService.deleteSysdiagramsById(diagram_id);
     }

     public static Sysdiagrams getSysdiagramsById(int diagram_id)
     {
       return SysdiagramsService.getSysdiagramsById(diagram_id);
     }

     public static IList<Sysdiagrams> getSysdiagramsAll()
     {
       return SysdiagramsService.getSysdiagramsAll();
     }
  }
}
