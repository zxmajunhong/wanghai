using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class ParameterManager
  {
     public static int addParameter(Parameter parameter)
     {
       return ParameterService.addParameter(parameter);
     }

     public static int updateParameter(Parameter parameter)
     {
      return ParameterService.updateParameterById(parameter);
     }

     public static int deleteParameter(int id)
     {
       return ParameterService.deleteParameterById(id);
     }

     public static Parameter getParameterById(int id)
     {
       return ParameterService.getParameterById(id);
     }

     public static IList<Parameter> getParameterAll()
     {
       return ParameterService.getParameterAll();
     }
  }
}
