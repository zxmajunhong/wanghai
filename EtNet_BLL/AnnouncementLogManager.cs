using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_BLL
{
	 //AnnouncementLog
	public class AnnouncementLogManager
	{
 
		public AnnouncementLogManager()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			return EtNet_DAL.AnnouncementLogService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.AnnouncementLog model)
		{
            return EtNet_DAL.AnnouncementLogService.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.AnnouncementLog model)
		{
            return EtNet_DAL.AnnouncementLogService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.AnnouncementLogService.Delete(id);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.AnnouncementLogService.DeleteList(idlist);
		}
		
         /// <summary>
        /// 删除多条数据
        /// </summary>
        public static bool Del(string strwhere)
        {
            return EtNet_DAL.AnnouncementLogService.Del(strwhere);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static  EtNet_Models.AnnouncementLog GetModel(int id)
		{
            return EtNet_DAL.AnnouncementLogService.GetModel(id);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.AnnouncementLogService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.AnnouncementLogService.GetList(Top, strWhere, filedOrder);
		}

	
		
#endregion
   
	}
}