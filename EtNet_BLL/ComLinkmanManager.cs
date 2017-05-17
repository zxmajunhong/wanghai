using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class ComLinkmanManager
    {
        public static int addComLinkman(ComLinkman comlinkman)
        {
            return ComLinkmanService.addComLinkman(comlinkman);
        }

        public static int updateComLinkman(ComLinkman comlinkman)
        {
            return ComLinkmanService.updateComLinkmanById(comlinkman);
        }

        public static int deleteComLinkman(int id)
        {
            return ComLinkmanService.deleteComLinkmanById(id);
        }

        public static ComLinkman getComLinkmanById(int id)
        {
            return ComLinkmanService.getComLinkmanById(id);
        }

        public static IList<ComLinkman> getComLinkmanAll()
        {
            return ComLinkmanService.getComLinkmanAll();
        }

        public static System.Data.DataTable getList(int id)
        {
            return ComLinkmanService.getList(id);
        }

        public static int deleteComLinkmanByComId(int id)
        {
            return ComLinkmanService.deleteComLinkmanByComId(id);
        }
    }
}
