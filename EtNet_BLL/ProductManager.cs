using System;
using System.Data;
using System.Collections.Generic;
using EtNet_Models;
namespace EtNet_BLL
{
	/// <summary>
	/// ProductManager
	/// </summary>
	public partial class ProductManager
	{
		private readonly EtNet_DAL.ProductService dal=new EtNet_DAL.ProductService();
		public ProductManager()
		{}
		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public object  Add(EtNet_Models.Product model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EtNet_Models.Product model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProdID)
		{
			
			return dal.Delete(ProdID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProdIDlist )
		{
			return dal.DeleteList(ProdIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EtNet_Models.Product GetModel(int ProdID)
		{
			
			return dal.GetModel(ProdID);
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
		public List<EtNet_Models.Product> GetModelList(string strWhere)
		{
            DataTable ds = dal.GetList(strWhere);
			return DataTableToList(ds);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EtNet_Models.Product> DataTableToList(DataTable dt)
		{
			List<EtNet_Models.Product> modelList = new List<EtNet_Models.Product>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EtNet_Models.Product model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new EtNet_Models.Product();
					if(dt.Rows[n]["ProdID"]!=null && dt.Rows[n]["ProdID"].ToString()!="")
					{
						model.ProdID=int.Parse(dt.Rows[n]["ProdID"].ToString());
					}
					if(dt.Rows[n]["ProdNo"]!=null && dt.Rows[n]["ProdNo"].ToString()!="")
					{
					model.ProdNo=dt.Rows[n]["ProdNo"].ToString();
					}
					if(dt.Rows[n]["ProdName"]!=null && dt.Rows[n]["ProdName"].ToString()!="")
					{
					model.ProdName=dt.Rows[n]["ProdName"].ToString();
					}
					if(dt.Rows[n]["ProdTypeID"]!=null && dt.Rows[n]["ProdTypeID"].ToString()!="")
					{
					model.ProdTypeID=dt.Rows[n]["ProdTypeID"].ToString();
					}
					if(dt.Rows[n]["Brief"]!=null && dt.Rows[n]["Brief"].ToString()!="")
					{
					model.Brief=dt.Rows[n]["Brief"].ToString();
					}
					if(dt.Rows[n]["PremiumRate"]!=null && dt.Rows[n]["PremiumRate"].ToString()!="")
					{
						model.PremiumRate=decimal.Parse(dt.Rows[n]["PremiumRate"].ToString());
					}
					if(dt.Rows[n]["FlagMain"]!=null && dt.Rows[n]["FlagMain"].ToString()!="")
					{
						if((dt.Rows[n]["FlagMain"].ToString()=="1")||(dt.Rows[n]["FlagMain"].ToString().ToLower()=="true"))
						{
						model.FlagMain=true;
						}
						else
						{
							model.FlagMain=false;
						}
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["CommRate"]!=null && dt.Rows[n]["CommRate"].ToString()!="")
					{
						model.CommRate=decimal.Parse(dt.Rows[n]["CommRate"].ToString());
					}
					if(dt.Rows[n]["ProcRate"]!=null && dt.Rows[n]["ProcRate"].ToString()!="")
					{
						model.ProcRate=decimal.Parse(dt.Rows[n]["ProcRate"].ToString());
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

