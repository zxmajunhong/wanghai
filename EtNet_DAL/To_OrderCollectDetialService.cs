using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_OrderCollectDetial]表的数据访问类
    /// </summary>
    public class To_OrderCollectDetialService
    {
        /// <summary>
        ///[To_OrderCollectDetial]表添加的方法
        /// </summary>
        public static int addTo_OrderCollectDetial(To_OrderCollectDetial to_ordercollectdetial)
        {
            string sql = "insert into To_OrderCollectDetial([orderid],[cusid],[cusName],[salesman],[salemanid],[adultNum],[childNum],[withNum],[money],[collectStatus],[collectAmount],[remark],[linkid],[linkname],[departName]) values (@orderid,@cusid,@cusName,@salesman,@salemanid,@adultNum,@childNum,@withNum,@money,@collectStatus,@collectAmount,@remark,@linkid,@linkname,@departName)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@orderid",to_ordercollectdetial.Orderid),
        new SqlParameter("@cusid",to_ordercollectdetial.CustId),
        new SqlParameter("@cusName",to_ordercollectdetial.CusName),
        new SqlParameter("@salesman",to_ordercollectdetial.Salesman),
        new SqlParameter("@salemanid",to_ordercollectdetial.Salemanid),
        new SqlParameter("@adultNum",to_ordercollectdetial.AdultNum),
        new SqlParameter("@childNum",to_ordercollectdetial.ChildNum),
        new SqlParameter("@withNum",to_ordercollectdetial.WithNum),
        new SqlParameter("@money",to_ordercollectdetial.Money),
        new SqlParameter("@collectStatus",to_ordercollectdetial.CollectStatus),
        new SqlParameter("@collectAmount",to_ordercollectdetial.CollectAmount),
        new SqlParameter("@remark",to_ordercollectdetial.Remark),
        new SqlParameter("@linkid",to_ordercollectdetial.LinkID),
        new SqlParameter("@linkname",to_ordercollectdetial.LinkName),
        new SqlParameter("@departName",to_ordercollectdetial.DepartName)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_OrderCollectDetial]表修改的方法
        /// </summary>
        public static int updateTo_OrderCollectDetialById(To_OrderCollectDetial to_ordercollectdetial)
        {

            string sql = "update To_OrderCollectDetial set orderid=@orderid,cusid=@cusid,cusName=@cusName,salesman=@salesman,salemanid=@salemanid,adultNum=@adultNum,childNum=@childNum,withNum=@withNum,money=@money,collectStatus=@collectStatus,collectAmount=@collectAmount,remark=@remark,linkid=@linkid,linkname=@linkname,departName=@departName where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",to_ordercollectdetial.Id),
        new SqlParameter("@orderid",to_ordercollectdetial.Orderid),
        new SqlParameter("@cusid",to_ordercollectdetial.CustId),
        new SqlParameter("@cusName",to_ordercollectdetial.CusName),
        new SqlParameter("@salesman",to_ordercollectdetial.Salesman),
        new SqlParameter("@salemanid",to_ordercollectdetial.Salemanid),
        new SqlParameter("@adultNum",to_ordercollectdetial.AdultNum),
        new SqlParameter("@childNum",to_ordercollectdetial.ChildNum),
        new SqlParameter("@withNum",to_ordercollectdetial.WithNum),
        new SqlParameter("@money",to_ordercollectdetial.Money),
        new SqlParameter("@collectStatus",to_ordercollectdetial.CollectStatus),
        new SqlParameter("@collectAmount",to_ordercollectdetial.CollectAmount),
        new SqlParameter("@remark",to_ordercollectdetial.Remark),
        new SqlParameter("@linkid",to_ordercollectdetial.LinkID),
        new SqlParameter("@linkname",to_ordercollectdetial.LinkName),
        new SqlParameter("@departName",to_ordercollectdetial.DepartName)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        /// 更新收款明细信息的收款状态和实际收款金额
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="hasAmount"></param>
        /// <returns></returns>
        public static int updateDetialStatusAndMoney(string id, string status, string hasAmount)
        {
            string sql = "update To_OrderCollectDetial set collectStatus=@collectStatus,collectAmount=@collectAmount where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@id",id),
                new SqlParameter("@collectStatus",status),
                new SqlParameter("@collectAmount",hasAmount)
            };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        /// 更新收款明细信息的提成发放状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int updateDetialCutStatus(string strWhere, string status)
        {
            string sql = "update To_OrderCollectDetial set cutPayStatus='"+status +"'";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        ///[To_OrderCollectDetial]表删除的方法
        /// </summary>
        public static int deleteTo_OrderCollectDetialById(int id)
        {

            string sql = "delete from To_OrderCollectDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_OrderCollectDetial]表查询实体的方法
        /// </summary>
        public static To_OrderCollectDetial getTo_OrderCollectDetialById(int id)
        {
            To_OrderCollectDetial to_ordercollectdetial = null;

            string sql = "select * from To_OrderCollectDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_ordercollectdetial = new To_OrderCollectDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_ordercollectdetial.Id = Convert.ToInt32(dr["id"]);
                    to_ordercollectdetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_ordercollectdetial.CustId = Convert.ToInt32(dr["cusid"]);
                    to_ordercollectdetial.CusName = Convert.ToString(dr["cusName"]);
                    to_ordercollectdetial.Salesman = Convert.ToString(dr["salesman"]);
                    to_ordercollectdetial.Salemanid = Convert.ToInt32(dr["salemanid"]);
                    to_ordercollectdetial.AdultNum = Convert.ToInt32(dr["adultNum"]);
                    to_ordercollectdetial.ChildNum = Convert.ToInt32(dr["childNum"]);
                    to_ordercollectdetial.WithNum = Convert.ToInt32(dr["withNum"]);
                    to_ordercollectdetial.Money = Convert.IsDBNull(dr["money"]) ? 0.0 : Convert.ToDouble(dr["money"]);
                    to_ordercollectdetial.CollectStatus = Convert.ToString(dr["collectStatus"]);
                    to_ordercollectdetial.CollectAmount = Convert.IsDBNull(dr["collectAmount"]) ? 0.0 : Convert.ToDouble(dr["collectAmount"]);
                    to_ordercollectdetial.Remark = Convert.ToString(dr["remark"]);
                    to_ordercollectdetial.LinkID = Convert.IsDBNull(dr["linkid"]) ? 0 : Convert.ToInt32(dr["linkid"]);
                    to_ordercollectdetial.LinkName = Convert.ToString(dr["linkname"]);
                    to_ordercollectdetial.DepartName = Convert.ToString(dr["departName"]);
                }
            }

            return to_ordercollectdetial;
        }

        /// <summary>
        ///[To_OrderCollectDetial]表查询所有的方法
        /// </summary>
        public static IList<To_OrderCollectDetial> getTo_OrderCollectDetialAll()
        {
            string sql = "select * from To_OrderCollectDetial";
            return getTo_OrderCollectDetialsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_OrderCollectDetial> getTo_OrderCollectDetialsBySql(string sql)
        {
            IList<To_OrderCollectDetial> list = new List<To_OrderCollectDetial>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_OrderCollectDetial to_ordercollectdetial = new To_OrderCollectDetial();
                    to_ordercollectdetial.Id = Convert.ToInt32(dr["id"]);
                    to_ordercollectdetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_ordercollectdetial.CustId = Convert.ToInt32(dr["cusid"]);
                    to_ordercollectdetial.CusName = Convert.ToString(dr["cusName"]);
                    to_ordercollectdetial.Salesman = Convert.ToString(dr["salesman"]);
                    to_ordercollectdetial.Salemanid = Convert.ToInt32(dr["salemanid"]);
                    to_ordercollectdetial.AdultNum = Convert.ToInt32(dr["adultNum"]);
                    to_ordercollectdetial.ChildNum = Convert.ToInt32(dr["childNum"]);
                    to_ordercollectdetial.WithNum = Convert.ToInt32(dr["withNum"]);
                    to_ordercollectdetial.Money = Convert.ToDouble(dr["money"]);
                    to_ordercollectdetial.CollectStatus = Convert.ToString(dr["collectStatus"]);
                    to_ordercollectdetial.CollectAmount = Convert.ToDouble(dr["collectAmount"]);
                    to_ordercollectdetial.Remark = Convert.ToString(dr["remark"]);
                    to_ordercollectdetial.LinkID = Convert.ToInt32(dr["linkid"]);
                    to_ordercollectdetial.LinkName = Convert.ToString(dr["linkname"]);
                    to_ordercollectdetial.DepartName = Convert.ToString(dr["departName"]);
                    list.Add(to_ordercollectdetial);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_OrderCollectDetial getTo_OrderCollectDetialBySql(string sql)
        {
            To_OrderCollectDetial to_ordercollectdetial = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_ordercollectdetial = new To_OrderCollectDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_ordercollectdetial.Id = Convert.ToInt32(dr["id"]);
                    to_ordercollectdetial.Orderid = Convert.ToInt32(dr["orderid"]);
                    to_ordercollectdetial.CustId = Convert.ToInt32(dr["cusid"]);
                    to_ordercollectdetial.CusName = Convert.ToString(dr["cusName"]);
                    to_ordercollectdetial.Salesman = Convert.ToString(dr["salesman"]);
                    to_ordercollectdetial.Salemanid = Convert.ToInt32(dr["salemanid"]);
                    to_ordercollectdetial.AdultNum = Convert.ToInt32(dr["adultNum"]);
                    to_ordercollectdetial.ChildNum = Convert.ToInt32(dr["childNum"]);
                    to_ordercollectdetial.WithNum = Convert.ToInt32(dr["withNum"]);
                    to_ordercollectdetial.Money = Convert.ToDouble(dr["money"]);
                    to_ordercollectdetial.CollectStatus = Convert.ToString(dr["collectStatus"]);
                    to_ordercollectdetial.CollectAmount = Convert.ToDouble(dr["collectAmount"]);
                    to_ordercollectdetial.Remark = Convert.ToString(dr["remark"]);
                    to_ordercollectdetial.LinkID = Convert.ToInt32(dr["linkid"]);
                    to_ordercollectdetial.LinkName = Convert.ToString(dr["linkname"]);
                    to_ordercollectdetial.DepartName = Convert.ToString(dr["departName"]);
                }
            }
            return to_ordercollectdetial;
        }

        public static int deleteTo_OrderCollectDetialByOrderID(int orderid)
        {
            string sql = "delete from To_OrderCollectDetial where orderid=@orderid";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@orderid",orderid)
             };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        public static DataTable getList(int id)
        {
            string sql = "select * from To_OrderCollectDetial where orderid = " + id;
            return DBHelper.GetDataSet(sql);
        }

        /// <summary>
        /// 根据sql条件删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int deleteTo_OrderCollectDetailbySql(string sql)
        {
            string sqlwhere = "delete from To_OrderCollectDetial where " + sql;
            return DBHelper.ExecuteCommand(sqlwhere);
        }



        public static DataTable GetOrderCollectInvoice(string strWhere)
        {
            string sql = "select * from View_OrderCollectInvoice ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            sql += " order by canAmount desc ";
            return DBHelper.GetDataSet(sql);
        }
    }
}
