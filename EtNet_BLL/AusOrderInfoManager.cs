using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_BLL
{
    public class AusOrderInfoManager
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exists(int id)
        {
            return EtNet_DAL.AusOrderInfoService.Exists(id);
        }

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(EtNet_Models.AusOrderInfo model)
        {
            return EtNet_DAL.AusOrderInfoService.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(EtNet_Models.AusOrderInfo model)
        {
            return EtNet_DAL.AusOrderInfoService.Update(model);
        }

        /// <summary>
        /// 根据id值删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return EtNet_DAL.AusOrderInfoService.Delete(id);
        }

        /// <summary>
        /// 根据工作流id删除报销订单信息数据
        /// </summary>
        /// <param name="jobflowid"></param>
        /// <returns></returns>
        public static bool Del(int jobflowid)
        {
            return EtNet_DAL.AusOrderInfoService.Del(jobflowid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EtNet_Models.AusOrderInfo GetModel(int id)
        {
            return EtNet_DAL.AusOrderInfoService.GetModel(id);
        }

        /// <summary>
        /// 根据工作流id得到报销订单信息表
        /// </summary>
        /// <param name="jobflowId"></param>
        /// <returns></returns>
        public static DataTable GetList(string jobflowId)
        {
            return EtNet_DAL.AusOrderInfoService.GetList(jobflowId);
        }

        public static DataTable GetListBysql(string strWhere)
        {
            return EtNet_DAL.AusOrderInfoService.GetListBysql(strWhere);  
        }
    }
}
