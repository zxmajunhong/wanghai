using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;

namespace EtNet_BLL
{
    //ReimbursementInvoice
    public partial class ReimbursementInvoiceManager
    {

        private readonly ReimbursementInvoiceService dal = new ReimbursementInvoiceService();


        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ReimbursementInvoice model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ReimbursementInvoice model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            return dal.Delete(id);
        }

        public bool DeleteByRegID(string regID)
        {
            return dal.DeleteByRegID(regID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ReimbursementInvoice GetModel(string id)
        {

            return dal.GetModel(id);
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
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ReimbursementInvoice> GetModelList(string strWhere)
        {
            DataTable dt = dal.GetList(strWhere);
            return DataTableToList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ReimbursementInvoice> DataTableToList(DataTable dt)
        {
            List<ReimbursementInvoice> modelList = new List<ReimbursementInvoice>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ReimbursementInvoice model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ReimbursementInvoice();
                    model.id = dt.Rows[n]["id"].ToString();
                    model.reimbursementID = dt.Rows[n]["reimbursementID"].ToString();
                    model.invoiceNum = dt.Rows[n]["invoiceNum"].ToString();
                    model.remark = dt.Rows[n]["remark"].ToString();


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
