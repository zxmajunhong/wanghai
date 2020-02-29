using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_OrderInfo]表的数据访问类
    /// </summary>
    public class To_OrderInfoService
    {
        /// <summary>
        ///[To_OrderInfo]表添加的方法
        /// </summary>
        public static int addTo_OrderInfo(To_OrderInfo to_orderinfo)
        {
            string sql = "insert into To_OrderInfo([orderNum],[orderType],[outTime],[teamNum],[natrue],[tour],[tourRemark],[markId],[makerName],[makerTime],[gross],[jobflowID],[verify],[approvalID],[collectAmount],[collectCusID],[payAmount],[payCusID],[refundAmount],[refundID],[reimAmount],[reimID],[codeformat],[codenum],[departautocode],[iscancel],[inputer],[inputerID],[inputerTc]) values (@orderNum,@orderType,@outTime,@teamNum,@natrue,@tour,@tourRemark,@markId,@makerName,@makerTime,@gross,@jobflowID,@verify,@approvalID,@collectAmount,@collectCusID,@payAmount,@payCusID,@refundAmount,@refundID,@reimAmount,@reimID,@codeformat,@codenum,@departautocode,@iscancel,@inputer,@inputerID,@inputerTc);select @@IDENTITY";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@orderNum",to_orderinfo.OrderNum),
        new SqlParameter("@orderType",to_orderinfo.OrderType),
        new SqlParameter("@outTime",to_orderinfo.OutTime),
        new SqlParameter("@teamNum",to_orderinfo.TeamNum),
        new SqlParameter("@natrue",to_orderinfo.Natrue),
        new SqlParameter("@tour",to_orderinfo.Tour),
        new SqlParameter("@tourRemark",to_orderinfo.TourRemark),
        new SqlParameter("@markId",to_orderinfo.MarkId),
        new SqlParameter("@makerName",to_orderinfo.MakerName),
        new SqlParameter("@makerTime",to_orderinfo.MakerTime),
        new SqlParameter("@gross",to_orderinfo.Gross),
        new SqlParameter("@jobflowID",to_orderinfo.JobflowID),
        new SqlParameter("@verify",to_orderinfo.Verify),
        new SqlParameter("@approvalID",to_orderinfo.ApprovalID),
        new SqlParameter("@collectAmount",to_orderinfo.CollectAmount),
        new SqlParameter("@collectCusID",to_orderinfo.CollectCusID),
        new SqlParameter("@payAmount",to_orderinfo.PayAmount),
        new SqlParameter("@payCusID",to_orderinfo.PayCusID),
        new SqlParameter("@refundAmount",to_orderinfo.RefundAmount),
        new SqlParameter("@refundID",to_orderinfo.RefundID),
        new SqlParameter("@reimAmount",to_orderinfo.ReimAmount),
        new SqlParameter("@reimID",to_orderinfo.ReimID),
        new SqlParameter("@codeformat",to_orderinfo.Codeformat),
        new SqlParameter("@codenum",to_orderinfo.Codenum),
        new SqlParameter("@departautocode",to_orderinfo.DepartAutoCode),
        new SqlParameter("@iscancel",to_orderinfo.IsCancel),
        new SqlParameter("@inputer",to_orderinfo.Inputer),
        new SqlParameter("@inputerID",to_orderinfo.InputerID),
        new SqlParameter("@inputerTc",to_orderinfo.InputerTc)
      };
            //return DBHelper.ExecuteCommand(sql, sp);
            return DBHelper.ExecuteScalar(sql, sp);
        }

        /// <summary>
        ///[To_OrderInfo]表修改的方法
        /// </summary>
        public static int updateTo_OrderInfoById(To_OrderInfo to_orderinfo)
        {

            string sql = "update To_OrderInfo set orderNum=@orderNum,orderType=@orderType,outTime=@outTime,teamNum=@teamNum,natrue=@natrue,tour=@tour,tourRemark=@tourRemark,markId=@markId,makerName=@makerName,makerTime=@makerTime,gross=@gross,jobflowID=@jobflowID,verify=@verify,approvalID=@approvalID,collectAmount=@collectAmount,collectCusID=@collectCusID,payAmount=@payAmount,payCusID=@payCusID,refundAmount=@refundAmount,refundID=@refundID,reimAmount=@reimAmount,reimID=@reimID,codeformat=@codeformat,codenum=@codenum,departautocode=@departautocode,iscancel=@iscancel,inputer=@inputer,inputerID=@inputerID,inputerTc=@inputerTc where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",to_orderinfo.Id),
        new SqlParameter("@orderNum",to_orderinfo.OrderNum),
        new SqlParameter("@orderType",to_orderinfo.OrderType),
        new SqlParameter("@outTime",to_orderinfo.OutTime),
        new SqlParameter("@teamNum",to_orderinfo.TeamNum),
        new SqlParameter("@natrue",to_orderinfo.Natrue),
        new SqlParameter("@tour",to_orderinfo.Tour),
        new SqlParameter("@tourRemark",to_orderinfo.TourRemark),
        new SqlParameter("@markId",to_orderinfo.MarkId),
        new SqlParameter("@makerName",to_orderinfo.MakerName),
        new SqlParameter("@makerTime",to_orderinfo.MakerTime),
        new SqlParameter("@gross",to_orderinfo.Gross),
        new SqlParameter("@jobflowID",to_orderinfo.JobflowID),
        new SqlParameter("@verify",to_orderinfo.Verify),
        new SqlParameter("@approvalID",to_orderinfo.ApprovalID),
        new SqlParameter("@collectAmount",to_orderinfo.CollectAmount),
        new SqlParameter("@collectCusID",to_orderinfo.CollectCusID),
        new SqlParameter("@payAmount",to_orderinfo.PayAmount),
        new SqlParameter("@payCusID",to_orderinfo.PayCusID),
        new SqlParameter("@refundAmount",to_orderinfo.RefundAmount),
        new SqlParameter("@refundID",to_orderinfo.RefundID),
        new SqlParameter("@reimAmount",to_orderinfo.ReimAmount),
        new SqlParameter("@reimID",to_orderinfo.ReimID),
        new SqlParameter("@codeformat",to_orderinfo.Codeformat),
        new SqlParameter("@codenum",to_orderinfo.Codenum),
        new SqlParameter("@departautocode",to_orderinfo.DepartAutoCode),
        new SqlParameter("@iscancel",to_orderinfo.IsCancel),
        new SqlParameter("@inputer",to_orderinfo.Inputer),
        new SqlParameter("@inputerID",to_orderinfo.InputerID),
        new SqlParameter("@inputerTc",to_orderinfo.InputerTc)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_OrderInfo]表删除的方法
        /// </summary>
        public static int deleteTo_OrderInfoById(int id)
        {

            string sql = "delete from To_OrderInfo where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_OrderInfo]表查询实体的方法
        /// </summary>
        public static To_OrderInfo getTo_OrderInfoById(int id)
        {
            To_OrderInfo to_orderinfo = null;

            string sql = "select * from To_OrderInfo where id=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_orderinfo = new To_OrderInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    to_orderinfo.Id = Convert.ToInt32(dr["id"]);
                    to_orderinfo.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_orderinfo.OrderType = Convert.ToString(dr["orderType"]);
                    to_orderinfo.OutTime = Convert.ToDateTime(dr["outTime"]);
                    to_orderinfo.TeamNum = Convert.ToString(dr["teamNum"]);
                    to_orderinfo.Natrue = Convert.ToString(dr["natrue"]);
                    to_orderinfo.Tour = Convert.ToString(dr["tour"]);
                    to_orderinfo.TourRemark = Convert.ToString(dr["tourRemark"]);
                    to_orderinfo.MarkId = Convert.ToInt32(dr["markId"]);
                    to_orderinfo.MakerName = Convert.ToString(dr["makerName"]);
                    to_orderinfo.MakerTime = Convert.ToDateTime(dr["makerTime"]);
                    to_orderinfo.Gross = Convert.ToDouble(dr["gross"]);
                    to_orderinfo.JobflowID = Convert.ToInt32(dr["jobflowID"]);
                    to_orderinfo.Verify = Convert.ToInt32(dr["verify"]);
                    to_orderinfo.ApprovalID = Convert.ToInt32(dr["approvalID"]);
                    to_orderinfo.CollectAmount = Convert.ToDouble(dr["collectAmount"]);
                    to_orderinfo.CollectCusID = Convert.ToString(dr["collectCusID"]);
                    to_orderinfo.PayAmount = Convert.ToDouble(dr["payAmount"]);
                    to_orderinfo.PayCusID = Convert.ToString(dr["payCusID"]);
                    to_orderinfo.RefundAmount = Convert.ToDouble(dr["refundAmount"]);
                    to_orderinfo.RefundID = Convert.ToString(dr["refundID"]);
                    to_orderinfo.ReimAmount = Convert.ToDouble(dr["reimAmount"]);
                    to_orderinfo.ReimID = Convert.ToString(dr["reimID"]);
                    to_orderinfo.Codeformat = Convert.ToString(dr["codeformat"]);
                    to_orderinfo.Codenum = Convert.ToString(dr["codenum"]);
                    to_orderinfo.DepartAutoCode = Convert.ToString(dr["departautocode"]);
                    to_orderinfo.IsCancel = Convert.ToString(dr["iscancel"]);
                    to_orderinfo.Inputer = Convert.ToString(dr["inputer"]);
                    to_orderinfo.InputerID = Convert.ToInt32(dr["inputerID"]);
                    to_orderinfo.InputerTc = Convert.ToDouble(dr["inputerTc"]);
                    to_orderinfo.InputerTc_status = Convert.ToString(dr["inputerTc_status"]);
                }
            }

            return to_orderinfo;
        }

        /// <summary>
        ///[To_OrderInfo]表查询所有的方法
        /// </summary>
        public static IList<To_OrderInfo> getTo_OrderInfoAll()
        {
            string sql = "select * from To_OrderInfo";
            return getTo_OrderInfosBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_OrderInfo> getTo_OrderInfosBySql(string sql)
        {
            IList<To_OrderInfo> list = new List<To_OrderInfo>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_OrderInfo to_orderinfo = new To_OrderInfo();
                    to_orderinfo.Id = Convert.ToInt32(dr["id"]);
                    to_orderinfo.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_orderinfo.OrderType = Convert.ToString(dr["orderType"]);
                    to_orderinfo.OutTime = Convert.ToDateTime(dr["outTime"]);
                    to_orderinfo.TeamNum = Convert.ToString(dr["teamNum"]);
                    to_orderinfo.Natrue = Convert.ToString(dr["natrue"]);
                    to_orderinfo.Tour = Convert.ToString(dr["tour"]);
                    to_orderinfo.TourRemark = Convert.ToString(dr["tourRemark"]);
                    to_orderinfo.MarkId = Convert.ToInt32(dr["markId"]);
                    to_orderinfo.MakerName = Convert.ToString(dr["makerName"]);
                    to_orderinfo.MakerTime = Convert.ToDateTime(dr["makerTime"]);
                    to_orderinfo.Gross = Convert.ToDouble(dr["gross"]);
                    to_orderinfo.JobflowID = Convert.ToInt32(dr["jobflowID"]);
                    to_orderinfo.Verify = Convert.ToInt32(dr["verify"]);
                    to_orderinfo.ApprovalID = Convert.ToInt32(dr["approvalID"]);
                    to_orderinfo.CollectAmount = Convert.ToDouble(dr["collectAmount"]);
                    to_orderinfo.CollectCusID = Convert.ToString(dr["collectCusID"]);
                    to_orderinfo.PayAmount = Convert.ToDouble(dr["payAmount"]);
                    to_orderinfo.PayCusID = Convert.ToString(dr["payCusID"]);
                    to_orderinfo.RefundAmount = Convert.ToDouble(dr["refundAmount"]);
                    to_orderinfo.RefundID = Convert.ToString(dr["refundID"]);
                    to_orderinfo.ReimAmount = Convert.ToDouble(dr["reimAmount"]);
                    to_orderinfo.ReimID = Convert.ToString(dr["reimID"]);
                    to_orderinfo.Codeformat = Convert.ToString(dr["codeformat"]);
                    to_orderinfo.Codenum = Convert.ToString(dr["codenum"]);
                    to_orderinfo.DepartAutoCode = Convert.ToString(dr["departautocode"]);
                    to_orderinfo.IsCancel = Convert.ToString(dr["iscancel"]);
                    to_orderinfo.Inputer = Convert.ToString(dr["inputer"]);
                    to_orderinfo.InputerID = Convert.ToInt32(dr["inputerID"]);
                    to_orderinfo.InputerTc = Convert.ToDouble(dr["inputerTc"]);
                    to_orderinfo.InputerTc_status = Convert.ToString(dr["inputerTc_status"]);
                    list.Add(to_orderinfo);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_OrderInfo getTo_OrderInfoBySql(string sql)
        {
            To_OrderInfo to_orderinfo = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_orderinfo = new To_OrderInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    to_orderinfo.Id = Convert.ToInt32(dr["id"]);
                    to_orderinfo.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_orderinfo.OrderType = Convert.ToString(dr["orderType"]);
                    to_orderinfo.OutTime = Convert.ToDateTime(dr["outTime"]);
                    to_orderinfo.TeamNum = Convert.ToString(dr["teamNum"]);
                    to_orderinfo.Natrue = Convert.ToString(dr["natrue"]);
                    to_orderinfo.Tour = Convert.ToString(dr["tour"]);
                    to_orderinfo.TourRemark = Convert.ToString(dr["tourRemark"]);
                    to_orderinfo.MarkId = Convert.ToInt32(dr["markId"]);
                    to_orderinfo.MakerName = Convert.ToString(dr["makerName"]);
                    to_orderinfo.MakerTime = Convert.ToDateTime(dr["makerTime"]);
                    to_orderinfo.Gross = Convert.ToDouble(dr["gross"]);
                    to_orderinfo.JobflowID = Convert.ToInt32(dr["jobflowID"]);
                    to_orderinfo.Verify = Convert.ToInt32(dr["verify"]);
                    to_orderinfo.ApprovalID = Convert.ToInt32(dr["approvalID"]);
                    to_orderinfo.CollectAmount = Convert.ToDouble(dr["collectAmount"]);
                    to_orderinfo.CollectCusID = Convert.ToString(dr["collectCusID"]);
                    to_orderinfo.PayAmount = Convert.ToDouble(dr["payAmount"]);
                    to_orderinfo.PayCusID = Convert.ToString(dr["payCusID"]);
                    to_orderinfo.RefundAmount = Convert.ToDouble(dr["refundAmount"]);
                    to_orderinfo.RefundID = Convert.ToString(dr["refundID"]);
                    to_orderinfo.ReimAmount = Convert.ToDouble(dr["reimAmount"]);
                    to_orderinfo.ReimID = Convert.ToString(dr["reimID"]);
                    to_orderinfo.Codeformat = Convert.ToString(dr["codeformat"]);
                    to_orderinfo.Codenum = Convert.ToString(dr["codenum"]);
                    to_orderinfo.DepartAutoCode = Convert.ToString(dr["departautocode"]);
                    to_orderinfo.IsCancel = Convert.ToString(dr["iscancel"]);
                    to_orderinfo.Inputer = Convert.ToString(dr["inputer"]);
                    to_orderinfo.InputerID = Convert.ToInt32(dr["inputerID"]);
                    to_orderinfo.InputerTc = Convert.ToDouble(dr["inputerTc"]);
                    to_orderinfo.InputerTc_status = Convert.ToString(dr["inputerTc_status"]);
                }
            }
            return to_orderinfo;
        }

        /// <summary>
        /// 获得前几行数据
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
            strSql.Append(" FROM To_OrderInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }

        public static To_OrderInfo getLastOneID()
        {
            string sql = "select top 1 * from To_OrderInfo order by id desc";
            return getTo_OrderInfoBySql(sql);
        }

        public static DataTable GetLists(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from ViewOrder ");
            if (strWhere != "")
            {
                sql.Append(" where " + strWhere);
            }
            DataTable dt = DBHelper.GetDataSet(sql.ToString());
            return dt;
        }
        /// <summary>
        /// 查询视图数据
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable getList(string fields, string strWhere)
        {
            string str = "select ";

            if (fields != "")
            {
                str += fields;
            }
            else
            {
                str += " * ";
            }
            str += " from ViewOrder ";
            if (strWhere.Trim() != "")
            {
                str += " where " + strWhere;
            }

            return DBHelper.GetDataSet(str);
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetViewOrder(string fields, string strWhere)
        {
            string str = "select ";

            if (fields != "")
            {
                str += fields;
            }
            else
            {
                str += " * ";
            }
            str += " from View_OrderAndPay ";
            if (strWhere.Trim() != "")
            {
                str += " where " + strWhere;
            }

            return DBHelper.GetDataSet(str);
        }

        public static To_OrderInfo getTo_OrderInfoByOrderNum(string orderID)
        {
            To_OrderInfo to_orderinfo = null;

            string sql = "select * from To_OrderInfo where orderNum=@orderNum";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@orderNum",orderID)
             };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_orderinfo = new To_OrderInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    to_orderinfo.Id = Convert.ToInt32(dr["id"]);
                    to_orderinfo.OrderNum = Convert.ToString(dr["orderNum"]);
                    to_orderinfo.OrderType = Convert.ToString(dr["orderType"]);
                    to_orderinfo.OutTime = Convert.ToDateTime(dr["outTime"]);
                    to_orderinfo.TeamNum = Convert.ToString(dr["teamNum"]);
                    to_orderinfo.Natrue = Convert.ToString(dr["natrue"]);
                    to_orderinfo.Tour = Convert.ToString(dr["tour"]);
                    to_orderinfo.TourRemark = Convert.ToString(dr["tourRemark"]);
                    to_orderinfo.MarkId = Convert.ToInt32(dr["markId"]);
                    to_orderinfo.MakerName = Convert.ToString(dr["makerName"]);
                    to_orderinfo.MakerTime = Convert.ToDateTime(dr["makerTime"]);
                    to_orderinfo.Gross = Convert.ToDouble(dr["gross"]);
                    to_orderinfo.JobflowID = Convert.ToInt32(dr["jobflowID"]);
                    to_orderinfo.Verify = Convert.ToInt32(dr["verify"]);
                    to_orderinfo.ApprovalID = Convert.ToInt32(dr["approvalID"]);
                    to_orderinfo.CollectAmount = Convert.ToDouble(dr["collectAmount"]);
                    to_orderinfo.CollectCusID = Convert.ToString(dr["collectCusID"]);
                    to_orderinfo.PayAmount = Convert.ToDouble(dr["payAmount"]);
                    to_orderinfo.PayCusID = Convert.ToString(dr["payCusID"]);
                    to_orderinfo.RefundAmount = Convert.ToDouble(dr["refundAmount"]);
                    to_orderinfo.RefundID = Convert.ToString(dr["refundID"]);
                    to_orderinfo.ReimAmount = Convert.ToDouble(dr["reimAmount"]);
                    to_orderinfo.ReimID = Convert.ToString(dr["reimID"]);
                    to_orderinfo.Codeformat = Convert.ToString(dr["codeformat"]);
                    to_orderinfo.Codenum = Convert.ToString(dr["codenum"]);
                    to_orderinfo.DepartAutoCode = Convert.ToString(dr["departautocode"]);
                    to_orderinfo.IsCancel = Convert.ToString(dr["iscancel"]);
                    to_orderinfo.Inputer = Convert.ToString(dr["inputer"]);
                    to_orderinfo.InputerID = Convert.ToInt32(dr["inputerID"]);
                    to_orderinfo.InputerTc = Convert.ToDouble(dr["inputerTc"]);
                    to_orderinfo.InputerTc_status = Convert.ToString(dr["inputerTc_status"]);
                }
            }

            return to_orderinfo;
        }

        /// <summary>
        /// 得到订单中的退款信息
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetViewOrderReturn(string fields, string strWhere)
        {
            string str = " select ";
            if (fields != "")
            {
                str += fields;
            }
            else
            {
                str += " * ";
            }
            str += " from View_OrderAndReturn ";
            if (strWhere.Trim() != "")
            {
                str += " where " + strWhere;
            }
            return DBHelper.GetDataSet(str);
        }

        /// <summary>
        /// 更新订单的实际毛利
        /// </summary>
        /// <param name="jobflowid"></param>
        /// <param name="sjgross"></param>
        /// <returns></returns>
        public static int updateOrdersjGross(string jobflowid, string sjgross)
        {
            string sql = " update To_OrderInfo set sjgross=@sjgross where jobflowID=@jobflowID";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@sjgross",sjgross),
                new SqlParameter("@jobflowID",jobflowid)
            };

            return DBHelper.ExecuteCommand(sql, sp);
        }

        public static int Clear()
        {
            string sql = "truncate table To_OrderInfo;truncate table To_OrderCollectDetial;truncate table To_OrderPayDetial;truncate table To_OrderRefunDetial;truncate table To_OrderReimDetial;";
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 更新订单的发票情况
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="invoiceStatus"></param>
        /// <returns></returns>
        public static int updateOrderInvoice(string orderid, string invoiceStatus)
        {
            string sql = " update To_OrderInfo set invoiceStatus=@invoiceStatus where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@invoiceStatus",invoiceStatus),
                new SqlParameter("@id",orderid)
            };

            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        /// 验证订单是否能够删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CanDelete(int id)
        {
            bool result = true;
            string sqlpay = " select * from To_PaymentDetail where orderPayId in ( select id from To_OrderPayDetial where orderid=" + id + " )";
            string sqlret = " select * from To_PaymentReturn where orderRetID in ( select id from To_OrderRefunDetial where orderid=" + id + " )";
            string sqlcol = " select * from To_ClaimDetail where orderCollectId in ( select id from To_OrderCollectDetial where orderid=" + id + " )";
            string sqlreim = " select * from AusOrderInfo where orderId=" + id;
            DataTable dtpay = DBHelper.GetDataSet(sqlpay);
            DataTable dtret = DBHelper.GetDataSet(sqlret);
            DataTable dtcol = DBHelper.GetDataSet(sqlcol);
            DataTable dtreim = DBHelper.GetDataSet(sqlreim);

            if (dtpay.Rows.Count > 0 || dtret.Rows.Count > 0 || dtcol.Rows.Count > 0 || dtcol.Rows.Count > 0)
            {
                result = false;
            }

            return result;
        }

        public static DataTable GetViewOrderAndCollect(string fields, string strWhere)
        {
            string str = "select ";

            if (fields != "")
            {
                str += fields;
            }
            else
            {
                str += " * ";
            }
            str += " from View_OrderAndClollect ";
            if (strWhere.Trim() != "")
            {
                str += " where " + strWhere;
            }

            return DBHelper.GetDataSet(str);
        }

        public static DataTable GetViewOrderAndReturn(string fields, string strWhere)
        {
            string str = "select ";

            if (fields != "")
            {
                str += fields;
            }
            else
            {
                str += " * ";
            }
            str += " from View_OrderAndReturn ";
            if (strWhere.Trim() != "")
            {
                str += " where " + strWhere;
            }

            return DBHelper.GetDataSet(str);
        }

        public static bool updateInputerTcStatus(string strWhere, string status)
        {
            string sql = "update To_OrderInfo set inputerTc_status='" + status + "'";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            int result = DBHelper.ExecuteCommand(sql);
            return result > 0;
        }

        public static bool updateFileStatus(int status, int id)
        {
            string sql = "update To_OrderInfo set fileStatus=@fileStatus where id=@id ";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@fileStatus",status),
                new SqlParameter("@id",id)
            };
            int result = DBHelper.ExecuteCommand(sql, sp);
            return result > 0;
        }

        public static bool updateOrderGross(To_OrderInfo orderInfo)
        {
            string sql = "update To_OrderInfo set gross=@gross where id=@id ";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@gross",orderInfo.Gross),
                new SqlParameter("@id",orderInfo.Id)
            };
            return DBHelper.ExecuteCommand(sql, sp) > 0;
        }

        /// <summary>
        /// 获取指定表格指定字段数据
        /// </summary>
        /// <param name="tblname"></param>
        /// <param name="fields"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetTableInfo(string tblname, string fields, string strWhere)
        {
            string str = "select ";
            if (fields != "")
            {
                str += fields;
            }
            else
            {
                str += " * ";
            }
            str += " from " + tblname;
            if (strWhere.Trim() != "") 
            {
                str += " where 1=1 " + strWhere;
            }
            return DBHelper.GetDataSet(str);
        }
    }
}
