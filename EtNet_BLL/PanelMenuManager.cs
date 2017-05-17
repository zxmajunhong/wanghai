using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
    /// PanelMenuManager
	/// </summary>
	public partial class PanelMenuManager
	{

        public PanelMenuManager()
		{}
		#region  Method


        /// <summary>
        /// 返回最大的id值
        /// </summary>
        public static int MaxId()
        {
            return EtNet_DAL.PanelMenuService.MaxId();
        }




		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.PanelMenuService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool  Add(EtNet_Models.PanelMenu model)
		{
            return EtNet_DAL.PanelMenuService.Add(model);
		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.PanelMenu model)
		{
            return EtNet_DAL.PanelMenuService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.PanelMenuService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.PanelMenuService.DeleteList(idlist);
		}

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public static bool Del(string strWhere)
        {
            return  EtNet_DAL.PanelMenuService.Del(strWhere);
        }



		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.PanelMenu GetModel(int id)
		{
            return EtNet_DAL.PanelMenuService.GetModel(id);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.PanelMenuService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.PanelMenuService.GetList(Top, strWhere, filedOrder);
		}
	
	

		#endregion  Method
	}
}

