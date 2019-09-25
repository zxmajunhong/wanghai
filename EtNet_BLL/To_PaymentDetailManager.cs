using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class To_PaymentDetailManager
    {
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return To_PaymentDetailService.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(To_PaymentDetail model)
        {
            return To_PaymentDetailService.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(To_PaymentDetail model)
        {
            return To_PaymentDetailService.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return To_PaymentDetailService.Delete(id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return To_PaymentDetailService.DeleteList(idlist);
        }

        /// <summary>
        /// 根据paymentID删除数据
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public bool DeleteByPayment(string paymentID)
        {
            return To_PaymentDetailService.DeleteByPayment(paymentID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public To_PaymentDetail GetModel(int id)
        {

            return To_PaymentDetailService.GetModel(id);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return To_PaymentDetailService.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return To_PaymentDetailService.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<To_PaymentDetail> GetModelList(string strWhere)
        {
            return To_PaymentDetailService.getTo_PaymentDetailsBySql(strWhere);
        }
        

        /// <summary>
        /// 根据付款单id得到已付金额合计
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public double GetSumByPaymentId(string paymentID)
        {
            return To_PaymentDetailService.GetSumByPaymentId(paymentID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 得到已经认领的金额
        /// </summary>
        /// <param name="policyID">订单id</param>
        /// <param name="payerID">付款单位id</param>
        /// <param name="paymentType">付款类别</param>
        /// <returns></returns>
        public double GetHasAmount(string orderPayID)
        {
            return To_PaymentDetailService.GetHasAmount(orderPayID);
        }

        /// <summary>
        /// 得到实际已经认领的金额
        /// </summary>
        /// <param name="orderPayID">订单付款信息明细表id</param>
        /// <returns></returns>
        public double GetRealityHasAmount(string orderPayID)
        {
            return To_PaymentDetailService.GetRealityHasAmount(orderPayID);
        }

        /// <summary>
        /// 得到订单中付款单位所需要的付款申请数据
        /// </summary>
        /// <param name="strWhere">sql条件</param>
        /// <returns></returns>
        public DataTable GetOrderPayDetail(string strWhere)
        {
            return To_PaymentDetailService.GetOrderPayDetail(strWhere);
        }

        /// <summary>
        /// 得到付款信息明细表中所需要的已经付款的明细数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetPayDetail(string strWhere)
        {
            return To_PaymentDetailService.GetPayDetail(strWhere);
        }
        #endregion
    }
}
