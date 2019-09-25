using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class Tb_lineManager
  {
     public static int addTb_line(Tb_line tb_line)
     {
       return Tb_lineService.addTb_line(tb_line);
     }

     public static int updateTb_line(Tb_line tb_line)
     {
      return Tb_lineService.updateTb_lineById(tb_line);
     }

     public static int deleteTb_line(int id)
     {
       return Tb_lineService.deleteTb_lineById(id);
     }

     public static Tb_line getTb_lineById(int id)
     {
       return Tb_lineService.getTb_lineById(id);
     }

     public static IList<Tb_line> getTb_lineAll()
     {
       return Tb_lineService.getTb_lineAll();
     }

     public static System.Data.DataTable getList(string sqlwhere)
     {
         return Tb_lineService.getList(sqlwhere);
     }
  }
}
