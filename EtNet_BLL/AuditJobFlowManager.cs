using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;


namespace EtNet_BLL 
{
	 	
	public class AuditJobFlowManager
	{
   		     
			
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.AuditJobFlowService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public  static bool Add( EtNet_Models.AuditJobFlow model)
		{
            return EtNet_DAL.AuditJobFlowService.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.AuditJobFlow model)
		{
            return EtNet_DAL.AuditJobFlowService.Update(model);
		}

        /// <summary>
        /// 修改其他审核人员的审核信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static bool UpdateOther(string strWhere)
        {
            return EtNet_DAL.AuditJobFlowService.UpdateOther(strWhere);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{

            return EtNet_DAL.AuditJobFlowService.Delete(id);
		}

        /// <summary>
        /// 删除指定条件的数据
        /// </summary>
        public static bool Delete( string strWhere)
        {
            return EtNet_DAL.AuditJobFlowService.Delete(strWhere);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.AuditJobFlow GetModel(int id)
		{

            return EtNet_DAL.AuditJobFlowService.GetModel(id);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.AuditJobFlowService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public  static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.AuditJobFlowService.GetList(Top, strWhere, filedOrder);
		}


	
	
#endregion


        public static EtNet_Models.AuditJobFlow GetModelByJFID(int jobflowid)
        {
            return EtNet_DAL.AuditJobFlowService.GetModelByJFID(jobflowid);
        }
    }
}