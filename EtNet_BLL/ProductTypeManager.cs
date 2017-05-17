using System;
using System.Data;
using System.Collections.Generic;
using EtNet_Models;
namespace EtNet_BLL
{
	/// <summary>
	/// ProductTypeManager
	/// </summary>
	public partial class ProductTypeManager
	{
		private readonly EtNet_DAL.ProductTypeService dal=new EtNet_DAL.ProductTypeService();
		public ProductTypeManager()
		{}
		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EtNet_Models.ProductType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EtNet_Models.ProductType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdTypeNo)
		{
			
			return dal.Delete(ProdTypeNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProdTypeNolist )
		{
			return dal.DeleteList(ProdTypeNolist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EtNet_Models.ProductType GetModel(string ProdTypeNo)
		{
			
			return dal.GetModel(ProdTypeNo);
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
		public List<EtNet_Models.ProductType> GetModelList(string strWhere)
		{
			DataTable ds = dal.GetList(strWhere);
			return DataTableToList(ds);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EtNet_Models.ProductType> DataTableToList(DataTable dt)
		{
			List<EtNet_Models.ProductType> modelList = new List<EtNet_Models.ProductType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EtNet_Models.ProductType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new EtNet_Models.ProductType();
					if(dt.Rows[n]["ProdTypeNo"]!=null && dt.Rows[n]["ProdTypeNo"].ToString()!="")
					{
					model.ProdTypeNo=dt.Rows[n]["ProdTypeNo"].ToString();
					}
					if(dt.Rows[n]["ProdTypeName"]!=null && dt.Rows[n]["ProdTypeName"].ToString()!="")
					{
					model.ProdTypeName=dt.Rows[n]["ProdTypeName"].ToString();
					}
					if(dt.Rows[n]["ParentId"]!=null && dt.Rows[n]["ParentId"].ToString()!="")
					{
					model.ParentId=dt.Rows[n]["ParentId"].ToString();
					}
					if(dt.Rows[n]["ProdClass"]!=null && dt.Rows[n]["ProdClass"].ToString()!="")
					{
					model.ProdClass=dt.Rows[n]["ProdClass"].ToString();
					}
					if(dt.Rows[n]["TargetTypeId"]!=null && dt.Rows[n]["TargetTypeId"].ToString()!="")
					{
						model.TargetTypeId=int.Parse(dt.Rows[n]["TargetTypeId"].ToString());
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

