using System;
using System.Data;
using System.Collections.Generic;


namespace EtNet_BLL
{
	/// <summary>
    /// PanelMenuRecordManager
	/// </summary>
	public partial class PanelMenuRecordManager
	{

        public PanelMenuRecordManager()
		{}
		#region  Method

	

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.PanelMenuRecordService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public  static bool Add(EtNet_Models.PanelMenuRecord model)
		{
            return EtNet_DAL.PanelMenuRecordService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.PanelMenuRecord model)
		{
            return EtNet_DAL.PanelMenuRecordService.Update(model);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.PanelMenuRecordService.Delete(id);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.PanelMenuRecordService.DeleteList(idlist);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static  EtNet_Models.PanelMenuRecord GetModel(int id)
		{
            return EtNet_DAL.PanelMenuRecordService.GetModel(id);
		}


		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.PanelMenuRecordService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.PanelMenuRecordService.GetList(Top, strWhere, filedOrder);
		}
		
		

		#endregion  Method
	}
}

