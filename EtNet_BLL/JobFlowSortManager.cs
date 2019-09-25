using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_BLL {
	 	
	public class JobFlowSortManager
	{
   		     
	    public JobFlowSortManager()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(string num)
		{
            return EtNet_DAL.JobFlowSortService.Exists(num);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.JobFlowSort model)
		{
            return EtNet_DAL.JobFlowSortService.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.JobFlowSort model)
		{
            return EtNet_DAL.JobFlowSortService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.JobFlowSortService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
            return EtNet_DAL.JobFlowSortService.DeleteList(idlist);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.JobFlowSort GetModel(int id)
		{
            return EtNet_DAL.JobFlowSortService.GetModel(id);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.JobFlowSortService.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			return EtNet_DAL.JobFlowSortService.GetList(Top,strWhere,filedOrder);
		}
	
		
#endregion
   
	}
}