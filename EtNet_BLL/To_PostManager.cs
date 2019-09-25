using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class To_PostManager
  {
     public static int addTo_Post(To_Post to_post)
     {
       return To_PostService.addTo_Post(to_post);
     }

     public static int updateTo_Post(To_Post to_post)
     {
      return To_PostService.updateTo_PostById(to_post);
     }

     public static int deleteTo_Post(int id)
     {
       return To_PostService.deleteTo_PostById(id);
     }

     public static To_Post getTo_PostById(int id)
     {
       return To_PostService.getTo_PostById(id);
     }

     public static IList<To_Post> getTo_PostAll()
     {
       return To_PostService.getTo_PostAll();
     }
     public static int getLoginInfoByPostname(string postname)
     {
         return To_PostService.getLoginInfoByPostname(postname);
     }
  }
}
