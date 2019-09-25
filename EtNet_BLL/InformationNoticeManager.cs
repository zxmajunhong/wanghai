using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_BLL 
{
    //InformationNoticeManager
    public  class InformationNoticeManager
	{


        public InformationNoticeManager()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.InformationNoticeService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.InformationNotice model)
		{
            return EtNet_DAL.InformationNoticeService.Add(model);			
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.InformationNotice model)
		{
            return EtNet_DAL.InformationNoticeService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.InformationNoticeService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.InformationNoticeService.DeleteList(idlist);
		}


        


        /// <summary>
        /// 依据指定条件删除多条数据
        /// </summary>
        public static bool Del(string strWhere)
        {
            return EtNet_DAL.InformationNoticeService.Del(strWhere);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.InformationNotice GetModel(int id)
		{
            return EtNet_DAL.InformationNoticeService.GetModel(id);
		}


	   
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.InformationNoticeService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public  static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.InformationNoticeService.GetList(Top, strWhere, filedOrder);
		}


		
#endregion
   
	}
}