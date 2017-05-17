using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_PaymentReturn]������ݷ�����
    /// </summary>
    public class To_PaymentReturnService
    {
        /// <summary>
        ///[To_PaymentReturn]����ӵķ���
        /// </summary>
        public static int addTo_PaymentReturn(To_PaymentReturn to_paymentreturn)
        {
            string sql = "insert into To_PaymentReturn([paymentID],[orderRetID],[orderNum],[shouldReturn],[returnAmount]) values (@paymentID,@orderRetID,@orderNum,@shouldReturn,@returnAmount)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@paymentID",to_paymentreturn.PaymentID),
        new SqlParameter("@orderRetID",to_paymentreturn.orderRetID),
        new SqlParameter("@orderNum",to_paymentreturn.OrderNum),
        new SqlParameter("@shouldReturn",to_paymentreturn.ShouldReturn),
        new SqlParameter("@returnAmount",to_paymentreturn.ReturnAmount)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_PaymentReturn]���޸ĵķ���
        /// </summary>
        public static int updateTo_PaymentReturnById(To_PaymentReturn to_paymentreturn)
        {

            string sql = "update To_PaymentReturn set paymentID=@paymentID,orderRetID=@orderRetID,orderNum=@orderNum,shouldReturn=@shouldReturn,returnAmount=@returnAmount where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",to_paymentreturn.Id),
        new SqlParameter("@paymentID",to_paymentreturn.PaymentID),
        new SqlParameter("@orderRetID",to_paymentreturn.orderRetID),
        new SqlParameter("@orderNum",to_paymentreturn.OrderNum),
        new SqlParameter("@shouldReturn",to_paymentreturn.ShouldReturn),
        new SqlParameter("@returnAmount",to_paymentreturn.ReturnAmount)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_PaymentReturn]��ɾ���ķ���
        /// </summary>
        public static int deleteTo_PaymentReturnById(int id)
        {

            string sql = "delete from To_PaymentReturn where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_PaymentReturn]���ѯʵ��ķ���
        /// </summary>
        public static To_PaymentReturn getTo_PaymentReturnById(int id)
        {
            To_PaymentReturn to_paymentreturn = null;

            string sql = "select * from To_PaymentReturn where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_paymentreturn = new To_PaymentReturn();
                foreach (DataRow dr in dt.Rows)
                {
                    to_paymentreturn.Id = Convert.ToInt32(dr["id"]);
                    to_paymentreturn.PaymentID = Convert.ToString(dr["paymentID"]);
                    to_paymentreturn.orderRetID = Convert.ToInt32(dr["orderRetID"]);
                    to_paymentreturn.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_paymentreturn.ShouldReturn = Convert.ToDouble(dr["shouldReturn"]);
                    to_paymentreturn.ReturnAmount = Convert.ToDouble(dr["returnAmount"]);
                }
            }

            return to_paymentreturn;
        }

        /// <summary>
        ///[To_PaymentReturn]���ѯ���еķ���
        /// </summary>
        public static IList<To_PaymentReturn> getTo_PaymentReturnAll()
        {
            string sql = "select * from To_PaymentReturn";
            return getTo_PaymentReturnsBySql(sql);
        }
        /// <summary>
        ///����SQL����ȡ����
        /// </summary>
        public static IList<To_PaymentReturn> getTo_PaymentReturnsBySql(string sql)
        {
            IList<To_PaymentReturn> list = new List<To_PaymentReturn>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_PaymentReturn to_paymentreturn = new To_PaymentReturn();
                    to_paymentreturn.Id = Convert.ToInt32(dr["id"]);
                    to_paymentreturn.PaymentID = Convert.ToString(dr["paymentID"]);
                    to_paymentreturn.orderRetID = Convert.ToInt32(dr["orderRetID"]);
                    to_paymentreturn.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_paymentreturn.ShouldReturn = Convert.ToDouble(dr["shouldReturn"]);
                    to_paymentreturn.ReturnAmount = Convert.ToDouble(dr["returnAmount"]);
                    list.Add(to_paymentreturn);
                }
            }
            return list;
        }
        /// <summary>
        ///����SQL����ȡʵ��
        /// </summary>
        public static To_PaymentReturn getTo_PaymentReturnBySql(string sql)
        {
            To_PaymentReturn to_paymentreturn = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_paymentreturn = new To_PaymentReturn();
                foreach (DataRow dr in dt.Rows)
                {
                    to_paymentreturn.Id = Convert.ToInt32(dr["id"]);
                    to_paymentreturn.PaymentID = Convert.ToString(dr["paymentID"]);
                    to_paymentreturn.orderRetID = Convert.ToInt32(dr["orderRetID"]);
                    to_paymentreturn.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_paymentreturn.ShouldReturn = Convert.ToDouble(dr["shouldReturn"]);
                    to_paymentreturn.ReturnAmount = Convert.ToDouble(dr["returnAmount"]);
                }
            }
            return to_paymentreturn;
        }

        /// <summary>
        /// �õ��Ѿ��˹����˿���
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="payerId"></param>
        /// <returns></returns>
        public static double GetHasAmount(string orderRetID)
        {
            string sql = " select SUM(returnAmount) from View_PaymentReturn where orderRetID=" + orderRetID;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                double hasAmount = 0;
                double.TryParse(dt.Rows[0][0].ToString(), out hasAmount);
                return hasAmount;
            }
            else
                return 0;
        }

        /// <summary>
        /// �õ�ʵ���Ѿ��˹����˿���
        /// </summary>
        /// <param name="orderRetID"></param>
        /// <returns></returns>
        public static double GetRealityHasAmount(string orderRetID)
        {
            string sql = " select SUM(returnAmount) from View_PaymentReturn where auditstatus='04' and orderRetID=" + orderRetID;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                double hasAmount = 0;
                double.TryParse(dt.Rows[0][0].ToString(), out hasAmount);
                return hasAmount;
            }
            else
                return 0;
        }

        /// <summary>
        /// ���������õ��б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM To_PaymentReturn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// ���ݸ��idɾ������
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public static bool DeleteByPayment(string paymentID)
        {
            string sql = " delete from To_PaymentReturn where paymentID=@paymentID";
            SqlParameter parameter = new SqlParameter("@paymentID", paymentID);
            int result = DBHelper.ExecuteCommand(sql, parameter);
            return result > 0;
        }

        /// <summary>
        /// ���ݸ��id�õ��˿���ϼ�
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public static double GetSumByPaymentId(string paymentID)
        {
            string sql = " select SUM(returnAmount) from To_PaymentReturn where paymentID='" + paymentID + "'";
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                double sum = 0;
                double.TryParse(dt.Rows[0][0].ToString(), out sum);
                return sum;
            }
            else
                return 0;
        }

        /// <summary>
        /// �õ��������˿λ����Ҫ�ĸ�����������
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="payerId"></param>
        /// <returns></returns>
        public static DataTable GetOrderReturnDetail(string strWhere)
        {
            string sql = " select * from View_PaymentReturn ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            return DBHelper.GetDataSet(sql);
        }

        public static DataTable GetReturnDetail(string strWhere)
        {
            string sql = "select * from ViewOrderRefundDetail ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            return DBHelper.GetDataSet(sql);
        }
    }
}
