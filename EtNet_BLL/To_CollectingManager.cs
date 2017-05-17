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
        /// 更新收款单的单位信息
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

        #region 后添加方法
        /// <summary>
        /// 获取分页数据
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
        /// 获得前几行数据
        /// </summary>
        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return To_CollectingService.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCount(string where, int userID)
        {
            return To_CollectingService.GetTotalCount(where, userID);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCountByLimit(string where, int userID)
        {
            return To_CollectingService.GetTotalCountByLimit(where, userID);
        }

        /// <summary>
        /// 判断单据是否已确认
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
        /// 根据收款单据ID获取收款金额
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetAmount(int ID)
        {
            return To_CollectingService.GetAmount(ID);
        }

        /// <summary>
        /// 根据收款单据ID查询认领明细
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
        /// 更新收款单位确认信息
        /// </summary>
        /// <param name="id">收款单id</param>
        /// <param name="confirmMan">确认人</param>
        /// <param name="confirmDate">确认日期</param>
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
