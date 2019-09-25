using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// FirmInfoManager
	/// </summary>
	public class FirmInfoManager
	{
		
		public FirmInfoManager()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			return EtNet_DAL.FirmInfoService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据,取id值
		/// </summary>
		public static int Add( EtNet_Models.FirmInfo model)
		{
            return EtNet_DAL.FirmInfoService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update( EtNet_Models.FirmInfo model)
		{
            return EtNet_DAL.FirmInfoService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.FirmInfoService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
			 return EtNet_DAL.FirmInfoService.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  static EtNet_Models.FirmInfo GetModel(int id)
		{
            return EtNet_DAL.FirmInfoService.GetModel(id);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.FirmInfoService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.FirmInfoService.GetList(Top, strWhere, filedOrder);
		}

	
		#endregion  Method
	}
}

