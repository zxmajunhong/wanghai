using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EtNet_Models;
using EtNet_DAL;

namespace EtNet_BLL
{
    public class To_IncomeManager
    {
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="income"></param>
        /// <returns></returns>
        public static int Add(To_Income income)
        {
           return To_IncomeService.Add(income);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetList(string strWhere)
        {
            return To_IncomeService.GetList(strWhere);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            return To_IncomeService.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static To_Income GetModel(string id)
        {
            return To_IncomeService.GetModel(id);
        }

        public static int Update(To_Income income)
        {
            return To_IncomeService.Update(income);
        }
    }
}
