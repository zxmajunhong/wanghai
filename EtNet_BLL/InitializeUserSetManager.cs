using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// InitializeUserSetManager
	/// </summary>
	public partial class InitializeUserSetManager
	{
		
		public InitializeUserSetManager()
		{}
		#region  Method

	

	

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(EtNet_Models.InitializeUserSet model)
		{
			return EtNet_DAL.InitializeUserSetService.Add(model);
		} 


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.InitializeUserSet model)
		{
            return  EtNet_DAL.InitializeUserSetService.Update(model);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return  EtNet_DAL.InitializeUserSetService.Delete(id);
		}


         /// <summary>
        /// 删除数据
        /// </summary>
        public static bool Del(string strWhere)
        {
            return  EtNet_DAL.InitializeUserSetService.Del(strWhere);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return  EtNet_DAL.InitializeUserSetService.DeleteList(idlist);
		}



		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static  EtNet_Models.InitializeUserSet GetModel(int id)
		{
            return  EtNet_DAL.InitializeUserSetService.GetModel(id);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return  EtNet_DAL.InitializeUserSetService.GetList(strWhere);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return  EtNet_DAL.InitializeUserSetService.GetList(Top, strWhere, filedOrder);
		}


	

		#endregion  Method
	}
}

