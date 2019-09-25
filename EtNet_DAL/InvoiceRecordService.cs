using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EtNet_Models;

namespace EtNet_DAL
{
    public class InvoiceRecordService
    {
        public static int Add(InvoiceRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into InvoiceRecord (");
            strSql.Append("recordDate,makeDate,makeMan,makeId,makeRemark,amount,cusId,cusName");
            strSql.Append(") values (");
            strSql.Append("@recordDate,@makeDate,@makeMan,@makeId,@makeRemark,@amount,@cusId,@cusName");
            strSql.Append("); select @@IDENTITY");
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@recordDate",model.recordDate),
                new SqlParameter("@makeDate",model.makeDate),
                new SqlParameter("@makeMan",model.makeMan),
                new SqlParameter("@makeId",model.makeId),
                new SqlParameter("@makeRemark",model.makeRemark),
                new SqlParameter("@amount",model.amount),
                new SqlParameter("@cusId",model.cusId),
                new SqlParameter("@cusName",model.cusName)
            };

            object result = DBHelper.GetSingle(strSql.ToString(), sp);
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public static InvoiceRecord GetModel(int Id)
        {
            string strWhere = " Id = " + Id;
            return GetModelBySql(strWhere);
        }

        public static InvoiceRecord GetModelBySql(string strWhere)
        {
            InvoiceRecord model = null;
            string sql = " select * from InvoiceRecord ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                model = new InvoiceRecord();
                DataRow dr = dt.Rows[0];
                model.ID = Convert.ToInt32(dr["Id"]);
                model.recordDate = Convert.ToDateTime(dr["recordDate"]);
                model.makeDate = Convert.ToDateTime(dr["makeDate"]);
                model.makeMan = dr["makeMan"].ToString();
                model.makeId = Convert.ToInt32(dr["makeId"]);
                model.makeRemark = dr["makeRemark"].ToString();
                model.amount = Convert.ToDouble(dr["amount"]);
                model.cusId = Convert.ToInt32(dr["cusId"]);
                model.cusName = dr["cusName"].ToString();
            }

            return model;
        }

        public static bool Update(InvoiceRecord model)
        {
            string sql = "update InvoiceRecord set recordDate=@recordDate,makeDate=@makeDate,makeMan=@makeMan,makeId=@makeId,makeRemark=@makeRemark,amount=@amount,cusId=@cusId,cusName=@cusName where Id=@Id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@Id",model.ID),
                new SqlParameter("@recordDate",model.recordDate),
                new SqlParameter("@makeDate",model.makeDate),
                new SqlParameter("@makeMan",model.makeMan),
                new SqlParameter("@makeId",model.makeId),
                new SqlParameter("@makeRemark",model.makeRemark),
                new SqlParameter("@amount",model.amount),
                new SqlParameter("@cusId",model.cusId),
                new SqlParameter("@cusName",model.cusName)
            };

            int result = DBHelper.ExecuteCommand(sql, sp);
            return result > 0;
        }

        public static bool Del(string Id)
        {
            string sql = "delete InvoiceRecord where Id=@Id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@Id",Id)
            };

            int result = DBHelper.ExecuteCommand(sql, sp);
            return result > 0;
        }
    }
}
