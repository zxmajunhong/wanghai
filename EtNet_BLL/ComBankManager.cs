using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class ComBankManager
    {
        public static int addComBank(ComBank combank)
        {
            return ComBankService.addComBank(combank);
        }

        public static int updateComBank(ComBank combank)
        {
            return ComBankService.updateComBankById(combank);
        }

        public static int deleteComBank(int id)
        {
            return ComBankService.deleteComBankById(id);
        }

        public static ComBank getComBankById(int id)
        {
            return ComBankService.getComBankById(id);
        }

        public static IList<ComBank> getComBankAll()
        {
            return ComBankService.getComBankAll();
        }

        public static System.Data.DataTable getList(int id)
        {
            return ComBankService.getList(id);
        }

        public static int deleteComBankByComId(int id)
        {
            return ComBankService.deleteComBankByCusId(id);
        }
    }
}
