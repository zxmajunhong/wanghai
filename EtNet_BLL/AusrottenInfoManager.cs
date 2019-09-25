using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EtNet_BLL
{
	/// <summary>
	/// AusRottenInfo
	/// </summary>
	public class AusRottenInfoManager
	{
		
        public AusRottenInfoManager()
		{}
		#region  Method

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.AusRottenInfoService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool  Add(EtNet_Models.AusRottenInfo model)
		{
            return EtNet_DAL.AusRottenInfoService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update( EtNet_Models.AusRottenInfo model)
		{
            return EtNet_DAL.AusRottenInfoService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.AusRottenInfoService.Delete(id);
		}

		/// <summary>
		/// 删除多条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.AusRottenInfoService.DeleteList(idlist);
		}

        /// <summary>
        /// 依据指定的条件删除数据
        /// </summary>
        public static bool Del(string strWhere)
        {
            return EtNet_DAL.AusRottenInfoService.Del(strWhere);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.AusRottenInfo GetModel(int id)
		{

            return EtNet_DAL.AusRottenInfoService.GetModel(id);
		}

        /// <summary>
        /// 根据工作流id得到对象实体
        /// </summary>
        /// <param name="jobflowid"></param>
        /// <returns></returns>
        public static EtNet_Models.AusRottenInfo GetModelByjob(int jobflowid)
        {
            return EtNet_DAL.AusRottenInfoService.GetModelByjob(jobflowid);
        }

		

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.AusRottenInfoService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.AusRottenInfoService.GetList(Top, strWhere, filedOrder);
		}

	
		
		

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method

        public static int Clear()
        {
            return EtNet_DAL.AusRottenInfoService.Clear();
        }

        public static DataTable GetViewList(string sqlwhere)
        {
            return EtNet_DAL.AusRottenInfoService.GetViewList(sqlwhere);
        }
    }
}

