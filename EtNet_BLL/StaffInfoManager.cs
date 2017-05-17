using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL 
{
	/// <summary>
	/// StaffInfoManager
	/// </summary>
	public class StaffInfoManager
	{
		
		public StaffInfoManager()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID,排序是按id值倒序
		/// </summary>
		public static int GetId(string strwhere)
		{
            return EtNet_DAL.StaffInfoService.GetId(strwhere);
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public  static bool Exists(int id)
		{
            return EtNet_DAL.StaffInfoService.Exists(id);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add( EtNet_Models.StaffInfo model)
		{
            return EtNet_DAL.StaffInfoService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update( EtNet_Models.StaffInfo model)
		{
            return EtNet_DAL.StaffInfoService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.StaffInfoService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.StaffInfoService.DeleteList(idlist);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.StaffInfo GetModel(int id)
		{
            return EtNet_DAL.StaffInfoService.GetModel(id);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static  DataTable GetList(string strWhere)
		{
            return EtNet_DAL.StaffInfoService.GetList(strWhere);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.StaffInfoService.GetList(Top, strWhere, filedOrder);
		}


		#endregion  Method

	}
}

