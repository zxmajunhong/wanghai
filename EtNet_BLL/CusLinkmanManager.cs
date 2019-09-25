using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class CusLinkmanManager
    {
        public static int addCusLinkman(CusLinkman cuslinkman)
        {
            return CusLinkmanService.addCusLinkman(cuslinkman);
        }

        public static int updateCusLinkman(CusLinkman cuslinkman)
        {
            return CusLinkmanService.updateCusLinkmanById(cuslinkman);
        }

        public static int deleteCusLinkman(int id)
        {
            return CusLinkmanService.deleteCusLinkmanById(id);
        }

        /// <summary>
        /// 根据sql语句删除数据
        /// </summary>
        /// <param name="sql"></param>
        public static int deleteCusLinkmanBySql(string sql)
        {
            return CusLinkmanService.deleteCusLinkmanBySql(sql);
        }

        public static CusLinkman getCusLinkmanById(int id)
        {
            return CusLinkmanService.getCusLinkmanById(id);
        }

        public static IList<CusLinkman> getCusLinkmanAll()
        {
            return CusLinkmanService.getCusLinkmanAll();
        }

        public static IList<CusLinkman> getCusLinkmanByCusId(int cusId)
        {
            return CusLinkmanService.getCusLinkmanByCusId(cusId);
        }

        public static DataTable getList(int id)
        {
            return CusLinkmanService.getList(id);
        }

        public static int deleteCusLinkmanByCusId(int id)
        {
            return CusLinkmanService.deleteCusLinkmanByCusId(id);
        }

    }
}
