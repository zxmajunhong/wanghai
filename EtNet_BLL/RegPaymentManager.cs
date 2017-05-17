using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;

namespace EtNet_BLL
{
	public class RegPaymentManager
	{
		private RegPaymentService dal = new RegPaymentService();

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(RegPayment model)
		{
			dal.Add(model);
		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RegPayment model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RegPayment GetModel(string id)
		{
			return dal.GetModel(id);
		}

		/// <summary>
		/// 修改财务支付状态
		/// </summary>
		/// <param name="payStatus"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool UpdatePayStatus(int payStatus, string id)
		{
			return dal.UpdatePayStatus(payStatus, id);
		}

		public DataTable GetViewPaymentList(string where)
		{
			return dal.GetViewPaymentList(where);
		}
	}
}
