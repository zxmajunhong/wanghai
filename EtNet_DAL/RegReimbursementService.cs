using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EtNet_Models;

namespace EtNet_DAL
{
	//RegReimbursement 
	public partial class RegReimbursementService
	{


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(RegReimbursement model)
		{
			StringBuilder strSql = new StringBuilder();

			strSql.Append("insert into RegReimbursement (");
			strSql.Append("id,payStatus,paymentMode,payerID,payerName,paymentDate,makeTime,makerID,makerName,ausID,payremark,bankname,banknum,bankId");
			strSql.Append(") values (");
			strSql.Append("@id,@payStatus,@paymentMode,@payerID,@payerName,@paymentDate,@makeTime,@makerID,@makerName,@ausID,@payremark,@bankname,@banknum,@bankId");
			strSql.Append(") ");

			SqlParameter[] parameters = {
						new SqlParameter("@id", SqlDbType.VarChar,50) ,            
						new SqlParameter("@payStatus", SqlDbType.TinyInt,1) ,            
						new SqlParameter("@paymentMode", SqlDbType.TinyInt,1) ,            
						new SqlParameter("@payerID", SqlDbType.Int,4) ,            
						new SqlParameter("@payerName", SqlDbType.VarChar,50) ,            
						new SqlParameter("@paymentDate", SqlDbType.DateTime) ,            
						new SqlParameter("@makeTime", SqlDbType.DateTime) ,            
						new SqlParameter("@makerID", SqlDbType.Int,4) ,            
						new SqlParameter("@makerName", SqlDbType.VarChar,50),
						new SqlParameter("@ausID",SqlDbType.Int,4),
			            new SqlParameter("@payremark",SqlDbType.VarChar,100),
                        new SqlParameter("@bankname",SqlDbType.VarChar,100),
                        new SqlParameter("@banknum",SqlDbType.VarChar,100),
                        new SqlParameter("@bankId",SqlDbType.Int,4),
			};

			parameters[0].Value = model.id;
			parameters[1].Value = model.payStatus;
			parameters[2].Value = model.paymentMode;
			parameters[3].Value = model.payerID;
			parameters[4].Value = model.payerName;
			parameters[5].Value = model.paymentDate;
			parameters[6].Value = model.makeTime;
			parameters[7].Value = model.makerID;
			parameters[8].Value = model.makerName;
			parameters[9].Value = model.ausID;
            parameters[10].Value = model.payremark;
            parameters[11].Value = model.bankName;
            parameters[12].Value = model.bankNum;
            parameters[13].Value = model.bankId;
			int row = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RegReimbursement model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update RegReimbursement  set ");

			strSql.Append(" id = @id , ");
			strSql.Append(" payStatus = @payStatus , ");
			strSql.Append(" paymentMode = @paymentMode , ");
			strSql.Append(" payerID = @payerID , ");
			strSql.Append(" payerName = @payerName , ");
			strSql.Append(" paymentDate = @paymentDate , ");
			strSql.Append(" makeTime = @makeTime , ");
			strSql.Append(" makerID = @makerID , ");
			strSql.Append(" makerName = @makerName,  ");
			strSql.Append(" payremark = @payremark,  ");
            strSql.Append(" bankname = @bankname,  ");
            strSql.Append(" banknum = @banknum,  ");
            strSql.Append(" bankId = @bankId ");
			strSql.Append(" where id=@id  ");

			SqlParameter[] parameters = {
						new SqlParameter("@id", SqlDbType.VarChar,50) ,            
						new SqlParameter("@payStatus", SqlDbType.TinyInt,1) ,            
						new SqlParameter("@paymentMode", SqlDbType.TinyInt,1) ,            
						new SqlParameter("@payerID", SqlDbType.Int,4) ,            
						new SqlParameter("@payerName", SqlDbType.VarChar,50) ,            
						new SqlParameter("@paymentDate", SqlDbType.DateTime) ,            
						new SqlParameter("@makeTime", SqlDbType.DateTime) ,            
						new SqlParameter("@makerID", SqlDbType.Int,4) ,            
						new SqlParameter("@makerName", SqlDbType.VarChar,50)  ,
						new SqlParameter("@payremark",SqlDbType.VarChar,100),
                        new SqlParameter("@bankname",SqlDbType.VarChar,100),
                        new SqlParameter("@banknum",SqlDbType.VarChar,100),
                        new SqlParameter("@bankId",SqlDbType.Int,4)
			  
			};

			parameters[0].Value = model.id;
			parameters[1].Value = model.payStatus;
			parameters[2].Value = model.paymentMode;
			parameters[3].Value = model.payerID;
			parameters[4].Value = model.payerName;
			parameters[5].Value = model.paymentDate;
			parameters[6].Value = model.makeTime;
			parameters[7].Value = model.makerID;
			parameters[8].Value = model.makerName;
			parameters[9].Value = model.payremark;
            parameters[10].Value = model.bankName;
            parameters[11].Value = model.bankNum;
            parameters[12].Value = model.bankId;
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
        public bool UpdatePayerType(int regType, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update To_Payment  set ");

            strSql.Append(" regType = @regType  ");
            strSql.Append(" where id=@id  ");

            SqlParameter[] parameters = {
						new SqlParameter("@id", SqlDbType.VarChar,50) ,            
						new SqlParameter("@regType", SqlDbType.TinyInt,1)
			  
			};

            parameters[0].Value = id;
            parameters[1].Value = regType;
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

		public bool UpdatePayStatus(int payStatus,string id)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update RegReimbursement  set ");

			strSql.Append(" payStatus = @payStatus  ");
			strSql.Append(" where id=@id  ");

			SqlParameter[] parameters = {
						new SqlParameter("@id", SqlDbType.VarChar,50) ,            
						new SqlParameter("@payStatus", SqlDbType.TinyInt,1)
			  
			};

			parameters[0].Value = id;
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

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from RegReimbursement  ");
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



		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RegReimbursement GetModel(string id)
		{

			StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, payStatus, paymentMode, payerID, payerName, paymentDate, makeTime, makerID, makerName,hasInvoice,hasInvoiceDate,bankId,bankname,banknum,payremark  ");
			strSql.Append("  from RegReimbursement  ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
			parameters[0].Value = id;


			RegReimbursement model = new RegReimbursement();
			DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);

			if (dt.Rows.Count > 0)
			{
				model.id = dt.Rows[0]["id"].ToString();
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
				if (dt.Rows[0]["makeTime"].ToString() != "")
				{
					model.makeTime = DateTime.Parse(dt.Rows[0]["makeTime"].ToString());
				}
				if (dt.Rows[0]["makerID"].ToString() != "")
				{
					model.makerID = int.Parse(dt.Rows[0]["makerID"].ToString());
				}
				model.makerName = dt.Rows[0]["makerName"].ToString();

                model.payremark = dt.Rows[0]["payremark"].ToString();

                model.bankName = dt.Rows[0]["bankname"].ToString();
                model.bankNum = dt.Rows[0]["banknum"].ToString();
                model.bankId = Convert.IsDBNull(dt.Rows[0]["bankId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["bankId"].ToString());

				return model;
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RegReimbursement GetModelByAusID(int ausID)
		{

			StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, payStatus, paymentMode, payerID, payerName, paymentDate, makeTime, makerID, makerName,hasInvoice,hasInvoiceDate,bankId,bankname,banknum,payremark  ");
			strSql.Append("  from RegReimbursement  ");
			strSql.Append(" where ausID=@ausID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ausID", SqlDbType.Int,4)			};
			parameters[0].Value = ausID;


			RegReimbursement model = new RegReimbursement();
			DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);

			if (dt.Rows.Count > 0)
			{
				model.id = dt.Rows[0]["id"].ToString();
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
				if (dt.Rows[0]["makeTime"].ToString() != "")
				{
					model.makeTime = DateTime.Parse(dt.Rows[0]["makeTime"].ToString());
				}
				if (dt.Rows[0]["makerID"].ToString() != "")
				{
					model.makerID = int.Parse(dt.Rows[0]["makerID"].ToString());
				}
				model.makerName = dt.Rows[0]["makerName"].ToString();
				if (dt.Rows[0]["hasInvoice"].ToString() != "")
				{
					model.hasInvoice = int.Parse(dt.Rows[0]["hasInvoice"].ToString());
				}
				if (dt.Rows[0]["hasInvoiceDate"].ToString() != "")
				{
					model.hasInvoiceDate = DateTime.Parse(dt.Rows[0]["hasInvoiceDate"].ToString());
				}
                model.bankName = dt.Rows[0]["bankname"].ToString();
                model.bankNum = dt.Rows[0]["banknum"].ToString();
                model.payremark = dt.Rows[0]["payremark"].ToString();
                model.bankId = Convert.ToInt32(dt.Rows[0]["bankId"].ToString());

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
			strSql.Append(" FROM RegReimbursement  ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DBHelper.GetDataSet(strSql.ToString());
		}

        /// <summary>
        /// 0429 -------获取分页数据
        /// </summary>
        /// <returns></returns>
        public  DataTable GetListpage(string strWhere, string  ordertype, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT * FROM View_PaymentList ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append("where "+strWhere);
            }
            if (!string.IsNullOrEmpty(ordertype.Trim()))
            {
                strSql.Append(" order by " + ordertype);
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
			strSql.Append(" FROM RegReimbursement  ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.GetDataSet(strSql.ToString());
		}

        public DataTable GetViewList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" from View_RegReimbursement ");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);
            return DBHelper.GetDataSet(strSql.ToString());

        }

	}
}
