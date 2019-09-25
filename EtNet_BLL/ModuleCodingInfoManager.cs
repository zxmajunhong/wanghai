using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// ModuleCodingInfoManager
	/// </summary>
	public partial class ModuleCodingInfoManager
	{
		
		public ModuleCodingInfoManager()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public  static bool Exists(int id)
		{
			return  EtNet_DAL.ModuleCodingInfoService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.ModuleCodingInfo model)
		{
            return EtNet_DAL.ModuleCodingInfoService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public static bool Update(EtNet_Models.ModuleCodingInfo model)
		{
            return EtNet_DAL.ModuleCodingInfoService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.ModuleCodingInfoService.Delete(id);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.ModuleCodingInfoService.DeleteList(idlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static  EtNet_Models.ModuleCodingInfo GetModel(int id)
		{
            return EtNet_DAL.ModuleCodingInfoService.GetModel(id);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.ModuleCodingInfoService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.ModuleCodingInfoService.GetList(Top, strWhere, filedOrder);
		}

		#endregion  Method
	}
}

