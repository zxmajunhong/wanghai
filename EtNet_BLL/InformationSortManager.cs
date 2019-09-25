using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace EtNet_BLL 
{
    //InformationSortManager
    public class InformationSortManager
	{


        public InformationSortManager()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
            return EtNet_DAL.InformationSortService.Exists(id);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public  static bool Add(EtNet_Models.InformationSort model)
		{
            return EtNet_DAL.InformationSortService.Add(model);			
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.InformationSort model)
		{
            return EtNet_DAL.InformationSortService.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
            return EtNet_DAL.InformationSortService.Delete(id);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
            return EtNet_DAL.InformationSortService.DeleteList(idlist);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.InformationSort GetModel(int id)
		{
            return EtNet_DAL.InformationSortService.GetModel(id);
		}


	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataTable GetList(string strWhere)
		{
            return EtNet_DAL.InformationSortService.GetList(strWhere);
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
            return EtNet_DAL.InformationSortService.GetList(Top, strWhere, filedOrder);
		}

		
    #endregion
   
	}
}