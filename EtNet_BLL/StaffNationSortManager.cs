using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// StaffNationSortManager
	/// </summary>
	public class StaffNationSortManager
	{
	
		public StaffNationSortManager()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.StaffNationSortService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add( EtNet_Models.StaffNationSort model)
		{
            return EtNet_DAL.StaffNationSortService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.StaffNationSort model)
		{
            return EtNet_DAL.StaffNationSortService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.StaffNationSortService.Delete(id);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.StaffNationSortService.DeleteList(idlist);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static  EtNet_Models.StaffNationSort GetModel(int id)
		{
            return EtNet_DAL.StaffNationSortService.GetModel(id);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.StaffNationSortService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.StaffNationSortService.GetList(Top, strWhere, filedOrder);
		}


		#endregion  Method


	}
}

