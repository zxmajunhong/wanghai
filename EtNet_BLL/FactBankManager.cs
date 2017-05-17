using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using System.Data;
using EtNet_Models;
namespace EtNet_BLL
{


    public class FactBankManager
    {
        public static int addFactBank(FactBank factbank)
        {
            return FactBankService.addFactBank(factbank);
        }

        public static int updateFactBank(FactBank factbank)
        {
            return FactBankService.updateFactBankById(factbank);
        }

        public static int deleteFactBank(int id)
        {
            return FactBankService.deleteFactBankById(id);
        }

        public static FactBank getFactBankById(int id)
        {
            return FactBankService.getFactBankById(id);
        }

        public static IList<FactBank> getFactBankAll()
        {
            return FactBankService.getFactBankAll();
        }

        public static DataTable getList(int id)
        {
            return FactBankService.getList(id);
        }

        public static int deleteFactBankByfactId(int id)
        {
            return FactBankService.deleteFactBankByfactId(id);
        }

        public static IList<FactBank> getFactBankByFacrId(int factId)
        {
            return FactBankService.getFactBankByFacrId(factId);
        }
    }
}
