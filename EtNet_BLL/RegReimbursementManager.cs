using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;

namespace EtNet_BLL
{
	//RegReimbursement 
	public partial class RegReimbursementManager
	{

		private readonly RegReimbursementService dal = new RegReimbursementService();
		public RegReimbursementManager()
		{ }

		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(RegReimbursement model)
		{
			return dal.Add(model);

		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RegReimbursement model)
		{
			return dal.Update(model);
		}

		public bool UpdatePayStatus(int payStatus, string id)
		{
			return dal.UpdatePayStatus(payStatus, id);
		}
        public bool UpdatePayerType(int regType, string id)
        {
            return dal.UpdatePayerType(regType, id);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{

			return dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public RegReimbursement GetModel(string id)
		{

			return dal.GetModel(id);
		}


        public  DataTable GetListpage(string strWhere, string ordertype, int startIndex, int endIndex)
        {
            return dal.GetListpage(strWhere, ordertype, startIndex, endIndex);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public RegReimbursement GetModelByAusID(int ausID)
		{
			return dal.GetModelByAusID(ausID);
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
			return dal.GetList(Top, strWhere, filedOrder);
		}

        public DataTable GetViewList(string strWhere)
        {
            return dal.GetViewList(strWhere);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<RegReimbursement> GetModelList(string strWhere)
		{
			DataTable dt = dal.GetList(strWhere);
			return DataTableToList(dt);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<RegReimbursement> DataTableToList(DataTable dt)
		{
			List<RegReimbursement> modelList = new List<RegReimbursement>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RegReimbursement model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RegReimbursement();
					model.id = dt.Rows[n]["id"].ToString();
					if (dt.Rows[n]["payStatus"].ToString() != "")
					{
						model.payStatus = int.Parse(dt.Rows[n]["payStatus"].ToString());
					}
					if (dt.Rows[n]["paymentMode"].ToString() != "")
					{
						model.paymentMode = int.Parse(dt.Rows[n]["paymentMode"].ToString());
					}
					if (dt.Rows[n]["payerID"].ToString() != "")
					{
						model.payerID = int.Parse(dt.Rows[n]["payerID"].ToString());
					}
					model.payerName = dt.Rows[n]["payerName"].ToString();
					if (dt.Rows[n]["paymentDate"].ToString() != "")
					{
						model.paymentDate = DateTime.Parse(dt.Rows[n]["paymentDate"].ToString());
					}
					if (dt.Rows[n]["makeTime"].ToString() != "")
					{
						model.makeTime = DateTime.Parse(dt.Rows[n]["makeTime"].ToString());
					}
					if (dt.Rows[n]["makerID"].ToString() != "")
					{
						model.makerID = int.Parse(dt.Rows[n]["makerID"].ToString());
					}
					model.makerName = dt.Rows[n]["makerName"].ToString();


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
		#endregion

	}
}
