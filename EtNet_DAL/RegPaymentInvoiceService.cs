using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using System.Data.SqlClient;
using System.Data;

namespace EtNet_DAL
{
	public class RegPaymentInvoiceService
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(RegPaymentInvoice model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into RegPaymentInvoice(");
            strSql.Append("regID,invoiceID,invoiceNum,remark");
			strSql.Append(") values (");
            strSql.Append("@regID,@invoiceID,@invoiceNum,@remark");
			strSql.Append(") ");

			SqlParameter[] parameters = {
						new SqlParameter("@regID", SqlDbType.VarChar,50) ,            
                        //new SqlParameter("@regID", SqlDbType.VarChar,50) ,            
						new SqlParameter("@invoiceID", SqlDbType.Int,4) ,            
						new SqlParameter("@invoiceNum", SqlDbType.VarChar,50) ,            
						new SqlParameter("@remark", SqlDbType.NVarChar,500)             
			  
			};

			parameters[0].Value = model.id;
            //parameters[1].Value = model.regID;
			parameters[1].Value = model.invoiceID;
			parameters[2].Value = model.invoiceNum;
			parameters[3].Value = model.remark;
			DBHelper.ExecuteCommand(strSql.ToString(), parameters);

		}

		public bool DeleteByRegID(string regID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from RegPaymentInvoice ");
			strSql.Append(" where regID=@regID ");
			SqlParameter[] parameters = {
					new SqlParameter("@regID", SqlDbType.VarChar,50)			};
			parameters[0].Value = regID;


			int rows = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
        /// 获得数据列表
        /// </summary>
        public  DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM RegPaymentInvoice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDataSet(strSql.ToString());
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        public int GetCount(string regid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.Append(" FROM RegPaymentInvoice ");
            if (regid.Trim() != "")
            {
                strSql.Append(" where regID='" + regid+"'");
            }
            return DBHelper.ExecuteScalar(strSql.ToString());
        }
	}
}
