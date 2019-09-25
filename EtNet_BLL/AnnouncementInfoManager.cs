using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_BLL
{
	//AnnouncementInfo
	public  class AnnouncementInfoManager
	{
   		     
		
		public AnnouncementInfoManager()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			return  EtNet_DAL.AnnouncementInfoService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据,返回id值
		/// </summary>
		public static  int  Add(EtNet_Models.AnnouncementInfo model)
		{
            return EtNet_DAL.AnnouncementInfoService.Add(model);				
		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.AnnouncementInfo model)
		{
            return EtNet_DAL.AnnouncementInfoService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.AnnouncementInfoService.Delete(id);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.AnnouncementInfoService.DeleteList(idlist);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.AnnouncementInfo GetModel(int id)
		{
            return EtNet_DAL.AnnouncementInfoService.GetModel(id);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.AnnouncementInfoService.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.AnnouncementInfoService.GetList(Top, strWhere, filedOrder);
		}

        /// <summary>
        /// 清空
        /// </summary>
        public static int Clear()
        {
            return EtNet_DAL.AnnouncementInfoService.Clear();
        }
		
        #endregion


        
    }
}