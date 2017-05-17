using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


  public class To_InvoiceDetialManager
  {
     public static int addTo_InvoiceDetial(To_InvoiceDetial to_invoicedetial)
     {
       return To_InvoiceDetialService.addTo_InvoiceDetial(to_invoicedetial);
     }

     public static int updateTo_InvoiceDetial(To_InvoiceDetial to_invoicedetial)
     {
      return To_InvoiceDetialService.updateTo_InvoiceDetialById(to_invoicedetial);
     }

     public static int deleteTo_InvoiceDetial(int id)
     {
       return To_InvoiceDetialService.deleteTo_InvoiceDetialById(id);
     }

     public static To_InvoiceDetial getTo_InvoiceDetialById(int id)
     {
       return To_InvoiceDetialService.getTo_InvoiceDetialById(id);
     }

     public static IList<To_InvoiceDetial> getTo_InvoiceDetialAll()
     {
       return To_InvoiceDetialService.getTo_InvoiceDetialAll();
     }

     public static IList<To_InvoiceDetial> getTo_InvoiceDetialByInvoiceId(string invoiceID)
     {
         return To_InvoiceDetialService.getTo_InvoiceDetialByInvoiceId(invoiceID); ;
     }

     public static System.Data.DataTable getList(int id)
     {
         return To_InvoiceDetialService.getList(id);
     }

     public static int deleteTo_InvoiceDetialByInvoiceID(int id)
     {
         return To_InvoiceDetialService.deleteTo_InvoiceDetialByInvoiceId(id);
     }
  }
}
