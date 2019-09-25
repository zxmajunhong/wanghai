using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_Collecting]表的数据访问类
    /// </summary>
    public class To_CollectingService
    {
        /// <summary>
        ///[To_Collecting]表添加的方法
        /// </summary>
        public static int addTo_Collecting(To_Collecting to_collecting)
        {
            string sql = "insert into To_Collecting([receiptNum],[receiptAmount],[receiptDate],[businessUnit],[businessUnitID],[paymentUnit],[paymentUnitID],[paymentMode],[marker],[markerID],[markerDepartment],[markerDepartmentID],[markDate],[receiptMark],[payBank],[payBankAcount],[confirmReceipt],[receiptStatusCode],[orderNum],[codeFormat],[payBankId]) values (@receiptNum,@receiptAmount,@receiptDate,@businessUnit,@businessUnitID,@paymentUnit,@paymentUnitID,@paymentMode,@marker,@markerID,@markerDepartment,@markerDepartmentID,@markDate,@receiptMark,@payBank,@payBankAcount,@confirmReceipt,@receiptStatusCode,@orderNum,@codeFormat,@payBankId);select @@IDENTITY";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@receiptNum",to_collecting.ReceiptNum),
        new SqlParameter("@receiptAmount",to_collecting.ReceiptAmount),
        new SqlParameter("@receiptDate",to_collecting.ReceiptDate),
        new SqlParameter("@businessUnit",to_collecting.BusinessUnit),
        new SqlParameter("@businessUnitID",to_collecting.BusinessUnitID),
        new SqlParameter("@paymentUnit",to_collecting.PaymentUnit),
        new SqlParameter("@paymentUnitID",to_collecting.PaymentUnitID),
        new SqlParameter("@paymentMode",to_collecting.PaymentMode),
        new SqlParameter("@marker",to_collecting.Marker),
        new SqlParameter("@markerID",to_collecting.MarkerID),
        new SqlParameter("@markerDepartment",to_collecting.MarkerDepartment),
        new SqlParameter("@markerDepartmentID",to_collecting.MarkerDepartmentID),
        new SqlParameter("@markDate",to_collecting.MarkDate),
        new SqlParameter("@receiptMark",to_collecting.ReceiptMark),
        new SqlParameter("@payBank",to_collecting.PayBank),
        new SqlParameter("@payBankAcount",to_collecting.PayBankAcount),
        new SqlParameter("@confirmReceipt",to_collecting.ConfirmReceipt),
        new SqlParameter("@receiptStatusCode",to_collecting.receiptStatusCode),
        new SqlParameter("@orderNum",to_collecting.orderNum),
        new SqlParameter("@codeFormat",to_collecting.codeFormat),
        new SqlParameter("@payBankId",to_collecting.payBankId),
      };
            using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.Connection = conn;
                sqlCmd.Parameters.AddRange(sp);

                object objResult = sqlCmd.ExecuteScalar();

                return objResult != null && objResult != DBNull.Value ? Convert.ToInt32(objResult) : 0;

            }
        }

        /// <summary>
        ///[To_Collecting]表修改的方法
        /// </summary>
        public static int updateTo_CollectingById(To_Collecting to_collecting)
        {

            string sql = "update To_Collecting set receiptNum=@receiptNum,receiptAmount=@receiptAmount,receiptDate=@receiptDate,businessUnit=@businessUnit,businessUnitID=@businessUnitID,paymentUnit=@paymentUnit,paymentUnitID=@paymentUnitID,paymentMode=@paymentMode,marker=@marker,markerID=@markerID,markerDepartment=@markerDepartment,markerDepartmentID=@markerDepartmentID,markDate=@markDate,receiptMark=@receiptMark,payBank=@payBank,payBankAcount=@payBankAcount,confirmReceipt=@confirmReceipt,receiptStatusCode=@receiptStatusCode,orderNum=@orderNum,codeFormat=@codeFormat,payBankId=@payBankId where ID=@ID";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@ID",to_collecting.ID),
        new SqlParameter("@receiptNum",to_collecting.ReceiptNum),
        new SqlParameter("@receiptAmount",to_collecting.ReceiptAmount),
        new SqlParameter("@receiptDate",to_collecting.ReceiptDate),
        new SqlParameter("@businessUnit",to_collecting.BusinessUnit),
        new SqlParameter("@businessUnitID",to_collecting.BusinessUnitID),
        new SqlParameter("@paymentUnit",to_collecting.PaymentUnit),
        new SqlParameter("@paymentUnitID",to_collecting.PaymentUnitID),
        new SqlParameter("@paymentMode",to_collecting.PaymentMode),
        new SqlParameter("@marker",to_collecting.Marker),
        new SqlParameter("@markerID",to_collecting.MarkerID),
        new SqlParameter("@markerDepartment",to_collecting.MarkerDepartment),
        new SqlParameter("@markerDepartmentID",to_collecting.MarkerDepartmentID),
        new SqlParameter("@markDate",to_collecting.MarkDate),
        new SqlParameter("@receiptMark",to_collecting.ReceiptMark),
        new SqlParameter("@payBank",to_collecting.PayBank),
        new SqlParameter("@payBankAcount",to_collecting.PayBankAcount),
        new SqlParameter("@confirmReceipt",to_collecting.ConfirmReceipt),
        new SqlParameter("@receiptStatusCode",to_collecting.receiptStatusCode),
        new SqlParameter("@orderNum",to_collecting.orderNum),
        new SqlParameter("@codeFormat",to_collecting.codeFormat),
        new SqlParameter("@payBankId",to_collecting.payBankId)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        /// 更新收款单的单位信息
        /// </summary>
        /// <param name="to_collecting"></param>
        /// <returns></returns>
        public static int updateTo_CollectPaymentUnit(To_Collecting to_collecting)
        {
            string sql = " update To_Collecting set paymentUnit=@paymentUnit,paymentUnitID=@paymentUnitID where ID=@ID ";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@ID",to_collecting.ID),
                new SqlParameter("@paymentUnit",to_collecting.PaymentUnit),
                new SqlParameter("@paymentUnitID",to_collecting.PaymentUnitID)
            };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_Collecting]表删除的方法
        /// </summary>
        public static int deleteTo_CollectingById(int ID)
        {

            string sql = "delete from To_Collecting where ID=@ID";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@ID",ID)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_Collecting]表查询实体的方法
        /// </summary>
        public static To_Collecting getTo_CollectingById(int ID)
        {
            To_Collecting to_collecting = null;

            string sql = "select * from To_Collecting where ID=@ID";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@ID",ID)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_collecting = new To_Collecting();
                foreach (DataRow dr in dt.Rows)
                {
                    to_collecting.ID = Convert.ToInt32(dr["ID"]);
                    to_collecting.ReceiptNum = Convert.ToString(dr["receiptNum"]);
                    to_collecting.ReceiptAmount = Convert.ToDouble(dr["receiptAmount"]);
                    to_collecting.ReceiptDate = Convert.ToDateTime(dr["receiptDate"]);
                    to_collecting.BusinessUnit = Convert.ToString(dr["businessUnit"]);
                    to_collecting.BusinessUnitID = Convert.ToInt32(dr["businessUnitID"]);
                    to_collecting.PaymentUnit = Convert.ToString(dr["paymentUnit"]);
                    to_collecting.PaymentUnitID = Convert.ToInt32(dr["paymentUnitID"]);
                    to_collecting.PaymentMode = Convert.ToInt32(dr["paymentMode"]);
                    to_collecting.Marker = Convert.ToString(dr["marker"]);
                    to_collecting.MarkerID = Convert.ToInt32(dr["markerID"]);
                    to_collecting.MarkerDepartment = Convert.ToString(dr["markerDepartment"]);
                    to_collecting.MarkerDepartmentID = Convert.ToInt32(dr["markerDepartmentID"]);
                    to_collecting.MarkDate = Convert.ToDateTime(dr["markDate"]);
                    to_collecting.ReceiptMark = Convert.ToString(dr["receiptMark"]);

                    to_collecting.payBankId = Convert.IsDBNull(dr["payBankId"]) ? 0 : Convert.ToInt32(dr["payBankId"]);

                    to_collecting.PayBank = Convert.ToString(dr["payBank"]);
                    to_collecting.PayBankAcount = Convert.ToString(dr["payBankAcount"]);
                    to_collecting.ConfirmReceipt = Convert.ToInt32(dr["confirmReceipt"]);
                    to_collecting.receiptStatusCode = Convert.ToInt32(dr["receiptStatusCode"]);
                    to_collecting.orderNum = Convert.ToString(dr["orderNum"]);
                    to_collecting.codeFormat = Convert.ToString(dr["codeFormat"]);
                }
            }

            return to_collecting;
        }

        /// <summary>
        ///[To_Collecting]表查询所有的方法
        /// </summary>
        public static IList<To_Collecting> getTo_CollectingAll()
        {
            string sql = "select * from To_Collecting order by markDate";
            return getTo_CollectingsBySql(sql);
        }


        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_Collecting> getTo_CollectingsBySql(string sql)
        {
            IList<To_Collecting> list = new List<To_Collecting>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_Collecting to_collecting = new To_Collecting();
                    to_collecting.ID = Convert.ToInt32(dr["ID"]);
                    to_collecting.ReceiptNum = Convert.ToString(dr["receiptNum"]);
                    to_collecting.ReceiptAmount = Convert.ToDouble(dr["receiptAmount"]);
                    to_collecting.ReceiptDate = Convert.ToDateTime(dr["receiptDate"]);
                    to_collecting.BusinessUnit = Convert.ToString(dr["businessUnit"]);
                    to_collecting.BusinessUnitID = Convert.ToInt32(dr["businessUnitID"]);
                    to_collecting.PaymentUnit = Convert.ToString(dr["paymentUnit"]);
                    to_collecting.PaymentUnitID = Convert.ToInt32(dr["paymentUnitID"]);
                    to_collecting.PaymentMode = Convert.ToInt32(dr["paymentMode"]);
                    to_collecting.Marker = Convert.ToString(dr["marker"]);
                    to_collecting.MarkerID = Convert.ToInt32(dr["markerID"]);
                    to_collecting.MarkerDepartment = Convert.ToString(dr["markerDepartment"]);
                    to_collecting.MarkerDepartmentID = Convert.ToInt32(dr["markerDepartmentID"]);
                    to_collecting.MarkDate = Convert.ToDateTime(dr["markDate"]);
                    to_collecting.ReceiptMark = Convert.ToString(dr["receiptMark"]);

                    to_collecting.payBankId = Convert.IsDBNull(dr["payBankId"]) ? 0 : Convert.ToInt32(dr["payBankId"]);

                    to_collecting.PayBank = Convert.ToString(dr["payBank"]);
                    to_collecting.PayBankAcount = Convert.ToString(dr["payBankAcount"]);
                    to_collecting.ConfirmReceipt = Convert.ToInt32(dr["confirmReceipt"]);
                    to_collecting.receiptStatusCode = Convert.ToInt32(dr["receiptStatusCode"]);
                    to_collecting.orderNum = Convert.ToString(dr["orderNum"]);
                    to_collecting.codeFormat = Convert.ToString(dr["codeFormat"]);
                    list.Add(to_collecting);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_Collecting getTo_CollectingBySql(string sql)
        {
            To_Collecting to_collecting = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_collecting = new To_Collecting();
                foreach (DataRow dr in dt.Rows)
                {
                    to_collecting.ID = Convert.ToInt32(dr["ID"]);
                    to_collecting.ReceiptNum = Convert.ToString(dr["receiptNum"]);
                    to_collecting.ReceiptAmount = Convert.ToDouble(dr["receiptAmount"]);
                    to_collecting.ReceiptDate = Convert.ToDateTime(dr["receiptDate"]);
                    to_collecting.BusinessUnit = Convert.ToString(dr["businessUnit"]);
                    to_collecting.BusinessUnitID = Convert.ToInt32(dr["businessUnitID"]);
                    to_collecting.PaymentUnit = Convert.ToString(dr["paymentUnit"]);
                    to_collecting.PaymentUnitID = Convert.ToInt32(dr["paymentUnitID"]);
                    to_collecting.PaymentMode = Convert.ToInt32(dr["paymentMode"]);
                    to_collecting.Marker = Convert.ToString(dr["marker"]);
                    to_collecting.MarkerID = Convert.ToInt32(dr["markerID"]);
                    to_collecting.MarkerDepartment = Convert.ToString(dr["markerDepartment"]);
                    to_collecting.MarkerDepartmentID = Convert.ToInt32(dr["markerDepartmentID"]);
                    to_collecting.MarkDate = Convert.ToDateTime(dr["markDate"]);
                    to_collecting.ReceiptMark = Convert.ToString(dr["receiptMark"]);

                    to_collecting.payBankId = Convert.ToInt32(dr["payBankId"]);

                    to_collecting.PayBank = Convert.ToString(dr["payBank"]);
                    to_collecting.PayBankAcount = Convert.ToString(dr["payBankAcount"]);
                    to_collecting.ConfirmReceipt = Convert.ToInt32(dr["confirmReceipt"]);
                    to_collecting.receiptStatusCode = Convert.ToInt32(dr["receiptStatusCode"]);
                    to_collecting.orderNum = Convert.ToString(dr["orderNum"]);
                    to_collecting.codeFormat = Convert.ToString(dr["codeFormat"]);
                }
            }
            return to_collecting;
        }


        #region 后添加方法
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <returns></returns>
        public static IList<To_Collecting> GetListByPage(string strWhere, int userID, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.markDate desc,T.ID desc ");
            strSql.Append(")AS Row, T.*  from To_Collecting T ");

            //2016年10月9号注释
            //string ids = LoginDataLimitServices.GetLimit(userID);
            //if (string.IsNullOrEmpty(ids))
            //{
            //    strSql.AppendFormat(" WHERE markerID = {0}", userID);
            //}
            //else
            //{
            //    strSql.AppendFormat(" WHERE markerID in ({0},{1})", ids, userID);
            //}

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where 1= 1 ");
                strSql.Append(strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.AppendFormat(" order by receiptDate desc");//0429 按照收款登记日期排序
            return getTo_CollectingsBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListByLimit(string strWhere, int userID, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.markDate desc,T.ID desc ");
            strSql.Append(")AS Row, T.*  from View_Renling T ");

            //2016年10月9号注释

            //string ids = To_ReceiptLimitService.GetReceiptList(userID);
            //if (string.IsNullOrEmpty(ids))
            //{
            //    strSql.AppendFormat(" WHERE markerID = {0}", userID);
            //}
            //else
            //{
            //    strSql.AppendFormat(" WHERE ( ID in ({0}) or markerID = {1} ) ", ids, userID);
            //}

            //strSql.AppendFormat(" AND ( makerID = {0} or makerID is null ) ", userID);
             

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where 1= 1 ");
                strSql.Append(strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.AppendFormat(" order by TT.receiptStatusCode asc, TT.receiptDate desc");//0429 增加排序字段

            return DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCountByLimit(string where, int userID)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT COUNT(*) FROM View_Renling ");
            string ids = To_ReceiptLimitService.GetReceiptList(userID);
            if (string.IsNullOrEmpty(ids))
            {
                sqlBuilder.AppendFormat(" WHERE markerID = {0}", userID);
            }
            else
            {
                sqlBuilder.AppendFormat(" WHERE ( ID in ({0}) or markerID = {1} ) ", ids, userID);
            }
            sqlBuilder.AppendFormat(" AND ( makerID = {0} or makerID is null ) ", userID);

            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.Append(where);
            }

            using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlBuilder.ToString(), conn);
                object result = sqlCmd.ExecuteScalar();
                return result == null ? 0 : int.Parse(result.ToString());
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static int GetTotalCount(string where, int userID)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT COUNT(*) FROM To_Collecting ");
            string ids = LoginDataLimitServices.GetLimit(userID);
            if (string.IsNullOrEmpty(ids))
            {
                sqlBuilder.AppendFormat(" WHERE markerID = {0}", userID);
            }
            else
            {
                sqlBuilder.AppendFormat(" WHERE markerID in ({0},{1})", ids, userID);
            }
            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.Append(where);
            }

            using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlBuilder.ToString(), conn);
                object result = sqlCmd.ExecuteScalar();
                return result == null ? 0 : int.Parse(result.ToString());
            }
        }

        /// <summary>
        /// 判断单据是否已确认
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CancelConfirm(int id)
        {
            string sql = "update To_Collecting set confirmReceipt=0 where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",id)
            };

            return DBHelper.ExecuteCommand(sql, sp) > 0;
        }
        public static void ChangeClaim(int collectingID, int receiptStatusCode)
        {
            string sql = "update To_Collecting set receiptStatusCode=@code where ID=@id ";
            SqlParameter[] pa = new SqlParameter[] { 
                new SqlParameter("@code",receiptStatusCode),
                new SqlParameter("@id", collectingID)
            };

            DBHelper.ExecuteCommand(sql, pa);
        }

        /// <summary>
        /// 根据收款单据ID获取收款金额
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetAmount(int ID)
        {
            string sql = "select receiptAmount from To_Collecting where ID=@ID ";
            using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@ID", ID);

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;

                sqlCmd.CommandText = sql;
                sqlCmd.Parameters.Add(param);

                object objResult = sqlCmd.ExecuteScalar();

                return objResult == null ? string.Empty : objResult.ToString();
            }
        }

        /// <summary>
        /// 根据收款单据ID查询认领明细
        /// </summary>
        /// <param name="collcetingID"></param>
        /// <returns></returns>
        public static DataTable GetClaimDetail(int collcetingID)
        {
            string sql = "select * from ViewCollecting where collectingID=@collectingID ";

            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@collectingID",collcetingID)
            };

            return DBHelper.GetDataSet(sql, param);
        }
        #endregion


        public static int Clear()
        {
            string sql = "truncate table To_Collecting; truncate table To_Claim;truncate table To_ClaimDetail;";
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 获得前几行数据(自动编码需要)
        /// </summary>
        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM To_Collecting ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 更新收款登记确认信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="confirmMan"></param>
        /// <param name="confirmDate"></param>
        /// <returns></returns>
        public static int updateConfirm(string id, string confirmMan, string confirmDate)
        {
            string sql = " update To_Collecting set confirmMan=@confirmMan,confirmDate=@confirmDate,confirmReceipt=1 where ID=@ID";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@ID",id),
                new SqlParameter("@confirmMan",confirmMan),
                new SqlParameter("@confirmDate",confirmDate)
            };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        /// 得到确认信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable getConfirmInfo(string id)
        {
            string sql = "select * from To_Collecting where ID=" + id;
            return DBHelper.GetDataSet(sql);
        }
    }
}
