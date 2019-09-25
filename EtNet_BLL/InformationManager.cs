using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;


namespace EtNet_BLL 
{

	//InformationManager
	public  class InformationManager
	{


        public InformationManager()
		{
        
        }
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static  bool Exists(int id)
		{
            return EtNet_DAL.InformationService.Exists(id);
		}

        
        /// <summary>
        /// 取当最新添加的记录
        /// </summary>
        public static int GetMaxId()
        {
            return EtNet_DAL.InformationService.GetMaxId("");
        }


        /// <summary>
        /// 取当前用户最新添加的数据记录
        /// </summary>
        public static int GetMaxId(string login)
        {
            return EtNet_DAL.InformationService.GetMaxId(login);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool  Add(EtNet_Models.Information model)
		{
            return EtNet_DAL.InformationService.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.Information model)
		{
            return EtNet_DAL.InformationService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.InformationService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.InformationService.DeleteList(idlist);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.Information GetModel(int id)
		{
            return EtNet_DAL.InformationService.GetModel(id);
		}

		
		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.InformationService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.InformationService.GetList(Top, strWhere, filedOrder);
		}


  #endregion

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public static int Clear()
        {
            return EtNet_DAL.InformationService.Clear();
        }
    }
}