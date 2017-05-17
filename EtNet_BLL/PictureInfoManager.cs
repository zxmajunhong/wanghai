using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// PictureInfoManager
	/// </summary>
	public partial class PictureInfoManager
	{
		
		public PictureInfoManager()
		{}
		#region  Method

		
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.PictureInfoService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.PictureInfo model)
		{
            return EtNet_DAL.PictureInfoService.Add(model);
		}



		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.PictureInfo model)
		{
            return EtNet_DAL.PictureInfoService.Update(model);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.PictureInfoService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.PictureInfoService.DeleteList(idlist);
		}

        /// <summary>
        /// 依据条件,默认删除全部数据
        /// </summary>
        public static bool DelList(string strwhere)
        {
            return EtNet_DAL.PictureInfoService.DelList(strwhere);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.PictureInfo GetModel(int id)
		{
            return EtNet_DAL.PictureInfoService.GetModel(id);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public  static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.PictureInfoService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.PictureInfoService.GetList(Top, strWhere, filedOrder);
		}

		#endregion  Method

        public static int Clear()
        {
            return EtNet_DAL.PictureInfoService.Clear();
        }
    }
}

