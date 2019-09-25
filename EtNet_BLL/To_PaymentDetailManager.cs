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
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return To_PaymentDetailService.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(To_PaymentDetail model)
        {
            return To_PaymentDetailService.Add(model);

        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(To_PaymentDetail model)
        {
            return To_PaymentDetailService.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {

            return To_PaymentDetailService.Delete(id);
        }
        /// <summary>
        /// ����ɾ��һ������
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return To_PaymentDetailService.DeleteList(idlist);
        }

        /// <summary>
        /// ����paymentIDɾ������
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public bool DeleteByPayment(string paymentID)
        {
            return To_PaymentDetailService.DeleteByPayment(paymentID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public To_PaymentDetail GetModel(int id)
        {

            return To_PaymentDetailService.GetModel(id);
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return To_PaymentDetailService.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return To_PaymentDetailService.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<To_PaymentDetail> GetModelList(string strWhere)
        {
            return To_PaymentDetailService.getTo_PaymentDetailsBySql(strWhere);
        }
        

        /// <summary>
        /// ���ݸ��id�õ��Ѹ����ϼ�
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public double GetSumByPaymentId(string paymentID)
        {
            return To_PaymentDetailService.GetSumByPaymentId(paymentID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// �õ��Ѿ�����Ľ��
        /// </summary>
        /// <param name="policyID">����id</param>
        /// <param name="payerID">���λid</param>
        /// <param name="paymentType">�������</param>
        /// <returns></returns>
        public double GetHasAmount(string orderPayID)
        {
            return To_PaymentDetailService.GetHasAmount(orderPayID);
        }

        /// <summary>
        /// �õ�ʵ���Ѿ�����Ľ��
        /// </summary>
        /// <param name="orderPayID">����������Ϣ��ϸ��id</param>
        /// <returns></returns>
        public double GetRealityHasAmount(string orderPayID)
        {
            return To_PaymentDetailService.GetRealityHasAmount(orderPayID);
        }

        /// <summary>
        /// �õ������и��λ����Ҫ�ĸ�����������
        /// </summary>
        /// <param name="strWhere">sql����</param>
        /// <returns></returns>
        public DataTable GetOrderPayDetail(string strWhere)
        {
            return To_PaymentDetailService.GetOrderPayDetail(strWhere);
        }

        /// <summary>
        /// �õ�������Ϣ��ϸ��������Ҫ���Ѿ��������ϸ����
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
