using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// NoticeShareManager
	/// </summary>
	public class NoticeShareManager
	{

        public NoticeShareManager()
		{}
		#region  Method

	

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.NoticeShareService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public  static  bool Add(EtNet_Models.NoticeShare model)
		{
            return EtNet_DAL.NoticeShareService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.NoticeShare model)
		{
            return EtNet_DAL.NoticeShareService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.NoticeShareService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.NoticeShareService.DeleteList(idlist);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.NoticeShare GetModel(int id)
		{
            return EtNet_DAL.NoticeShareService.GetModel(id);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.NoticeShareService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.NoticeShareService.GetList(Top, strWhere, filedOrder);
		}


		
		#endregion  Method
	}
}

