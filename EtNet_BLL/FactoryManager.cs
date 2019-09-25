using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class FactoryManager
    {
        public static int addFactory(Factory factory)
        {
            return FactoryService.addFactory(factory);
        }

        public static int updateFactory(Factory factory)
        {
            return FactoryService.updateFactoryById(factory);
        }

        public static int deleteFactory(int id)
        {
            return FactoryService.deleteFactoryById(id);
        }

        public static Factory getFactoryById(int id)
        {
            return FactoryService.getFactoryById(id);
        }

        public static IList<Factory> getFactoryAll()
        {
            return FactoryService.getFactoryAll();
        }

        public static System.Data.DataTable getList(string strsql)
        {
            return FactoryService.GetList(strsql);
        }

        public static System.Data.DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return FactoryService.GetList(Top, strWhere, filedOrder);
        }

        public static bool getSName(string factshortname, int num)
        {
            return FactoryService.getSName(factshortname, num);
        }

        public static bool getCName(string factCName, int num)
        {
            return FactoryService.getCName(factCName, num);
        }

        public static Factory getLastOneID()
        {
            return FactoryService.getLastOneID();
        }
        public static IList<Factory> getFactoryType(int id)
        {
            return FactoryService.getFactoryType(id);
        }

        public static int GetTotalCount(string where)
        {
            return FactoryService.GetTotalCount(where);
        }

        public static object GetListByPage(string where, int s, int e)
        {
            return FactoryService.GetListByPage(where,s,e);
        }

        /// <summary>
        /// 得到做过付款申请并且付款申请审核通过的单位信息
        /// </summary>
        /// <returns></returns>
        public static DataTable getFactoryWhichHasPayment()
        {
            return FactoryService.getFactoryWhichHasPayment();
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public static int Clear()
        {
            return FactoryService.Clear();
        }
    }
}
