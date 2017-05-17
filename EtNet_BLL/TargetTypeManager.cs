using System;
using System.Data;
using System.Collections.Generic;
using EtNet_Models;
namespace EtNet_BLL
{
	/// <summary>
	/// TargetTypeManager
	/// </summary>
	public partial class TargetTypeManager
	{
		private readonly EtNet_DAL.TargetTypeService dal=new EtNet_DAL.TargetTypeService();
		public TargetTypeManager()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EtNet_Models.TargetType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EtNet_Models.TargetType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TargetTypeID)
		{
			
			return dal.Delete(TargetTypeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TargetTypeIDlist )
		{
			return dal.DeleteList(TargetTypeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EtNet_Models.TargetType GetModel(int TargetTypeID)
		{
			
			return dal.GetModel(TargetTypeID);
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
		public List<EtNet_Models.TargetType> GetModelList(string strWhere)
		{
            DataTable ds = dal.GetList(strWhere);
			return DataTableToList(ds);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EtNet_Models.TargetType> DataTableToList(DataTable dt)
		{
			List<EtNet_Models.TargetType> modelList = new List<EtNet_Models.TargetType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EtNet_Models.TargetType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new EtNet_Models.TargetType();
					if(dt.Rows[n]["TargetTypeID"]!=null && dt.Rows[n]["TargetTypeID"].ToString()!="")
					{
						model.TargetTypeID=int.Parse(dt.Rows[n]["TargetTypeID"].ToString());
					}
					if(dt.Rows[n]["TypeNo"]!=null && dt.Rows[n]["TypeNo"].ToString()!="")
					{
					model.TypeNo=dt.Rows[n]["TypeNo"].ToString();
					}
					if(dt.Rows[n]["TypeName"]!=null && dt.Rows[n]["TypeName"].ToString()!="")
					{
					model.TypeName=dt.Rows[n]["TypeName"].ToString();
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

