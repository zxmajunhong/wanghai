using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;

namespace EtNet_BLL
{
    //To_Payment
    public partial class To_PaymentManager
    {

        private readonly To_PaymentService dal = new To_PaymentService();
        public To_PaymentManager()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(To_Payment model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(To_Payment model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新付款申请的财务支付
        /// </summary>
        /// <param name="paymentId">付款申请id</param>
        /// <param name="regtype">是否支付</param>
        /// <returns></returns>
        public bool UpdateReg(string paymentId, string regtype)
        {
            return dal.UpdateReg(paymentId, regtype);
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
        public To_Payment GetModel(string id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 通过工作流id得到对象实体
        /// </summary>
        /// <param name="jfid"></param>
        /// <returns></returns>
        public To_Payment GetModelByjfid(string jfid)
        {
            return dal.getModelByjfid(jfid);
        }

        /// <summary>
        /// 更新付款申请的帐号信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateAccount(To_Payment Model)
        {
            return dal.UpdateAccount(Model);
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
        public List<To_Payment> GetModelList(string strWhere)
        {
            DataTable dt = dal.GetList(strWhere);
            return DataTableToList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<To_Payment> DataTableToList(DataTable dt)
        {
            List<To_Payment> modelList = new List<To_Payment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                To_Payment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new To_Payment();
                    model.id = dt.Rows[n]["id"].ToString();
                    if (dt.Rows[n]["payerID"].ToString() != "")
                    {
                        model.payerID = int.Parse(dt.Rows[n]["payerID"].ToString());
                    }
                    if (dt.Rows[n]["totalAmount"].ToString() != "")
                    {
                        model.totalAmount = decimal.Parse(dt.Rows[n]["totalAmount"].ToString());
                    }
                    if (dt.Rows[n]["expectedDate"].ToString() != "")
                    {
                        model.expectedDate = DateTime.Parse(dt.Rows[n]["expectedDate"].ToString());
                    }
                    model.bankName = dt.Rows[n]["bankName"].ToString();
                    if (dt.Rows[n]["bankID"].ToString() != "")
                    {
                        model.bankID = int.Parse(dt.Rows[n]["bankID"].ToString());
                    }
                    model.bankAccount = dt.Rows[n]["bankAccount"].ToString();
                    model.bankAccountName = dt.Rows[n]["bankAccountName"].ToString();
                    model.bankMark = dt.Rows[n]["bankMark"].ToString();
                    model.orderNum = dt.Rows[n]["orderNum"].ToString();
                    model.codeFormat = dt.Rows[n]["codeFormat"].ToString();
                    model.serialNum = dt.Rows[n]["serialNum"].ToString();
                    if (dt.Rows[n]["jobFlowID"].ToString() != "")
                    {
                        model.jobFlowID = int.Parse(dt.Rows[n]["jobFlowID"].ToString());
                    }
                    model.approvalOpinion = dt.Rows[n]["approvalOpinion"].ToString();
                    if (dt.Rows[n]["requestDate"].ToString() != "")
                    {
                        model.requestDate = DateTime.Parse(dt.Rows[n]["requestDate"].ToString());
                    }
                    model.makerName = dt.Rows[n]["makerName"].ToString();
                    if (dt.Rows[n]["makerID"].ToString() != "")
                    {
                        model.makerID = int.Parse(dt.Rows[n]["makerID"].ToString());
                    }
                    model.payFor = dt.Rows[n]["payFor"].ToString();
                    model.paymentType = dt.Rows[n]["paymentType"].ToString();
                    model.payerName = dt.Rows[n]["payerName"].ToString();
                    model.payerCode = dt.Rows[n]["payerCode"].ToString();


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

        public DataTable GetViewPayment(string where, string having, string field)
        {
            return dal.GetViewPayment(where, having, field);
        }

        public DataTable GetPaymentInvoice(string where, string field)
        {
            return dal.GetPaymentInvoice(where, field);
        }

        public DataTable GetViewPaymentList(string where)
        {
            return dal.GetViewPaymentList(where);
        }
        public DataTable GetViewRegPaymentList(string where)
        {
            return dal.GetViewRegPaymentList(where);
        }
        #endregion

    }
}