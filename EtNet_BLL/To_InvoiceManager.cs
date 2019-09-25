using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class To_InvoiceManager
    {
        public static int addTo_Invoice(To_Invoice to_invoice)
        {
            return To_InvoiceService.addTo_Invoice(to_invoice);
        }
        public static int getInvoiceById(int id)
        {
            return To_InvoiceService.getInvoiceById(id);
        }
        public static int updateTo_Invoice(To_Invoice to_invoice)
        {
            return To_InvoiceService.updateTo_InvoiceById(to_invoice);
        }

        public static int deleteTo_Invoice(int id)
        {
            return To_InvoiceService.deleteTo_InvoiceById(id);
        }

        public static To_Invoice getTo_InvoiceById(int id)
        {
            return To_InvoiceService.getTo_InvoiceById(id);
        }

        public static IList<To_Invoice> getTo_InvoiceAll()
        {
            return To_InvoiceService.getTo_InvoiceAll();
        }
        public static To_Invoice getTo_InvoiceLastONE()
        {
            return To_InvoiceService.getTo_InvoiceLastONE();
        }

        public static bool CancelIsSure(int id)
        {
            return To_InvoiceService.CancelIsSure(id);
        }

        public static int Clear()
        {
            return To_InvoiceService.Clear();
        }
        public static DataTable GetUnpaidInvoice()
        {
            return To_InvoiceService.GetUnpaidInvoice();
        }
    }
}
