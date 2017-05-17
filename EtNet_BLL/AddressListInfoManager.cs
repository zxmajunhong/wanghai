using System;
using System.Data;
using System.Collections.Generic;

namespace EtNet_BLL
{
	/// <summary>
	/// AddressListInfoManager
	/// </summary>
	public  class AddressListInfoManager
	{		
		public AddressListInfoManager()
		{}
		#region  Method

		
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			return  EtNet_DAL.AddressListInfoService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.AddressListInfo model)
		{
            return EtNet_DAL.AddressListInfoService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.AddressListInfo model)
		{
            return EtNet_DAL.AddressListInfoService.Update(model);
		}


         /// <summary>
        /// 依据条件,批量删除数据
        /// </summary>
        public static bool Del(string strwhere)
        {
            return EtNet_DAL.AddressListInfoService.Del(strwhere);
        }


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.AddressListInfoService.Delete(id);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.AddressListInfoService.DeleteList(idlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.AddressListInfo GetModel(int id)
		{
            return EtNet_DAL.AddressListInfoService.GetModel(id);
		}

		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.AddressListInfoService.GetList(strWhere);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.AddressListInfoService.GetList(Top, strWhere, filedOrder);
		}


		#endregion  Method

        public static int Clear()
        {
            return EtNet_DAL.AddressListInfoService.Clear();
        }
    }
}

