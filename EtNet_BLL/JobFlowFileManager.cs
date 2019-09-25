using System;
using System.Data;
using System.Collections.Generic;


namespace EtNet_BLL
{
	/// <summary>
	/// JobFlowFile
	/// </summary>
	public  class JobFlowFileManager
	{

        public JobFlowFileManager()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
			return  EtNet_DAL.JobFlowFileService.GetMaxId();
		}

		/// <summary>
		/// 是否存在指定工作流的相关文件
		/// </summary>
        public static bool Exists(int jobflowid)
		{
            return EtNet_DAL.JobFlowFileService.Exists(jobflowid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.JobFlowFile model)
		{
            return EtNet_DAL.JobFlowFileService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.JobFlowFile model)
		{
            return EtNet_DAL.JobFlowFileService.Update(model);
		}

		/// <summary>
		/// 删除数据,依据工作流的id值
		/// </summary>
		public static bool Delete(int jobflowid)
		{
            return EtNet_DAL.JobFlowFileService.Delete(jobflowid);
		}
	

        /// <summary>
        /// 依据id删除数据
        /// </summary>
        public static bool DeleteId(int id)
        {
            return EtNet_DAL.JobFlowFileService.DeleteId(id);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.JobFlowFile GetModel(int id)
		{
            return EtNet_DAL.JobFlowFileService.GetModel(id);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static  DataTable GetList(string strWhere)
		{
            return EtNet_DAL.JobFlowFileService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			return  EtNet_DAL.JobFlowFileService.GetList(Top,strWhere,filedOrder);
		}


		#endregion  Method

        
    }
}

