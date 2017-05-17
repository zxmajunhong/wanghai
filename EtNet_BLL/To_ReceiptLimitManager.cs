using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_DAL;
using System.Data.SqlClient;

namespace EtNet_BLL
{
    public class To_ReceiptLimitManager
    {
        public static bool AddLimit(IEnumerable<string> userList, string receiptID)
        {
            try
            {
                foreach (string userID in userList)
                {
                    To_ReceiptLimitService.AddLimit(userID, receiptID);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static string GetReceiptList(int userID)
        {
            return To_ReceiptLimitService.GetReceiptList(userID);
        }
    }
}
