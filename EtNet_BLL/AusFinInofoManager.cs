using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
using EtNet_DAL;

namespace EtNet_BLL
{
    public class AusFinInfoManager
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exists(int id)
        {
            return AusFinInfoService.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(AusFinInfo model)
        {
            return AusFinInfoService.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(AusFinInfo model)
        {
            return AusFinInfoService.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return AusFinInfoService.Delete(id);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public static bool DeleteList(string idlist)
        {
            return AusFinInfoService.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AusFinInfo GetModel(int id)
        {
            return AusFinInfoService.GetModel(id);
        }

        public static AusFinInfo GetModelByName(string name)
        {
            return AusFinInfoService.GetModelByName(name);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            return EtNet_DAL.AusFinInfoService.GetList(strWhere);
        }
    }
}
