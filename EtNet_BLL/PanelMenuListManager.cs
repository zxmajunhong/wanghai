using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;


namespace EtNet_BLL 
{
	//PanelMenuListManager
	public partial class PanelMenuListManager
	{


        public PanelMenuListManager()
		{}
		
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.PanelMenuListService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.PanelMenuList model)
		{
            return EtNet_DAL.PanelMenuListService.Add(model);
		}



		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.PanelMenuList model)
		{
            return EtNet_DAL.PanelMenuListService.Update(model);
		}



		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.PanelMenuListService.Delete(id);
		}


	    /// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.PanelMenuListService.DeleteList(idlist);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.PanelMenuList GetModel(int id)
		{
            return EtNet_DAL.PanelMenuListService.GetModel(id);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.PanelMenuListService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.PanelMenuListService.GetList(Top, strWhere, filedOrder);
		}


    #endregion
   
	}
}