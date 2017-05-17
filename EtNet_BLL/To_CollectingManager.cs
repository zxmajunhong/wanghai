using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class To_CollectingManager
    {
        public static int addTo_Collecting(To_Collecting to_collecting)
        {
            return To_CollectingService.addTo_Collecting(to_collecting);
        }

        public static int updateTo_Collecting(To_Collecting to_collecting)
        {
            return To_CollectingService.updateTo_CollectingById(to_collecting);
        }

        /// <summary>
        /// �����տ�ĵ�λ��Ϣ
        /// </summary>
        /// <param name="to_collecting"></param>
        /// <returns></returns>
        public static int updateTo_CollectPaymentUnit(To_Collecting to_collecting)
        {
            return To_CollectingService.updateTo_CollectPaymentUnit(to_collecting);
        }

        public static int deleteTo_Collecting(int ID)
        {
            return To_CollectingService.deleteTo_CollectingById(ID);
        }

        public static To_Collecting getTo_CollectingById(int ID)
        {
            return To_CollectingService.getTo_CollectingById(ID);
        }

        public static IList<To_Collecting> getTo_CollectingAll()
        {
            return To_CollectingService.getTo_CollectingAll();
        }

        #region ����ӷ���
        /// <summary>
        /// ��ȡ��ҳ����
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static DataTable GetListByLimit(string strWhere, int userID, int startIndex, int endIndex)
        {
            return To_CollectingService.GetListByLimit(strWhere, userID, startIndex, endIndex);
        }

        public static IList<To_Collecting> GetListByPage(string strWhere, int userID, int startIndex, int endIndex)
        {
            return To_CollectingService.GetListByPage(strWhere, userID, startIndex, endIndex);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return To_CollectingService.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ȡ��¼����
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCount(string where, int userID)
        {
            return To_CollectingService.GetTotalCount(where, userID);
        }

        /// <summary>
        /// ��ȡ��¼����
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCountByLimit(string where, int userID)
        {
            return To_CollectingService.GetTotalCountByLimit(where, userID);
        }

        /// <summary>
        /// �жϵ����Ƿ���ȷ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CancelConfirm(int id)
        {
            return To_CollectingService.CancelConfirm(id);
        }
        public static void ChangeClaim(int collectingID, int receiptStatusCode)
        {
            To_CollectingService.ChangeClaim(collectingID, receiptStatusCode);
        }

        /// <summary>
        /// �����տ��ID��ȡ�տ���
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetAmount(int ID)
        {
            return To_CollectingService.GetAmount(ID);
        }

        /// <summary>
        /// �����տ��ID��ѯ������ϸ
        /// </summary>
        /// <param name="collcetingID"></param>
        /// <returns></returns>
        public static DataTable GetClaimDetail(int collcetingID)
        {
            return To_CollectingService.GetClaimDetail(collcetingID);
        }

        #endregion

        public static int Clear()
        {
            return To_CollectingService.Clear();
        }

        /// <summary>
        /// �����տλȷ����Ϣ
        /// </summary>
        /// <param name="id">�տid</param>
        /// <param name="confirmMan">ȷ����</param>
        /// <param name="confirmDate">ȷ������</param>
        /// <returns></returns>
        public static int updateConfirm(string id, string confirmMan, string confirmDate)
        {
            return To_CollectingService.updateConfirm(id, confirmMan, confirmDate);
        }

        public static DataTable getConfirmInfo(string id)
        {
            return To_CollectingService.getConfirmInfo(id);
        }
    }
}
