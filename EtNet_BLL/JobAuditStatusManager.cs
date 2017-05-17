using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;


namespace EtNet_BLL 
{
	
	public class JobAuditStatusManager
	{

        public JobAuditStatusManager()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(string num)
		{
            return EtNet_DAL.JobAuditStatusService.Exists(num);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.JobAuditStatus model)
		{
            return EtNet_DAL.JobAuditStatusService.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.JobAuditStatus model)
		{
            return EtNet_DAL.JobAuditStatusService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.JobAuditStatusService.Delete(id);
		}

	    /// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.JobAuditStatusService.DeleteList(idlist);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.JobAuditStatus GetModel(int id)
		{

            return EtNet_DAL.JobAuditStatusService.GetModel(id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.JobAuditStatus GetModelByNUM(string num)
        {

            return EtNet_DAL.JobAuditStatusService.GetModelByNUM(num);
        }


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.JobAuditStatusService.GetList(strWhere);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			return EtNet_DAL.JobAuditStatusService.GetList(Top,strWhere,filedOrder);
		}

		
       #endregion


        
    }
}