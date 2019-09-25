using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL 
{
	/// <summary>
	/// InitializeSetManager
	/// </summary>
	public partial class InitializeSetManager
	{
	
		public InitializeSetManager()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(EtNet_Models.InitializeSet model)
		{
            return  EtNet_DAL.InitializeSetService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.InitializeSet model)
		{
            return EtNet_DAL.InitializeSetService.Update(model);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return  EtNet_DAL.InitializeSetService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return  EtNet_DAL.InitializeSetService.DeleteList(idlist);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static  EtNet_Models.InitializeSet GetModel(int id)
		{
            return  EtNet_DAL.InitializeSetService.GetModel(id);
		}



		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return  EtNet_DAL.InitializeSetService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return  EtNet_DAL.InitializeSetService.GetList(Top, strWhere, filedOrder);
		}



		#endregion  Method
	}
}

