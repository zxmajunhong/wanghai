using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_OrderRefunDetial]表的数据访问类
    /// </summary>
    public class To_OrderRefunDetialService
    {
        /// <summary>
        ///[To_OrderRefunDetial]表添加的方法
        /// </summary>
        public static int addTo_OrderRefunDetial(To_OrderRefunDetial to_orderrefundetial)
        {
            string sql = "insert into To_OrderRefunDetial([orderid],[cusid],[cusName],[money],[refundAmount],[refundStatus],[remark]) values (@orderid,@cusid,@cusName,@money,@refundAmount,@refundStatus,@remark)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@orderid",to_orderrefundetial.Orderid),
        new SqlParameter("@cusid",to_orderrefundetial.Cusid),
        new SqlParameter("@cusName",to_orderrefundetial.CusName),
        new SqlParameter("@money",to_orderrefundetial.Money),
        new SqlParameter("@refundAmount",to_orderrefundetial.RefundAmount),
        new SqlParameter("@refundStatus",to_orderrefundetial.RefundStatus),
        new SqlParameter("@remark",to_orderrefundetial.Remark)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_OrderRefunDetial]表修改的方法
        /// </summary>
        public static int updateTo_OrderRefunDetialById(To_OrderRefunDetial to_orderrefundetial)
        {

            string sql = "update To_OrderRefunDetial set orderid=@orderid,cusid=@cusid,cusName=@cusName,money=@money,refundAmount=@refundAmount,refundStatus=@refundStatus,remark=@remark where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",to_orderrefundetial.Id),
        new SqlParameter("@orderid",to_orderrefundetial.Orderid),
        new SqlParameter ("@cusid",to_orderrefundetial.Cusid),
        new SqlParameter("@cusName",to_orderrefundetial.CusName),
        new SqlParameter("@money",to_orderrefundetial.Money),
        new SqlParameter("@refundAmount",to_orderrefundetial.RefundAmount),
        new SqlParameter("@refundStatus",to_orderrefundetial.RefundStatus),
        new SqlParameter("@remark",to_orderrefundetial.Remark)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_OrderRefunDetial]表删除的方法
        /// </summary>
        public static int deleteTo_OrderRefunDetialById(int id)
        {

            string sql = "delete from To_OrderRefunDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_OrderRefunDetial]表查询实体的方法
        /// </summary>
        public static To_OrderRefunDetial getTo_OrderRefunDetialById(int id)
        {
            To_OrderRefunDetial to_orderrefundetial = null;

            string sql = "select * from To_OrderRefunDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_orderrefundetial = new To_OrderRefunDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_orderrefundetial.Id = Convert.ToInt32(dr["id"]);
                    to_orderrefundetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_orderrefundetial.Cusid = Convert.ToInt32(dr["cusid"]);
                    to_orderrefundetial.CusName = Convert.ToString(dr["cusName"]);
                    to_orderrefundetial.Money = Convert.ToDouble(dr["money"]);
                    to_orderrefundetial.RefundAmount = Convert.ToDouble(dr["refundAmount"]);
                    to_orderrefundetial.RefundStatus = Convert.ToString(dr["refundStatus"]);
                    to_orderrefundetial.Remark = Convert.ToString(dr["remark"]);
                }
            }

            return to_orderrefundetial;
        }

        /// <summary>
        ///[To_OrderRefunDetial]表查询所有的方法
        /// </summary>
        public static IList<To_OrderRefunDetial> getTo_OrderRefunDetialAll()
        {
            string sql = "select * from To_OrderRefunDetial";
            return getTo_OrderRefunDetialsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_OrderRefunDetial> getTo_OrderRefunDetialsBySql(string sql)
        {
            IList<To_OrderRefunDetial> list = new List<To_OrderRefunDetial>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_OrderRefunDetial to_orderrefundetial = new To_OrderRefunDetial();
                    to_orderrefundetial.Id = Convert.ToInt32(dr["id"]);
                    to_orderrefundetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_orderrefundetial.Cusid = Convert.ToInt32(dr["cusid"]);
                    to_orderrefundetial.CusName = Convert.ToString(dr["cusName"]);
                    to_orderrefundetial.Money = Convert.ToDouble(dr["money"]);
                    to_orderrefundetial.RefundAmount = Convert.ToDouble(dr["refundAmount"]);
                    to_orderrefundetial.RefundStatus = Convert.ToString(dr["refundStatus"]);
                    to_orderrefundetial.Remark = Convert.ToString(dr["remark"]);
                    list.Add(to_orderrefundetial);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_OrderRefunDetial getTo_OrderRefunDetialBySql(string sql)
        {
            To_OrderRefunDetial to_orderrefundetial = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_orderrefundetial = new To_OrderRefunDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_orderrefundetial.Id = Convert.ToInt32(dr["id"]);
                    to_orderrefundetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_orderrefundetial.Cusid = Convert.ToInt32(dr["cusid"]);
                    to_orderrefundetial.CusName = Convert.ToString(dr["cusName"]);
                    to_orderrefundetial.Money = Convert.ToDouble(dr["money"]);
                    to_orderrefundetial.RefundAmount = Convert.ToDouble(dr["refundAmount"]);
                    to_orderrefundetial.RefundStatus = Convert.ToString(dr["refundStatus"]);
                    to_orderrefundetial.Remark = Convert.ToString(dr["remark"]);
                }
            }
            return to_orderrefundetial;
        }

        public static int deleteTo_OrderRefunDetialByOrderID(int orderid)
        {
            string sql = "delete from To_OrderRefunDetial where orderid=@orderid";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@orderid",orderid)
             };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from To_OrderRefunDetial where orderid = " + id;
            return DBHelper.GetDataSet(sql);
        }

        /// <summary>
        /// 根据sql条件删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int deleteTo_OrderRefunDetialbySql(string sql)
        {
            string sqlwhere = "delete from To_OrderRefunDetial where " + sql;
            return DBHelper.ExecuteCommand(sqlwhere);
        }

        /// <summary>
        /// 更新订单退款信息明细表的退款状态和以退金额
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getstatus"></param>
        /// <param name="hasAmount"></param>
        /// <returns></returns>
        public static int updateDetialStatusAndMoney(string id, string getstatus, string hasAmount)
        {
            string sql = " update To_OrderRefunDetial set refundStatus=@refundStatus,refundAmount=@refundAmount where id=@id ";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",id),
                new SqlParameter("@refundStatus",getstatus),
                new SqlParameter("@refundAmount",hasAmount)
            };

            return DBHelper.ExecuteCommand(sql, sp);
        }
    }
}
