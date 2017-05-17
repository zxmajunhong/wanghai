using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_OrderPayDetial]表的数据访问类
    /// </summary>
    public class To_OrderPayDetialService
    {
        /// <summary>
        ///[To_OrderPayDetial]表添加的方法
        /// </summary>
        public static int addTo_OrderPayDetial(To_OrderPayDetial to_orderpaydetial)
        {
            string sql = "insert into To_OrderPayDetial([orderid],[factid],[supName],[money],[payConfirm],[payStatus],[payType],[linkID],[linkName],[remark],[payNum],[payChildNum]) values (@orderid,@factid,@supName,@money,@payConfirm,@payStatus,@payType,@linkID,@linkName,@remark,@payNum,@payChildNum)";
            SqlParameter[] sp = new SqlParameter[]
              {
                new SqlParameter("@orderid",to_orderpaydetial.Orderid),
                new SqlParameter("@factid",to_orderpaydetial.Factid),
                new SqlParameter("@supName",to_orderpaydetial.SupName),
                new SqlParameter("@money",to_orderpaydetial.Money),
                new SqlParameter("@payConfirm",to_orderpaydetial.PayConfirm),
                new SqlParameter("@payStatus",to_orderpaydetial.PayStatus),
                new SqlParameter("@payType",to_orderpaydetial.PayType),
                new SqlParameter("@linkID",to_orderpaydetial.LinkID),
                new SqlParameter("@linkName",to_orderpaydetial.LinkName),
                new SqlParameter("@remark",to_orderpaydetial.Remark),
                new SqlParameter("@payNum",to_orderpaydetial.PayNum),
                new SqlParameter("@payChildNum",to_orderpaydetial.PayChildNum)
              };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_OrderPayDetial]表修改的方法
        /// </summary>
        public static int updateTo_OrderPayDetialById(To_OrderPayDetial to_orderpaydetial)
        {

            string sql = "update To_OrderPayDetial set orderid=@orderid,factid=@factid,supName=@supName,money=@money,payConfirm=@payConfirm,payStatus=@payStatus,payAmount=@payAmount,payType=@payType,linkID=@linkID,linkName=@linkName,remark=@remark,payNum=@payNum,payChildNum=@payChildNum where id=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
                new SqlParameter("@id",to_orderpaydetial.Id),
                new SqlParameter("@orderid",to_orderpaydetial.Orderid),
                new SqlParameter("@factid",to_orderpaydetial.Factid),
                new SqlParameter("@supName",to_orderpaydetial.SupName),
                new SqlParameter("@money",to_orderpaydetial.Money),
                new SqlParameter("@payConfirm",to_orderpaydetial.PayConfirm),
                new SqlParameter("@payStatus",to_orderpaydetial.PayStatus),
                new SqlParameter("@payAmount",to_orderpaydetial.PayAmount),
                new SqlParameter("@payType",to_orderpaydetial.PayType),
                new SqlParameter("@linkID",to_orderpaydetial.LinkID),
                new SqlParameter("@linkName",to_orderpaydetial.LinkName),
                new SqlParameter("@remark",to_orderpaydetial.Remark),
                new SqlParameter("@payNum",to_orderpaydetial.PayNum),
                new SqlParameter("@payChildNum",to_orderpaydetial.PayChildNum)
             };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_OrderPayDetial]表删除的方法
        /// </summary>
        public static int deleteTo_OrderPayDetialById(int id)
        {

            string sql = "delete from To_OrderPayDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_OrderPayDetial]表查询实体的方法
        /// </summary>
        public static To_OrderPayDetial getTo_OrderPayDetialById(int id)
        {
            To_OrderPayDetial to_orderpaydetial = null;

            string sql = "select * from To_OrderPayDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@id",id)
             };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_orderpaydetial = new To_OrderPayDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_orderpaydetial.Id = Convert.ToInt32(dr["id"]);
                    to_orderpaydetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_orderpaydetial.Factid = Convert.ToInt32(dr["factid"]);
                    to_orderpaydetial.SupName = Convert.ToString(dr["supName"]);
                    to_orderpaydetial.Money = Convert.ToDouble(dr["money"]);
                    to_orderpaydetial.PayConfirm = Convert.ToString(dr["payConfirm"]);
                    to_orderpaydetial.PayStatus = Convert.ToString(dr["payStatus"]);
                    to_orderpaydetial.PayAmount = Convert.ToDouble(dr["payAmount"] == DBNull.Value ? 0.00 : dr["payAmount"]);
                    to_orderpaydetial.PayType = Convert.ToString(dr["payType"]);
                    to_orderpaydetial.LinkID = Convert.ToInt32(dr["linkID"] == DBNull.Value ? 0 : dr["linkID"]);
                    to_orderpaydetial.LinkName = Convert.ToString(dr["linkName"]);
                    to_orderpaydetial.Remark = Convert.ToString(dr["remark"]);
                    to_orderpaydetial.PayNum = Convert.ToInt32(dr["payNum"]);
                    to_orderpaydetial.PayChildNum = Convert.ToInt32(dr["payChildNum"]);
                }
            }

            return to_orderpaydetial;
        }

        /// <summary>
        ///[To_OrderPayDetial]表查询所有的方法
        /// </summary>
        public static IList<To_OrderPayDetial> getTo_OrderPayDetialAll()
        {
            string sql = "select * from To_OrderPayDetial";
            return getTo_OrderPayDetialsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_OrderPayDetial> getTo_OrderPayDetialsBySql(string sql)
        {
            IList<To_OrderPayDetial> list = new List<To_OrderPayDetial>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_OrderPayDetial to_orderpaydetial = new To_OrderPayDetial();
                    to_orderpaydetial.Id = Convert.ToInt32(dr["id"]);
                    to_orderpaydetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_orderpaydetial.Factid = Convert.ToInt32(dr["factid"]);
                    to_orderpaydetial.SupName = Convert.ToString(dr["supName"]);
                    to_orderpaydetial.Money = Convert.ToDouble(dr["money"]);
                    to_orderpaydetial.PayConfirm = Convert.ToString(dr["payConfirm"]);
                    to_orderpaydetial.PayStatus = Convert.ToString(dr["payStatus"]);
                    to_orderpaydetial.PayAmount = Convert.ToDouble(dr["payAmount"] == DBNull.Value ? 0.00 : dr["payAmount"]);
                    to_orderpaydetial.PayType = Convert.ToString(dr["payType"]);
                    to_orderpaydetial.LinkID = Convert.ToInt32(dr["linkID"] == DBNull.Value ? 0 : dr["linkID"]);
                    to_orderpaydetial.LinkName = Convert.ToString(dr["linkName"]);
                    to_orderpaydetial.Remark = Convert.ToString(dr["remark"]);
                    to_orderpaydetial.PayNum = Convert.ToInt32(dr["payNum"]);
                    to_orderpaydetial.PayChildNum = Convert.ToInt32(dr["payChildNum"]);
                    list.Add(to_orderpaydetial);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_OrderPayDetial getTo_OrderPayDetialBySql(string sql)
        {
            To_OrderPayDetial to_orderpaydetial = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_orderpaydetial = new To_OrderPayDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_orderpaydetial.Id = Convert.ToInt32(dr["id"]);
                    to_orderpaydetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_orderpaydetial.Factid = Convert.ToInt32(dr["factid"]);
                    to_orderpaydetial.SupName = Convert.ToString(dr["supName"]);
                    to_orderpaydetial.Money = Convert.ToDouble(dr["money"]);
                    to_orderpaydetial.PayConfirm = Convert.ToString(dr["payConfirm"]);
                    to_orderpaydetial.PayStatus = Convert.ToString(dr["payStatus"]);
                    to_orderpaydetial.PayAmount = Convert.ToDouble(dr["payAmount"]);
                    to_orderpaydetial.PayType = Convert.ToString(dr["payType"]);
                    to_orderpaydetial.LinkID = Convert.ToInt32(dr["linkID"] == DBNull.Value ? 0 : dr["linkID"]);
                    to_orderpaydetial.LinkName = Convert.ToString(dr["linkName"]);
                    to_orderpaydetial.Remark = Convert.ToString(dr["remark"]);
                    to_orderpaydetial.PayNum = Convert.ToInt32(dr["payNum"]);
                    to_orderpaydetial.PayChildNum = Convert.ToInt32(dr["payChildNum"]);
                }
            }
            return to_orderpaydetial;
        }

        public static int deleteTo_OrderPayDetialByOrderID(int orderid)
        {
            string sql = "delete from To_OrderPayDetial where orderid=@orderid";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@orderid",orderid)
             };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from To_OrderPayDetial where orderid = " + id;
            return DBHelper.GetDataSet(sql);
        }

        public static IList<To_OrderPayDetial> getTo_OrderPayDetialByOrderId(int orderID)
        {
            string sql = "select * from To_OrderPayDetial where orderid=" + orderID;
            return getTo_OrderPayDetialsBySql(sql);
        }

        /// <summary>
        /// 根据sql条件删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int deleteTo_orderPayDetailbySql(string sql)
        {
            string sqlwhere = "delete from To_OrderPayDetial where " + sql;
            return DBHelper.ExecuteCommand(sqlwhere);
        }

        /// <summary>
        /// 更新付款明细信息的付款状态和实际付款金额
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getstatus"></param>
        /// <param name="hasAmount"></param>
        /// <returns></returns>
        public static int updateDetialStatusAndMoney(string id, string getstatus, string hasAmount)
        {
            string sql = " update To_OrderPayDetial set payStatus=@payStatus,payAmount=@payAmount where id=@id ";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",id),
                new SqlParameter("@payStatus",getstatus),
                new SqlParameter("@payAmount",hasAmount)
            };

            return DBHelper.ExecuteCommand(sql, sp);
        }
    }
}
