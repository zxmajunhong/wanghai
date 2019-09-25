using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// StaffPapersSortManager
	/// </summary>
	public  class StaffPapersSortManager
	{
		
		public StaffPapersSortManager()
		{}
		#region  Method

	
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.StaffPapersSortService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.StaffPapersSort model)
		{
			return EtNet_DAL.StaffPapersSortService.Add(model);
		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
        public static bool Update(EtNet_Models.StaffPapersSort model)
		{
            return EtNet_DAL.StaffPapersSortService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.StaffPapersSortService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.StaffPapersSortService.DeleteList(idlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.StaffPapersSort GetModel(int id)
		{
            return EtNet_DAL.StaffPapersSortService.GetModel(id);
		}

		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.StaffPapersSortService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.StaffPapersSortService.GetList(Top, strWhere, filedOrder);
		}
	
		#endregion  Method
	}
}

