using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_BLL
{
	 
    public class ApprovalRuleManager
	{


        public ApprovalRuleManager()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.ApprovalRuleService.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.ApprovalRule model)
		{
            return EtNet_DAL.ApprovalRuleService.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.ApprovalRule model)
		{
            return EtNet_DAL.ApprovalRuleService.Update(model);
		}
        /// <summary>
        /// 更新一条数据（隐藏按钮专用）
        /// </summary>
        public static bool UpdateHide(EtNet_Models.ApprovalRule model)
        {
            return EtNet_DAL.ApprovalRuleService.UpdateHide(model);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.ApprovalRuleService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.ApprovalRuleService.DeleteList(idlist);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.ApprovalRule GetModel(int id)
		{
            return EtNet_DAL.ApprovalRuleService.GetModel(id);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.ApprovalRuleService.GetList(strWhere);
		}


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string sort,string jobflowsort)
        {
            string strWhere = " sort ='" + sort + "' AND jobflowsort = '" + jobflowsort + "'";
            return EtNet_DAL.ApprovalRuleService.GetList(strWhere); 
        }



		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.ApprovalRuleService.GetList(Top, strWhere, filedOrder);
		}
		



		
#endregion
   
	}
}