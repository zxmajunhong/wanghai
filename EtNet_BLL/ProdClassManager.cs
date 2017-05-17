using System;
using System.Data;
using System.Collections.Generic;
using EtNet_Models;
namespace EtNet_BLL
{
	/// <summary>
	/// ProdClassManager
	/// </summary>
	public partial class ProdClassManager
	{
		private readonly EtNet_DAL.ProdClassService dal=new EtNet_DAL.ProdClassService();
		public ProdClassManager()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EtNet_Models.ProdClass model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EtNet_Models.ProdClass model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string num)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete(num);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EtNet_Models.ProdClass GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}



		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataTable GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EtNet_Models.ProdClass> GetModelList(string strWhere)
		{
            DataTable ds = dal.GetList(strWhere);
			return DataTableToList(ds);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EtNet_Models.ProdClass> DataTableToList(DataTable dt)
		{
			List<EtNet_Models.ProdClass> modelList = new List<EtNet_Models.ProdClass>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EtNet_Models.ProdClass model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new EtNet_Models.ProdClass();
					if(dt.Rows[n]["ProdClassNo"]!=null && dt.Rows[n]["ProdClassNo"].ToString()!="")
					{
					model.ProdClassNo=dt.Rows[n]["ProdClassNo"].ToString();
					}
					if(dt.Rows[n]["ProdClassName"]!=null && dt.Rows[n]["ProdClassName"].ToString()!="")
					{
					model.ProdClassName=dt.Rows[n]["ProdClassName"].ToString();
					}
					if(dt.Rows[n]["Prior"]!=null && dt.Rows[n]["Prior"].ToString()!="")
					{
						model.Prior=int.Parse(dt.Rows[n]["Prior"].ToString());
					}
					if(dt.Rows[n]["ViewInReport"]!=null && dt.Rows[n]["ViewInReport"].ToString()!="")
					{
						if((dt.Rows[n]["ViewInReport"].ToString()=="1")||(dt.Rows[n]["ViewInReport"].ToString().ToLower()=="true"))
						{
						model.ViewInReport=true;
						}
						else
						{
							model.ViewInReport=false;
						}
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataTable GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

