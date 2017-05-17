using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EtNet_Models;

namespace EtNet_DAL
{
	public class RegPaymentService
	{

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(RegPayment model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into RegPayment(");
            strSql.Append("id,payStatus,paymentID,payerID,payerName,paymentDate,hasInvoice,hasInvoiceDate,makeTime,makerID,makerName,payRemark");
			strSql.Append(") values (");
            strSql.Append("@id,@payStatus,@paymentID,@payerID,@payerName,@paymentDate,@hasInvoice,@hasInvoiceDate,@makeTime,@makerID,@makerName,@payRemark");
			strSql.Append(") ");

			SqlParameter[] parameters = {
                        new SqlParameter("@id", SqlDbType.VarChar,50) ,
                        new SqlParameter("@payStatus", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@paymentID", SqlDbType.VarChar,50) ,
                        new SqlParameter("@payerID", SqlDbType.Int,4) ,            
						new SqlParameter("@payerName", SqlDbType.VarChar,50) ,            
						new SqlParameter("@paymentDate", SqlDbType.DateTime) ,
                        new SqlParameter("@hasInvoice", SqlDbType.TinyInt,1) ,            
						new SqlParameter("@hasInvoiceDate", SqlDbType.DateTime),
                        new SqlParameter("@makeTime", SqlDbType.DateTime) ,
                        new SqlParameter("@makerID", SqlDbType.Int,4) ,
                        new SqlParameter("@makerName", SqlDbType.VarChar,50) ,            
						new SqlParameter("@payRemark",SqlDbType.VarChar,100)
						             
			};

            parameters[0].Value = model.id;
            parameters[1].Value = model.payStatus;
            parameters[2].Value = model.paymentID;
            parameters[3].Value = model.payerID;
            parameters[4].Value = model.payerName;
            parameters[5].Value = model.paymentDate;
            parameters[6].Value = model.hasInvoice;
            parameters[7].Value = model.hasInvoiceDate;
            parameters[8].Value = model.makeTime;
            parameters[9].Value = model.makerID;
            parameters[10].Value = model.makerName;
            parameters[11].Value = model.payRemark;
         
			DBHelper.ExecuteCommand(strSql.ToString(), parameters);

		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RegPayment model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update RegPayment set ");

            strSql.Append(" payStatus = @payStatus , ");
		    strSql.Append(" paymentID = @paymentID , ");
            strSql.Append(" payerID = @payerID , ");
            strSql.Append(" payerName = @payerName , ");
            strSql.Append(" paymentDate = @paymentDate , ");
            strSql.Append(" hasInvoice = @hasInvoice , ");
            strSql.Append(" hasInvoiceDate = @hasInvoiceDate , ");
            strSql.Append(" makeTime = @makeTime , ");
            strSql.Append(" makerID = @makerID , ");
            strSql.Append(" makerName = @makerName ,");
            strSql.Append(" payRemark = @payRemark ");
			
            strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
						          
						new SqlParameter("@id", SqlDbType.VarChar,50) ,
                        new SqlParameter("@payStatus", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@paymentID", SqlDbType.VarChar,50) ,
                        new SqlParameter("@payerID", SqlDbType.Int,4) ,            
						new SqlParameter("@payerName", SqlDbType.VarChar,50) ,            
						new SqlParameter("@paymentDate", SqlDbType.DateTime) ,
                        new SqlParameter("@hasInvoice", SqlDbType.TinyInt,1) ,            
						new SqlParameter("@hasInvoiceDate", SqlDbType.DateTime),
                        new SqlParameter("@makeTime", SqlDbType.DateTime) ,
                        new SqlParameter("@makerID", SqlDbType.Int,4) ,
                        new SqlParameter("@makerName", SqlDbType.VarChar,50) ,            
						new SqlParameter("@payRemark",SqlDbType.VarChar,100)             
			  
			};


            parameters[0].Value = model.id;
            parameters[1].Value = model.payStatus;
            parameters[2].Value = model.paymentID;
            parameters[3].Value = model.payerID;
            parameters[4].Value = model.payerName;
            parameters[5].Value = model.paymentDate;
            parameters[6].Value = model.hasInvoice;
            parameters[7].Value = model.hasInvoiceDate;
            parameters[8].Value = model.makeTime;
            parameters[9].Value = model.makerID;
            parameters[10].Value = model.makerName;
            parameters[11].Value = model.payRemark;
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
		/// 得到一个对象实体
		/// </summary>
		public RegPayment GetModel(string id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * ");
			strSql.Append("  from RegPayment ");
			strSql.Append(" where paymentID=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
			parameters[0].Value = id;


			RegPayment model = new RegPayment();
			DataTable dt =DBHelper.GetDataSet(strSql.ToString(), parameters);

			if (dt.Rows.Count > 0)
			{
				model.id = dt.Rows[0]["id"].ToString();
				if (dt.Rows[0]["invoiceType"].ToString() != "")
				{
					model.invoiceType = int.Parse(dt.Rows[0]["invoiceType"].ToString());
				}
				if (dt.Rows[0]["makeTime"].ToString() != "")
				{
					model.makeTime = DateTime.Parse(dt.Rows[0]["makeTime"].ToString());
				}
				if (dt.Rows[0]["makerID"].ToString() != "")
				{
					model.makerID = int.Parse(dt.Rows[0]["makerID"].ToString());
				}
				model.makerName = dt.Rows[0]["makerName"].ToString();
				model.paymentID = dt.Rows[0]["paymentID"].ToString();
				if (dt.Rows[0]["payStatus"].ToString() != "")
				{
					model.payStatus = int.Parse(dt.Rows[0]["payStatus"].ToString());
				}
				if (dt.Rows[0]["paymentMode"].ToString() != "")
				{
					model.paymentMode = int.Parse(dt.Rows[0]["paymentMode"].ToString());
				}
				if (dt.Rows[0]["payerID"].ToString() != "")
				{
					model.payerID = int.Parse(dt.Rows[0]["payerID"].ToString());
				}
				model.payerName = dt.Rows[0]["payerName"].ToString();
				if (dt.Rows[0]["paymentDate"].ToString() != "")
				{
					model.paymentDate = DateTime.Parse(dt.Rows[0]["paymentDate"].ToString());
				}
				if (dt.Rows[0]["hasInvoice"].ToString() != "")
				{
					model.hasInvoice = int.Parse(dt.Rows[0]["hasInvoice"].ToString());
				}
				if (dt.Rows[0]["hasInvoiceDate"].ToString() != "")
				{
					model.hasInvoiceDate = DateTime.Parse(dt.Rows[0]["hasInvoiceDate"].ToString());
				}

				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 修改财务支付状态
		/// </summary>
		/// <param name="payStatus"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool UpdatePayStatus(int payStatus, string paymentid)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update RegPayment  set ");

			strSql.Append(" payStatus = @payStatus  ");
            strSql.Append(" where paymentID=@paymentID  ");

			SqlParameter[] parameters = {
						new SqlParameter("@paymentID", SqlDbType.VarChar,50) ,            
						new SqlParameter("@payStatus", SqlDbType.TinyInt,1)
			  
			};

			parameters[0].Value = paymentid;
			parameters[1].Value = payStatus;
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

		public DataTable GetViewPaymentList(string where)
		{
			StringBuilder sqlBuilder = new StringBuilder();

			sqlBuilder.Append("SELECT * FROM View_RegPayment ");

			sqlBuilder.Append("WHERE 1=1 ");
			if (!string.IsNullOrEmpty(where))
			{
				sqlBuilder.Append(where);
			}

			sqlBuilder.Append(" ORDER BY makeTime desc ");

			return DBHelper.GetDataSet(sqlBuilder.ToString());
		}
	}
}
