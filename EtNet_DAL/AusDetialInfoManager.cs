using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EtNet_BLL
{
    public class AusDetialInfoManager
    {
        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(int id)
        {
            return EtNet_DAL.AusDetialInfoService.Exists(id);

        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
        public static bool Add(EtNet_Models.AusDetialInfo model)
        {
            return EtNet_DAL.AusDetialInfoService.Add(model);
        }
       

        /// <summary>
		/// 更新一条数据
		/// </summary>
        public static bool Update(EtNet_Models.AusDetialInfo model)
        {
            return EtNet_DAL.AusDetialInfoService.Update(model);
        }


        /// <summary>
		/// 删除一条数据
		/// </summary>
        public static bool Delete(int id)
        {
            return EtNet_DAL.AusDetialInfoService.Delete(id);

        }

        /// <summary>
        /// 根据报销单关联的工作流的id值，删除数据
        /// </summary>
        /// <param name="ausid">工作流的id值</param>
        public static bool Del(int jobflowid)
        {
           return  EtNet_DAL.AusDetialInfoService.Del(jobflowid);
        }

        /// <summary>
		/// 批量删除数据
		/// </summary>
        public static bool DeleteList(string idlist)
        {
            return EtNet_DAL.AusDetialInfoService.DeleteList(idlist);

        }


        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public static EtNet_Models.AusDetialInfo GetModel(int id)
        {
            return EtNet_DAL.AusDetialInfoService.GetModel(id);
        }

        /// <summary>
        /// 根据指定的jobflowid获得数据列表
		/// </summary>
        public static DataTable GetLists(string jobflowid)
        {
            return EtNet_DAL.AusDetialInfoService.GetLists(jobflowid);
        }

        /// <summary>
		/// 获得前几行数据,指定需要的行数
		/// </summary>
        public static DataTable GetList(int Top)
        {
            return EtNet_DAL.AusDetialInfoService.GetList(Top);
        }

    }
}
