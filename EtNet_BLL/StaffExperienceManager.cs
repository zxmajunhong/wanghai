﻿using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL 
{
	/// <summary>
	/// StaffExperienceManager
	/// </summary>
	public  class StaffExperienceManager
	{
	
		public StaffExperienceManager()
		{}
		#region  Method

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.StaffExperienceService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.StaffExperience model)
		{
            return EtNet_DAL.StaffExperienceService.Add(model);
		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
        public static bool Update(EtNet_Models.StaffExperience model)
		{
            return EtNet_DAL.StaffExperienceService.Update(model);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.StaffExperienceService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.StaffExperienceService.DeleteList(idlist);
		}

        
        /// <summary>
        /// 批量删除,指定筛选条件,条件为空全部删除
        /// </summary>
        public static bool DelList(string strwhere)
        {
            return EtNet_DAL.StaffExperienceService.DelList(strwhere);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.StaffExperience GetModel(int id)
        {
		   return EtNet_DAL.StaffExperienceService.GetModel(id);
		}

		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.StaffExperienceService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.StaffExperienceService.GetList(Top, strWhere, filedOrder);
		}

        

		#endregion  Method
	}
}

