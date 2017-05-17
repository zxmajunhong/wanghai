using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
using EtNet_DAL;

namespace EtNet_BLL
{
    public class AusItemInfoManager
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exists(int id)
        {
            return AusItemInfoService.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(AusItemInfo model)
        {
            return AusItemInfoService.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(AusItemInfo model)
        {
            return AusItemInfoService.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return AusItemInfoService.Delete(id);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public static bool DeleteList(string idlist)
        {
            return AusItemInfoService.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AusItemInfo GetModel(int id)
        {
            return AusItemInfoService.GetModel(id);
        }

        public static AusItemInfo GetModelByName(string name)
        {
            return AusItemInfoService.GetModelByName(name);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            return EtNet_DAL.AusItemInfoService.GetList(strWhere);
        }
    }
}
