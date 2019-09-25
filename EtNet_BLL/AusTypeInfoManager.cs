using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;

namespace EtNet_BLL
{
    public class AusTypeInfoManager
    {

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(int id)
        {
           return EtNet_DAL.AusTypeInfoService.Exists(id);
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
        public static bool Add(EtNet_Models.AusTypeInfo model)
        {
            return EtNet_DAL.AusTypeInfoService.Add(model);
          
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
        public static bool Update(EtNet_Models.AusTypeInfo model)
        {
             return  EtNet_DAL.AusTypeInfoService.Update(model);
           
        
        }

        /// <summary>
		/// 删除一条数据
		/// </summary>
        public static bool Delete(int id)
        {
           return EtNet_DAL.AusTypeInfoService.Delete(id);
          
        }

        /// <summary>
		/// 批量删除数据
		/// </summary>
        public static bool DeleteList(string idlist)
        {
          return  EtNet_DAL.AusTypeInfoService.DeleteList(idlist);
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public static EtNet_Models.AusTypeInfo GetModel(int id)
        {
            return EtNet_DAL.AusTypeInfoService.GetModel(id);
            
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.AusTypeInfo GetModelByTypename(string typename)
        {
            return EtNet_DAL.AusTypeInfoService.GetModelByTypename(typename);

        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
        public static DataTable GetList(string strWhere)
        {
            return EtNet_DAL.AusTypeInfoService.GetList(strWhere);
        }

        public static IList<AusTypeInfo> GetAllList()
        {
            return EtNet_DAL.AusTypeInfoService.GetAllList();
        }
        public static IList<AusTypeInfo> getAusRottenInfo(int id)
        {
            return EtNet_DAL.AusTypeInfoService.getAusRottenInfo(id);
        }
        public static EtNet_Models.AusTypeInfo getAusTypesById(int id)
        {
            return EtNet_DAL.AusTypeInfoService.getAusTypesById(id);
        }
    }
}
