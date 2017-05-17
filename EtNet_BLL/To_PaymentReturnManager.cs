using System;
using System.Collections.Generic;
using System.Text;
using EtNet_Models;
using EtNet_DAL;
using System.Data;
namespace EtNet_BLL
{


    public class To_PaymentReturnManager
    {
        public static int addTo_PaymentReturn(To_PaymentReturn to_paymentreturn)
        {
            return To_PaymentReturnService.addTo_PaymentReturn(to_paymentreturn);
        }

        public static int updateTo_PaymentReturn(To_PaymentReturn to_paymentreturn)
        {
            return To_PaymentReturnService.updateTo_PaymentReturnById(to_paymentreturn);
        }

        public static int deleteTo_PaymentReturn(int id)
        {
            return To_PaymentReturnService.deleteTo_PaymentReturnById(id);
        }

        /// <summary>
        /// ���ݸ��ɾ������
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public static bool DeleteByPayment(string paymentID)
        {
            return To_PaymentReturnService.DeleteByPayment(paymentID);
        }

        public static To_PaymentReturn getTo_PaymentReturnById(int id)
        {
            return To_PaymentReturnService.getTo_PaymentReturnById(id);
        }

        public static IList<To_PaymentReturn> getTo_PaymentReturnAll()
        {
            return To_PaymentReturnService.getTo_PaymentReturnAll();
        }

        /// <summary>
        /// ���������õ��б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetList(string strWhere)
        {
            return To_PaymentReturnService.GetList(strWhere);
        }

        /// <summary>
        /// �õ��Ѿ��˹����˿���
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="payerId"></param>
        /// <returns></returns>
        public static double GetHasAmount(string orderRetID)
        {
            return To_PaymentReturnService.GetHasAmount(orderRetID);
        }

        public static double GetRealityHasAmount(string orderRetID)
        {
            return To_PaymentReturnService.GetRealityHasAmount(orderRetID);
        }

        /// <summary>
        /// ���ݸ��id�õ��˿���ϼ�
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public static double GetSumByPaymentId(string paymentID)
        {
            return To_PaymentReturnService.GetSumByPaymentId(paymentID);
        }

        /// <summary>
        /// �õ��������˿λ����Ҫ�ĸ�����������
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetOrderReturnDetail(string strWhere)
        {
            return To_PaymentReturnService.GetOrderReturnDetail(strWhere);
        }

        /// <summary>
        /// �õ��˿���ϸ��������Ҫ���Ѿ��˿����ϸ����
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetReturnDetail(string strWhere)
        {
            return To_PaymentReturnService.GetReturnDetail(strWhere);
        }
    }
}
