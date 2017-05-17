using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[to_Invoice]表的数据访问类
    /// </summary>
    public class To_InvoiceService
    {
        /// <summary>
        ///[to_Invoice]表添加的方法
        /// </summary>
        public static int addTo_Invoice(To_Invoice to_invoice)
        {
            string sql = "insert into to_Invoice([invoiceID],[invoiceDate],[selasmane],[sum],[department],[invoiceUnit],[remark],[invoiceCMan],[invoiceCDepartment],[invoiceCDate],[upfile],[detialID],[invoiceType],[IsSure]) values (@invoiceID,@invoiceDate,@selasmane,@sum,@department,@invoiceUnit,@remark,@invoiceCMan,@invoiceCDepartment,@invoiceCDate,@upfile,@detialID,@invoiceType,@IsSure)";
            SqlParameter[] sp = new SqlParameter[]
      {
        new SqlParameter("@invoiceID",to_invoice.InvoiceID),
        new SqlParameter("@invoiceDate",to_invoice.InvoiceDate),
        new SqlParameter("@selasmane",to_invoice.Selasmane),
        new SqlParameter("@sum",to_invoice.Sum),
        new SqlParameter("@department",to_invoice.Department),
        new SqlParameter("@invoiceUnit",to_invoice.InvoiceUnit),
        new SqlParameter("@remark",to_invoice.Remark),
        new SqlParameter("@invoiceCMan",to_invoice.InvoiceCMan),
        new SqlParameter("@invoiceCDepartment",to_invoice.InvoiceCDepartment),
        new SqlParameter("@invoiceCDate",to_invoice.InvoiceCDate),
        new SqlParameter("@upfile",to_invoice.Upfile),
        new SqlParameter("@detialID",to_invoice.DetialID),
        new SqlParameter("@invoiceType",to_invoice.InvoiceType),
        new SqlParameter("@IsSure",to_invoice.IsSure)
      };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[to_Invoice]表修改的方法
        /// </summary>
        public static int updateTo_InvoiceById(To_Invoice to_invoice)
        {

            string sql = "update to_Invoice set invoiceID=@invoiceID,invoiceDate=@invoiceDate,selasmane=@selasmane,sum=@sum,department=@department,invoiceUnit=@invoiceUnit,remark=@remark,invoiceCMan=@invoiceCMan,invoiceCDepartment=@invoiceCDepartment,invoiceCDate=@invoiceCDate,upfile=@upfile,detialID=@detialID,invoiceType=@invoiceType,IsSure=@IsSure where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",to_invoice.Id),
        new SqlParameter("@invoiceID",to_invoice.InvoiceID),
        new SqlParameter("@invoiceDate",to_invoice.InvoiceDate),
        new SqlParameter("@selasmane",to_invoice.Selasmane),
        new SqlParameter("@sum",to_invoice.Sum),
        new SqlParameter("@department",to_invoice.Department),
        new SqlParameter("@invoiceUnit",to_invoice.InvoiceUnit),
        new SqlParameter("@remark",to_invoice.Remark),
        new SqlParameter("@invoiceCMan",to_invoice.InvoiceCMan),
        new SqlParameter("@invoiceCDepartment",to_invoice.InvoiceCDepartment),
        new SqlParameter("@invoiceCDate",to_invoice.InvoiceCDate),
        new SqlParameter("@upfile",to_invoice.Upfile),
        new SqlParameter("@detialID",to_invoice.DetialID),
        new SqlParameter("@invoiceType",to_invoice.InvoiceType),
        new SqlParameter("@IsSure",to_invoice.IsSure)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[to_Invoice]表删除的方法
        /// </summary>
        public static int deleteTo_InvoiceById(int id)
        {

            string sql = "delete from to_Invoice where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }
        public static int getInvoiceById(int id)
        {


            string sql = "select count(*) from to_Invoice where invoiceID='" + id+"'";
        
            return DBHelper.ExecuteScalar(sql);

        }

        /// <summary>
        /// 获取未支付发票
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUnpaidInvoice()
        {
            string sqlText = "select * from to_Invoice as i where i.invoiceID not in (select pd.invoiceNum from To_PaymentDetail as pd)";

            return DBHelper.GetDataSet(sqlText);
        }
        /// <summary>
        ///[to_Invoice]表查询实体的方法
        /// </summary>
        public static To_Invoice getTo_InvoiceById(int id)
        {
            To_Invoice to_invoice = null;

            string sql = "select * from to_Invoice where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_invoice = new To_Invoice();
                foreach (DataRow dr in dt.Rows)
                {
                    to_invoice.Id = Convert.ToInt32(dr["id"]);
                    to_invoice.InvoiceID = Convert.ToString(dr["invoiceID"]);
                    to_invoice.InvoiceDate = Convert.ToDateTime(dr["invoiceDate"]);
                    to_invoice.Selasmane = Convert.ToInt32(dr["selasmane"]);
                    to_invoice.Sum = Convert.ToDouble(dr["sum"]);
                    to_invoice.Department = Convert.ToString(dr["department"]);
                    to_invoice.InvoiceUnit = Convert.ToString(dr["invoiceUnit"]);
                    to_invoice.Remark = Convert.ToString(dr["remark"]);
                    to_invoice.InvoiceCMan = Convert.ToInt32(dr["invoiceCMan"]);
                    to_invoice.InvoiceCDepartment = Convert.ToInt32(dr["invoiceCDepartment"]);
                    to_invoice.InvoiceCDate = Convert.ToDateTime(dr["invoiceCDate"]);
                    to_invoice.Upfile = Convert.ToString(dr["upfile"]);
                    to_invoice.DetialID = Convert.ToInt32(dr["detialID"]);
                    to_invoice.InvoiceType = Convert.ToString(dr["invoiceType"]);
                    to_invoice.IsSure = Convert.ToInt32(dr["IsSure"]);
                }
            }

            return to_invoice;
        }

        /// <summary>
        ///[to_Invoice]表查询所有的方法
        /// </summary>
        public static IList<To_Invoice> getTo_InvoiceAll()
        {
            string sql = "select * from to_Invoice";
            return getTo_InvoicesBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_Invoice> getTo_InvoicesBySql(string sql)
        {
            IList<To_Invoice> list = new List<To_Invoice>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_Invoice to_invoice = new To_Invoice();
                    to_invoice.Id = Convert.ToInt32(dr["id"]);
                    to_invoice.InvoiceID = Convert.ToString(dr["invoiceID"]);
                    to_invoice.InvoiceDate = Convert.ToDateTime(dr["invoiceDate"]);
                    to_invoice.Selasmane = Convert.ToInt32(dr["selasmane"]);
                    to_invoice.Sum = Convert.ToDouble(dr["sum"]);
                    to_invoice.Department = Convert.ToString(dr["department"]);
                    to_invoice.InvoiceUnit = Convert.ToString(dr["invoiceUnit"]);
                    to_invoice.Remark = Convert.ToString(dr["remark"]);
                    to_invoice.InvoiceCMan = Convert.ToInt32(dr["invoiceCMan"]);
                    to_invoice.InvoiceCDepartment = Convert.ToInt32(dr["invoiceCDepartment"]);
                    to_invoice.InvoiceCDate = Convert.ToDateTime(dr["invoiceCDate"]);
                    to_invoice.Upfile = Convert.ToString(dr["upfile"]);
                    to_invoice.DetialID = Convert.ToInt32(dr["detialID"]);
                    to_invoice.InvoiceType = Convert.ToString(dr["invoiceType"]);
                    to_invoice.IsSure = Convert.ToInt32(dr["IsSure"]);
                    list.Add(to_invoice);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_Invoice getTo_InvoiceBySql(string sql)
        {
            To_Invoice to_invoice = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_invoice = new To_Invoice();
                foreach (DataRow dr in dt.Rows)
                {
                    to_invoice.Id = Convert.ToInt32(dr["id"]);
                    to_invoice.InvoiceID = Convert.ToString(dr["invoiceID"]);
                    to_invoice.InvoiceDate = Convert.ToDateTime(dr["invoiceDate"]);
                    to_invoice.Selasmane = Convert.ToInt32(dr["selasmane"]);
                    to_invoice.Sum = Convert.ToDouble(dr["sum"]);
                    to_invoice.Department = Convert.ToString(dr["department"]);
                    to_invoice.InvoiceUnit = Convert.ToString(dr["invoiceUnit"]);
                    to_invoice.Remark = Convert.ToString(dr["remark"]);
                    to_invoice.InvoiceCMan = Convert.ToInt32(dr["invoiceCMan"]);
                    to_invoice.InvoiceCDepartment = Convert.ToInt32(dr["invoiceCDepartment"]);
                    to_invoice.InvoiceCDate = Convert.ToDateTime(dr["invoiceCDate"]);
                    to_invoice.Upfile = Convert.ToString(dr["upfile"]);
                    to_invoice.DetialID = Convert.ToInt32(dr["detialID"]);
                    to_invoice.InvoiceType = Convert.ToString(dr["invoiceType"]);
                    to_invoice.IsSure = Convert.ToInt32(dr["IsSure"]);
                }
            }
            return to_invoice;
        }


        public static To_Invoice getTo_InvoiceLastONE()
        {
            string sql = "select Top 1 * from to_Invoice order by id  desc ";
            return getTo_InvoiceBySql(sql);
        }

        public static bool CancelIsSure(int id)
        {
            string sql = "update to_Invoice set IsSure=0 where id=@id";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@id", id) };
            return DBHelper.ExecuteCommand(sql, sp) > 0;
        }

        public static int Clear()
        {
            string sql = "truncate table to_Invoice;truncate table to_InvoiceDetial;";
            return DBHelper.ExecuteCommand(sql);
        }
    }
}
