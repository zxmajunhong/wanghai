using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// StaffLanguageLevelManager
	/// </summary>
	public class StaffLanguageLevelManager
	{
		
		public StaffLanguageLevelManager()
		{}
		#region  Method

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.StaffLanguageLevelService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add( EtNet_Models.StaffLanguageLevel model)
		{
            return EtNet_DAL.StaffLanguageLevelService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update( EtNet_Models.StaffLanguageLevel model)
		{
            return EtNet_DAL.StaffLanguageLevelService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.StaffLanguageLevelService.Delete(id);
		}



		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.StaffLanguageLevelService.DeleteList(idlist);
		}

         /// <summary>
        /// 批量删除数据,指定筛选条件，筛选条件为空删除全部数据
        /// </summary>
        public static bool DelList(string strwhere)
        {
            return EtNet_DAL.StaffLanguageLevelService.DelList(strwhere);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static  EtNet_Models.StaffLanguageLevel GetModel(int id)
		{
            return EtNet_DAL.StaffLanguageLevelService.GetModel(id);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.StaffLanguageLevelService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.StaffLanguageLevelService.GetList(Top, strWhere, filedOrder);
		}


		#endregion  Method

	}
}

