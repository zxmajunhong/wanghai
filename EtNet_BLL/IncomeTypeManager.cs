using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using EtNet_DAL;
using System.Data;

namespace EtNet_BLL
{
    public class IncomeTypeManager
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Add(IncomeType type)
        {
            return IncomeTypeService.Add(type);
        }

        /// <summary>
        /// 根据名称得到实例
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IncomeType GetModelByName(string name)
        {
            return IncomeTypeService.GetModelByName(name);
        }

        /// <summary>
        /// 根据id得到实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IncomeType GetModel(int id)
        {
            return IncomeTypeService.GetModel(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(IncomeType model)
        {
            return IncomeTypeService.Update(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return IncomeTypeService.Delete(id);
        }

        public static DataTable GetList(string strWhere)
        {
            return IncomeTypeService.GetList(strWhere);
        }
    }
}
