using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using System.Data.SqlClient;
using System.Data;

namespace EtNet_DAL
{
	//ReimbursementInvoice
	public partial class ReimbursementInvoiceService
	{



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ReimbursementInvoice model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into ReimbursementInvoice(");
			strSql.Append("id,reimbursementID,invoiceNum,remark");
			strSql.Append(") values (");
			strSql.Append("@id,@reimbursementID,@invoiceNum,@remark");
			strSql.Append(") ");

			SqlParameter[] parameters = {
						new SqlParameter("@id", SqlDbType.VarChar,50) ,            
						new SqlParameter("@reimbursementID", SqlDbType.VarChar,50) ,            
						new SqlParameter("@invoiceNum", SqlDbType.VarChar,50) ,            
						new SqlParameter("@remark", SqlDbType.NVarChar,500)             
			  
			};

			parameters[0].Value = model.id;
			parameters[1].Value = model.reimbursementID;
			parameters[2].Value = model.invoiceNum;
			parameters[3].Value = model.remark;
			DBHelper.ExecuteCommand(strSql.ToString(), parameters);

		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ReimbursementInvoice model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update ReimbursementInvoice set ");

			strSql.Append(" id = @id , ");
			strSql.Append(" reimbursementID = @reimbursementID , ");
			strSql.Append(" invoiceNum = @invoiceNum , ");
			strSql.Append(" remark = @remark  ");
			strSql.Append(" where id=@id  ");

			SqlParameter[] parameters = {
						new SqlParameter("@id", SqlDbType.VarChar,50) ,            
						new SqlParameter("@reimbursementID", SqlDbType.VarChar,50) ,            
						new SqlParameter("@invoiceNum", SqlDbType.VarChar,50) ,            
						new SqlParameter("@remark", SqlDbType.NVarChar,500)             
			  
			};

			parameters[0].Value = model.id;
			parameters[1].Value = model.reimbursementID;
			parameters[2].Value = model.invoiceNum;
			parameters[3].Value = model.remark;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from ReimbursementInvoice ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
			parameters[0].Value = id;


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

		public bool DeleteByRegID(string regID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from ReimbursementInvoice ");
			strSql.Append(" where reimbursementID=@reimbursementID ");
			SqlParameter[] parameters = {
					new SqlParameter("@reimbursementID", SqlDbType.VarChar,50)			};
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
		/// 得到一个对象实体
		/// </summary>
		public ReimbursementInvoice GetModel(string id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id, reimbursementID, invoiceNum, remark  ");
			strSql.Append("  from ReimbursementInvoice ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
			parameters[0].Value = id;


			ReimbursementInvoice model = new ReimbursementInvoice();
			DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);

			if (dt.Rows.Count > 0)
			{
				model.id = dt.Rows[0]["id"].ToString();
				model.reimbursementID = dt.Rows[0]["reimbursementID"].ToString();
				model.invoiceNum = dt.Rows[0]["invoiceNum"].ToString();
				model.remark = dt.Rows[0]["remark"].ToString();

				return model;
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM ReimbursementInvoice ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DBHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataTable GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM ReimbursementInvoice ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.GetDataSet(strSql.ToString());
		}


	}
}
