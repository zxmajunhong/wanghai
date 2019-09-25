using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_PaymentDetail]
    /// </summary>
    public class To_PaymentDetailService
    {
        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from To_PaymentDetail");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DBHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        ///[To_PaymentDetail]
        /// </summary>
        public static int Add(To_PaymentDetail to_paymentdetail)
        {
            string sql = "insert into To_PaymentDetail([paymentID],[orderNum],[orderPayId],[shouldPay],[payAmount]) values (@paymentID,@orderNum,@orderPayId,@shouldPay,@payAmount)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@paymentID",to_paymentdetail.PaymentID),
        new SqlParameter("@orderNum",to_paymentdetail.OrderNum),
        new SqlParameter("@orderPayId",to_paymentdetail.OrderPayId),
        new SqlParameter("@shouldPay",to_paymentdetail.ShouldPay),
        new SqlParameter("@payAmount",to_paymentdetail.PayAmount)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_PaymentDetail]
        /// </summary>
        public static bool Update(To_PaymentDetail to_paymentdetail)
        {

            string sql = "update To_PaymentDetail set paymentID=@paymentID,orderNum=@orderNum,orderPayId=@orderPayId,shouldPay=@shouldPay,payAmount=@payAmount where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",to_paymentdetail.Id),
        new SqlParameter("@paymentID",to_paymentdetail.PaymentID),
        new SqlParameter("@orderNum",to_paymentdetail.OrderNum),
        new SqlParameter("@orderPayId",to_paymentdetail.OrderPayId),
        new SqlParameter("@shouldPay",to_paymentdetail.ShouldPay),
        new SqlParameter("@payAmount",to_paymentdetail.PayAmount)
     };
            int rows = DBHelper.ExecuteCommand(sql, sp);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        ///[To_PaymentDetail]
        /// </summary>
        public static bool Delete(int id)
        {

            string sql = "delete from To_PaymentDetail where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            int rows = DBHelper.ExecuteCommand(sql, sp);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from To_PaymentDetail ");
            strSql.Append(" where ID in (" + idlist + ")  ");
            int rows = DBHelper.ExecuteCommand(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据paymentID删除数据
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public static bool DeleteByPayment(string paymentID)
        {
            string sql = "DELETE from To_PaymentDetail where paymentID=@paymentID";

            SqlParameter parameter = new SqlParameter("@paymentID", paymentID);

            int resultRowCount = DBHelper.ExecuteCommand(sql, parameter);

            return resultRowCount > 0;
        }

        /// <summary>
        ///[To_PaymentDetail]
        /// </summary>
        public static To_PaymentDetail GetModel(int id)
        {
            To_PaymentDetail to_paymentdetail = null;

            string sql = "select * from To_PaymentDetail where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_paymentdetail = new To_PaymentDetail();
                foreach (DataRow dr in dt.Rows)
                {
                    to_paymentdetail.Id = Convert.ToInt32(dr["id"]);
                    to_paymentdetail.PaymentID = Convert.ToString(dr["paymentID"]);
                    to_paymentdetail.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_paymentdetail.OrderPayId = Convert.ToInt32(dr["orderPayId"]);
                    to_paymentdetail.ShouldPay = Convert.ToDouble(dr["shouldPay"]);
                    to_paymentdetail.PayAmount = Convert.ToDouble(dr["payAmount"]);
                }
            }

            return to_paymentdetail;
        }

        /// <summary>
        ///[To_PaymentDetail]
        /// </summary>
        public static IList<To_PaymentDetail> getTo_PaymentDetailAll()
        {
            string sql = "select * from To_PaymentDetail";
            return getTo_PaymentDetailsBySql(sql);
        }
        /// <summary>
        ///
        /// </summary>
        public static IList<To_PaymentDetail> getTo_PaymentDetailsBySql(string strWhere)
        {
            IList<To_PaymentDetail> list = new List<To_PaymentDetail>();
            string sql = " select * from To_PaymentDetail ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_PaymentDetail to_paymentdetail = new To_PaymentDetail();
                    to_paymentdetail.Id = Convert.ToInt32(dr["id"]);
                    to_paymentdetail.PaymentID = Convert.ToString(dr["paymentID"]);
                    to_paymentdetail.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_paymentdetail.OrderPayId = Convert.ToInt32(dr["orderPayId"]);
                    to_paymentdetail.ShouldPay = Convert.ToDouble(dr["shouldPay"]);
                    to_paymentdetail.PayAmount = Convert.ToDouble(dr["payAmount"]);
                    list.Add(to_paymentdetail);
                }
            }
            return list;
        }
        /// <summary>
        ///
        /// </summary>
        public static To_PaymentDetail getTo_PaymentDetailBySql(string sql)
        {
            To_PaymentDetail to_paymentdetail = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_paymentdetail = new To_PaymentDetail();
                foreach (DataRow dr in dt.Rows)
                {
                    to_paymentdetail.Id = Convert.ToInt32(dr["id"]);
                    to_paymentdetail.PaymentID = Convert.ToString(dr["paymentID"]);
                    to_paymentdetail.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_paymentdetail.OrderPayId = Convert.ToInt32(dr["orderPayId"]);
                    to_paymentdetail.ShouldPay = Convert.ToDouble(dr["shouldPay"]);
                    to_paymentdetail.PayAmount = Convert.ToDouble(dr["payAmount"]);
                }
            }
            return to_paymentdetail;
        }

        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM To_PaymentDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDataSet(strSql.ToString());
        }

        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM To_PaymentDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.GetDataSet(strSql.ToString());
        }

        public static double GetSumByPaymentId(string paymentID)
        {
            string sql = " select SUM(payAmount) from To_PaymentDetail where paymentID='" + paymentID + "'";
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

        public static double GetHasAmount(string orderPayID)
        {
            string sql = " select SUM(payAmount) from View_PaymentDetail where orderPayId=" + orderPayID;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                double hasAmount = 0;
                double.TryParse(dt.Rows[0][0].ToString(), out hasAmount);
                return hasAmount;
            }
            else
            {
                return 0;
            }
        }

        public static DataTable GetOrderPayDetail(string strWhere)
        {
            string sql = " select * from View_PaymentDetail ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            return DBHelper.GetDataSet(sql);
        }

        public static double GetRealityHasAmount(string orderPayID)
        {
            string sql = " select SUM(payAmount) from View_PaymentDetail where auditstatus='04' and orderPayId=" + orderPayID;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                double hasAmount = 0;
                double.TryParse(dt.Rows[0][0].ToString(), out hasAmount);
                return hasAmount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 得到付款信息明细表中所需要的已经付款的明细数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetPayDetail(string strWhere)
        {
            string sql = " select * from ViewOrderPayDetail ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            return DBHelper.GetDataSet(sql);
        }
    }
}
