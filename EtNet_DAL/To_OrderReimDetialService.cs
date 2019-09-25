using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_OrderReimDetial]表的数据访问类
    /// </summary>
    public class To_OrderReimDetialService
    {
        /// <summary>
        ///[To_OrderReimDetial]表添加的方法
        /// </summary>
        public static int addTo_OrderReimDetial(To_OrderReimDetial to_orderreimdetial)
        {
            string sql = "insert into To_OrderReimDetial([orderid],[reimNum],[reimContent],[reimMoney],[reimAmount],[reimConfirm]) values (@orderid,@reimNum,@reimContent,@reimMoney,@reimAmount,@reimConfirm)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@orderid",to_orderreimdetial.Orderid),
        new SqlParameter("@reimNum",to_orderreimdetial.ReimNum),
        new SqlParameter("@reimContent",to_orderreimdetial.ReimContent),
        new SqlParameter("@reimMoney",to_orderreimdetial.ReimMoney),
        new SqlParameter("@reimAmount",to_orderreimdetial.ReimAmount),
        new SqlParameter("@reimConfirm",to_orderreimdetial.ReimConfirm)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_OrderReimDetial]表修改的方法
        /// </summary>
        public static int updateTo_OrderReimDetialById(To_OrderReimDetial to_orderreimdetial)
        {

            string sql = "update To_OrderReimDetial set orderid=@orderid,reimNum=@reimNum,reimContent=@reimContent,reimMoney=@reimMoney,reimAmount=@reimAmount,reimConfirm=@reimConfirm where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",to_orderreimdetial.Id),
        new SqlParameter("@orderid",to_orderreimdetial.Orderid),
        new SqlParameter("@reimNum",to_orderreimdetial.ReimNum),
        new SqlParameter("@reimContent",to_orderreimdetial.ReimContent),
        new SqlParameter("@reimMoney",to_orderreimdetial.ReimMoney),
        new SqlParameter("@reimAmount",to_orderreimdetial.ReimAmount),
        new SqlParameter("@reimConfirm",to_orderreimdetial.ReimConfirm)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_OrderReimDetial]表删除的方法
        /// </summary>
        public static int deleteTo_OrderReimDetialById(int id)
        {

            string sql = "delete from To_OrderReimDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_OrderReimDetial]表查询实体的方法
        /// </summary>
        public static To_OrderReimDetial getTo_OrderReimDetialById(int id)
        {
            To_OrderReimDetial to_orderreimdetial = null;

            string sql = "select * from To_OrderReimDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_orderreimdetial = new To_OrderReimDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_orderreimdetial.Id = Convert.ToInt32(dr["id"]);
                    to_orderreimdetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_orderreimdetial.ReimNum = Convert.ToString(dr["reimNum"]);
                    to_orderreimdetial.ReimContent = Convert.ToString(dr["reimContent"]);
                    to_orderreimdetial.ReimMoney = Convert.ToDouble(dr["reimMoney"]);
                    to_orderreimdetial.ReimAmount = Convert.ToDouble(dr["reimAmount"]);
                    to_orderreimdetial.ReimConfirm = Convert.ToString(dr["reimConfirm"]);
                }
            }

            return to_orderreimdetial;
        }

        /// <summary>
        ///[To_OrderReimDetial]表查询所有的方法
        /// </summary>
        public static IList<To_OrderReimDetial> getTo_OrderReimDetialAll()
        {
            string sql = "select * from To_OrderReimDetial";
            return getTo_OrderReimDetialsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_OrderReimDetial> getTo_OrderReimDetialsBySql(string sql)
        {
            IList<To_OrderReimDetial> list = new List<To_OrderReimDetial>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_OrderReimDetial to_orderreimdetial = new To_OrderReimDetial();
                    to_orderreimdetial.Id = Convert.ToInt32(dr["id"]);
                    to_orderreimdetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_orderreimdetial.ReimNum = Convert.ToString(dr["reimNum"]);
                    to_orderreimdetial.ReimContent = Convert.ToString(dr["reimContent"]);
                    to_orderreimdetial.ReimMoney = Convert.ToDouble(dr["reimMoney"]);
                    to_orderreimdetial.ReimAmount = Convert.ToDouble(dr["reimAmount"]);
                    to_orderreimdetial.ReimConfirm = Convert.ToString(dr["reimConfirm"]);
                    list.Add(to_orderreimdetial);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_OrderReimDetial getTo_OrderReimDetialBySql(string sql)
        {
            To_OrderReimDetial to_orderreimdetial = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_orderreimdetial = new To_OrderReimDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_orderreimdetial.Id = Convert.ToInt32(dr["id"]);
                    to_orderreimdetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_orderreimdetial.ReimNum = Convert.ToString(dr["reimNum"]);
                    to_orderreimdetial.ReimContent = Convert.ToString(dr["reimContent"]);
                    to_orderreimdetial.ReimMoney = Convert.ToDouble(dr["reimMoney"]);
                    to_orderreimdetial.ReimAmount = Convert.ToDouble(dr["reimAmount"]);
                    to_orderreimdetial.ReimConfirm = Convert.ToString(dr["reimConfirm"]);
                }
            }
            return to_orderreimdetial;
        }

        public static int deleteTo_OrderReimDetialByOrderID(int orderid)
        {
            string sql = "delete from To_OrderReimDetial where orderid=@orderid";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@orderid",orderid)
             };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from To_OrderReimDetial where orderid = " + id;
            return DBHelper.GetDataSet(sql);
        }
    }
}
