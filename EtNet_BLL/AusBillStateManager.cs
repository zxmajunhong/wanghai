using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// AusBillState
	/// </summary>
	public partial class AusBillStateManager
	{

        public AusBillStateManager()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public  static bool Add(EtNet_Models.AusBillState model)
		{
		   return EtNet_DAL.AusBillStateService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.AusBillState model)
		{
            return EtNet_DAL.AusBillStateService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{	
            return EtNet_DAL.AusBillStateService.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  static EtNet_Models.AusBillState GetModel(int id)
		{	
            return EtNet_DAL.AusBillStateService.GetModel(id);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.AusBillStateService.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.AusBillStateService.GetList(Top, strWhere, filedOrder);
		}
	
	

		#endregion  Method
	}
}

