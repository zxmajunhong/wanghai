using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[to_InvoiceDetial]表的数据访问类
    /// </summary>
    public class To_InvoiceDetialService
    {
        /// <summary>
        ///[to_InvoiceDetial]表添加的方法
        /// </summary>
        public static int addTo_InvoiceDetial(To_InvoiceDetial to_invoicedetial)
        {
            string sql = "insert into to_InvoiceDetial([invoiceID],[policyID],[cusName],[cost],[detialReamrk]) values (@invoiceID,@policyID,@cusName,@cost,@detialReamrk)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@invoiceID",to_invoicedetial.InvoiceID),
        new SqlParameter("@policyID",to_invoicedetial.PolicyID),
        new SqlParameter("@cusName",to_invoicedetial.CusName),
        new SqlParameter("@cost",to_invoicedetial.Cost),
        new SqlParameter("@detialReamrk",to_invoicedetial.DetialReamrk)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[to_InvoiceDetial]表修改的方法
        /// </summary>
        public static int updateTo_InvoiceDetialById(To_InvoiceDetial to_invoicedetial)
        {

            string sql = "update to_InvoiceDetial set invoiceID=@invoiceID,policyID=@policyID,cusName=@cusName,cost=@cost,detialReamrk=@detialReamrk where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",to_invoicedetial.Id),
        new SqlParameter("@invoiceID",to_invoicedetial.InvoiceID),
        new SqlParameter("@policyID",to_invoicedetial.PolicyID),
        new SqlParameter("@cusName",to_invoicedetial.CusName),
        new SqlParameter("@cost",to_invoicedetial.Cost),
        new SqlParameter("@detialReamrk",to_invoicedetial.DetialReamrk)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[to_InvoiceDetial]表删除的方法
        /// </summary>
        public static int deleteTo_InvoiceDetialById(int id)
        {

            string sql = "delete from to_InvoiceDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[to_InvoiceDetial]表查询实体的方法
        /// </summary>
        public static To_InvoiceDetial getTo_InvoiceDetialById(int id)
        {
            To_InvoiceDetial to_invoicedetial = null;

            string sql = "select * from to_InvoiceDetial where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_invoicedetial = new To_InvoiceDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_invoicedetial.Id = Convert.ToInt32(dr["id"]);
                    to_invoicedetial.InvoiceID = Convert.ToInt32(dr["invoiceID"]);
                    to_invoicedetial.PolicyID = Convert.ToString(dr["policyID"]);
                    to_invoicedetial.CusName = Convert.ToString(dr["cusName"]);
                    to_invoicedetial.Cost = Convert.ToDouble(dr["cost"]);
                    to_invoicedetial.DetialReamrk = Convert.ToString(dr["detialReamrk"]);
                }
            }

            return to_invoicedetial;
        }

        /// <summary>
        ///[to_InvoiceDetial]表查询所有的方法
        /// </summary>
        public static IList<To_InvoiceDetial> getTo_InvoiceDetialAll()
        {
            string sql = "select * from to_InvoiceDetial";
            return getTo_InvoiceDetialsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_InvoiceDetial> getTo_InvoiceDetialsBySql(string sql)
        {
            IList<To_InvoiceDetial> list = new List<To_InvoiceDetial>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_InvoiceDetial to_invoicedetial = new To_InvoiceDetial();
                    to_invoicedetial.Id = Convert.ToInt32(dr["id"]);
                    to_invoicedetial.InvoiceID = Convert.ToInt32(dr["invoiceID"]);
                    to_invoicedetial.PolicyID = Convert.ToString(dr["policyID"]);
                    to_invoicedetial.CusName = Convert.ToString(dr["cusName"]);
                    to_invoicedetial.Cost = Convert.ToDouble(dr["cost"]);
                    to_invoicedetial.DetialReamrk = Convert.ToString(dr["detialReamrk"]);
                    list.Add(to_invoicedetial);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_InvoiceDetial getTo_InvoiceDetialBySql(string sql)
        {
            To_InvoiceDetial to_invoicedetial = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_invoicedetial = new To_InvoiceDetial();
                foreach (DataRow dr in dt.Rows)
                {
                    to_invoicedetial.Id = Convert.ToInt32(dr["id"]);
                    to_invoicedetial.InvoiceID = Convert.ToInt32(dr["invoiceID"]);
                    to_invoicedetial.PolicyID = Convert.ToString(dr["policyID"]);
                    to_invoicedetial.CusName = Convert.ToString(dr["cusName"]);
                    to_invoicedetial.Cost = Convert.ToDouble(dr["cost"]);
                    to_invoicedetial.DetialReamrk = Convert.ToString(dr["detialReamrk"]);
                }
            }
            return to_invoicedetial;
        }

        public static IList<To_InvoiceDetial> getTo_InvoiceDetialByInvoiceId(string invoiceID)
        {
            string sql = "select * from to_InvoiceDetial where invoiceID=" + invoiceID;
            return getTo_InvoiceDetialsBySql(sql);
        }

        public static DataTable getList(int id)
        {
            string sql = "select * from to_InvoiceDetial where invoiceID = " + id;
            return DBHelper.GetDataSet(sql);
        }
        public static int deleteTo_InvoiceDetialByInvoiceId(int id)
        {

            string sql = "delete from to_InvoiceDetial where invoiceID=@invoiceID";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@invoiceID",id)
             };
            return DBHelper.ExecuteCommand(sql, sp);

        }

    }
}
