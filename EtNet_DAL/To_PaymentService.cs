using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EtNet_Models;

namespace EtNet_DAL
{
    //To_Payment
    public partial class To_PaymentService
    {

        public bool Exists(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from To_Payment");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
            parameters[0].Value = id;

            return DBHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(To_Payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into To_Payment(");
            strSql.Append("id,payerID,totalAmount,orderNum,codeFormat,serialNum,jobFlowID,approvalOpinion,requestDate,makerName,makerID,payFor,paymentType,payerName,makeTime");
            strSql.Append(") values (");
            strSql.Append("@id,@payerID,@totalAmount,@orderNum,@codeFormat,@serialNum,@jobFlowID,@approvalOpinion,@requestDate,@makerName,@makerID,@payFor,@paymentType,@payerName,@makeTime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
						new SqlParameter("@id", SqlDbType.VarChar,50) ,            
						new SqlParameter("@payerID", SqlDbType.Int,4) ,            
						new SqlParameter("@totalAmount", SqlDbType.Decimal,9) ,            
						new SqlParameter("@orderNum", SqlDbType.VarChar,10) ,            
						new SqlParameter("@codeFormat", SqlDbType.VarChar,40) ,            
						new SqlParameter("@serialNum", SqlDbType.VarChar,50) ,            
						new SqlParameter("@jobFlowID", SqlDbType.Int,4) ,            
						new SqlParameter("@approvalOpinion", SqlDbType.NVarChar,500) ,            
						new SqlParameter("@requestDate", SqlDbType.DateTime) ,            
						new SqlParameter("@makerName", SqlDbType.VarChar,20) ,            
						new SqlParameter("@makerID", SqlDbType.Int,4) ,            
						new SqlParameter("@payFor", SqlDbType.VarChar,20) ,            
						new SqlParameter("@paymentType", SqlDbType.VarChar,50) ,            
						new SqlParameter("@payerName", SqlDbType.VarChar,50) ,    
						new SqlParameter("@makeTime",SqlDbType.DateTime)
			  
			};

            parameters[0].Value = model.id;
            parameters[1].Value = model.payerID;
            parameters[2].Value = model.totalAmount;
            parameters[3].Value = model.orderNum;
            parameters[4].Value = model.codeFormat;
            parameters[5].Value = model.serialNum;
            parameters[6].Value = model.jobFlowID;
            parameters[7].Value = model.approvalOpinion;
            parameters[8].Value = model.requestDate;
            parameters[9].Value = model.makerName;
            parameters[10].Value = model.makerID;
            parameters[11].Value = model.payFor;
            parameters[12].Value = model.paymentType;
            parameters[13].Value = model.payerName;
            parameters[14].Value = model.makeTime;
            DBHelper.ExecuteCommand(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(To_Payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update To_Payment set ");

            strSql.Append(" payerID = @payerID , ");
            strSql.Append(" payerName = @payerName , ");
            strSql.Append(" totalAmount = @totalAmount , ");
            strSql.Append(" jobFlowID = @jobFlowID , ");
            strSql.Append(" approvalOpinion = @approvalOpinion , ");
            strSql.Append(" requestDate = @requestDate , ");
            strSql.Append(" paymentType = @paymentType ");
            strSql.Append(" where id=@id  ");

            SqlParameter[] parameters = {
						new SqlParameter("@id", SqlDbType.VarChar,50) ,            
						new SqlParameter("@payerID", SqlDbType.Int,4) ,   
                        new SqlParameter("@payerName", SqlDbType.VarChar,50) , 
						new SqlParameter("@totalAmount", SqlDbType.Decimal,9) ,            
						new SqlParameter("@jobFlowID", SqlDbType.Int,4) ,            
						new SqlParameter("@approvalOpinion", SqlDbType.NVarChar,500) ,            
						new SqlParameter("@requestDate", SqlDbType.DateTime) ,            
						new SqlParameter("@paymentType", SqlDbType.VarChar,50)   
			};

            parameters[0].Value = model.id;
            parameters[1].Value = model.payerID;
            parameters[2].Value = model.payerName;
            parameters[3].Value = model.totalAmount;
            parameters[4].Value = model.jobFlowID;
            parameters[5].Value = model.approvalOpinion;
            parameters[6].Value = model.requestDate;
            parameters[7].Value = model.paymentType;
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
            strSql.Append("delete from To_Payment ");
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
        public To_Payment GetModel(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from To_Payment ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
            parameters[0].Value = id;


            To_Payment model = new To_Payment();
            DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model.id = dt.Rows[0]["id"].ToString();
                if (dt.Rows[0]["payerID"].ToString() != "")
                {
                    model.payerID = int.Parse(dt.Rows[0]["payerID"].ToString());
                }
                if (dt.Rows[0]["totalAmount"].ToString() != "")
                {
                    model.totalAmount = decimal.Parse(dt.Rows[0]["totalAmount"].ToString());
                }
                if (dt.Rows[0]["expectedDate"].ToString() != "")
                {
                    model.expectedDate = DateTime.Parse(dt.Rows[0]["expectedDate"].ToString());
                }
                model.bankName = dt.Rows[0]["bankName"].ToString();
                if (dt.Rows[0]["bankID"].ToString() != "")
                {
                    model.bankID = int.Parse(dt.Rows[0]["bankID"].ToString());
                }
                model.bankAccount = dt.Rows[0]["bankAccount"].ToString();
                model.bankAccountName = dt.Rows[0]["bankAccountName"].ToString();
                model.bankMark = dt.Rows[0]["bankMark"].ToString();
                model.orderNum = dt.Rows[0]["orderNum"].ToString();
                model.codeFormat = dt.Rows[0]["codeFormat"].ToString();
                model.serialNum = dt.Rows[0]["serialNum"].ToString();
                if (dt.Rows[0]["jobFlowID"].ToString() != "")
                {
                    model.jobFlowID = int.Parse(dt.Rows[0]["jobFlowID"].ToString());
                }
                model.approvalOpinion = dt.Rows[0]["approvalOpinion"].ToString();
                if (dt.Rows[0]["requestDate"].ToString() != "")
                {
                    model.requestDate = DateTime.Parse(dt.Rows[0]["requestDate"].ToString());
                }
                model.makerName = dt.Rows[0]["makerName"].ToString();
                if (dt.Rows[0]["makerID"].ToString() != "")
                {
                    model.makerID = int.Parse(dt.Rows[0]["makerID"].ToString());
                }
                model.payFor = dt.Rows[0]["payFor"].ToString();
                model.paymentType = dt.Rows[0]["paymentType"].ToString();
                model.payerName = dt.Rows[0]["payerName"].ToString();
                model.payerCode = dt.Rows[0]["payerCode"].ToString();
                if (dt.Rows[0]["payerType"].ToString() != "")
                {
                    model.payerType = int.Parse(dt.Rows[0]["payerType"].ToString());
                }
                model.makeTime = DateTime.Parse(dt.Rows[0]["makeTime"].ToString());
                if (dt.Rows[0]["regType"].ToString() != "")
                {
                    model.regtype = int.Parse(dt.Rows[0]["regType"].ToString());
                }

                model.payType = dt.Rows[0]["payType"].ToString();
                model.isConfirm = dt.Rows[0]["isConfirm"].ToString();
                model.getBank = dt.Rows[0]["getBank"].ToString();
                model.getAccount = dt.Rows[0]["getAccount"].ToString();
                model.getAccountName = dt.Rows[0]["getAccountName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过工作流id得到对象实体
        /// </summary>
        /// <param name="jfid"></param>
        /// <returns></returns>
        public To_Payment getModelByjfid(string jfid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from To_Payment ");
            strSql.Append(" where jobFlowID=@jobFlowID ");
            SqlParameter[] parameters = {
					new SqlParameter("@jobFlowID", SqlDbType.VarChar,50)			};
            parameters[0].Value = jfid;


            To_Payment model = new To_Payment();
            DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model.id = dt.Rows[0]["id"].ToString();
                if (dt.Rows[0]["payerID"].ToString() != "")
                {
                    model.payerID = int.Parse(dt.Rows[0]["payerID"].ToString());
                }
                if (dt.Rows[0]["totalAmount"].ToString() != "")
                {
                    model.totalAmount = decimal.Parse(dt.Rows[0]["totalAmount"].ToString());
                }
                if (dt.Rows[0]["expectedDate"].ToString() != "")
                {
                    model.expectedDate = DateTime.Parse(dt.Rows[0]["expectedDate"].ToString());
                }
                model.bankName = dt.Rows[0]["bankName"].ToString();
                if (dt.Rows[0]["bankID"].ToString() != "")
                {
                    model.bankID = int.Parse(dt.Rows[0]["bankID"].ToString());
                }
                model.bankAccount = dt.Rows[0]["bankAccount"].ToString();
                model.bankAccountName = dt.Rows[0]["bankAccountName"].ToString();
                model.bankMark = dt.Rows[0]["bankMark"].ToString();
                model.orderNum = dt.Rows[0]["orderNum"].ToString();
                model.codeFormat = dt.Rows[0]["codeFormat"].ToString();
                model.serialNum = dt.Rows[0]["serialNum"].ToString();
                if (dt.Rows[0]["jobFlowID"].ToString() != "")
                {
                    model.jobFlowID = int.Parse(dt.Rows[0]["jobFlowID"].ToString());
                }
                model.approvalOpinion = dt.Rows[0]["approvalOpinion"].ToString();
                if (dt.Rows[0]["requestDate"].ToString() != "")
                {
                    model.requestDate = DateTime.Parse(dt.Rows[0]["requestDate"].ToString());
                }
                model.makerName = dt.Rows[0]["makerName"].ToString();
                if (dt.Rows[0]["makerID"].ToString() != "")
                {
                    model.makerID = int.Parse(dt.Rows[0]["makerID"].ToString());
                }
                model.payFor = dt.Rows[0]["payFor"].ToString();
                model.paymentType = dt.Rows[0]["paymentType"].ToString();
                model.payerName = dt.Rows[0]["payerName"].ToString();
                model.payerCode = dt.Rows[0]["payerCode"].ToString();
                if (dt.Rows[0]["payerType"].ToString() != "")
                {
                    model.payerType = int.Parse(dt.Rows[0]["payerType"].ToString());
                }
                model.makeTime = DateTime.Parse(dt.Rows[0]["makeTime"].ToString());
                if (dt.Rows[0]["regType"].ToString() != "")
                {
                    model.regtype = int.Parse(dt.Rows[0]["regType"].ToString());
                }

                model.payType = dt.Rows[0]["payType"].ToString();
                model.isConfirm = dt.Rows[0]["isConfirm"].ToString();
                model.getBank = dt.Rows[0]["getBank"].ToString();
                model.getAccount = dt.Rows[0]["getAccount"].ToString();
                model.getAccountName = dt.Rows[0]["getAccountName"].ToString();

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
            strSql.Append(" FROM To_Payment ");
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
            strSql.Append(" FROM To_Payment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.GetDataSet(strSql.ToString());
        }


        public DataTable GetViewPayment(string where, string having, string field)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT policyId, ");
            //sqlBuilder.Append("SUM(payAmount) as payAmount, ");
            sqlBuilder.AppendFormat("SUM({0}Amount) as payAmount, ", field.TrimStart("exp".ToCharArray()).TrimStart('_'));
            sqlBuilder.AppendFormat("MAX({0}) as policyAmount, ", field);
            sqlBuilder.Append("MAX(serialnum) as serialnum,MAX(policy_num) as policy_num,MAX(isDaidian) as isDaidian, ")
                .Append("MAX(customer) as customer,MAX(company) as company ");
            sqlBuilder.Append(" FROM View_Payment ");

            //sqlBuilder.AppendFormat("WHERE {0} IS NOT NULL AND ( payFor='{0}' or payFor is null ) ", field);
            sqlBuilder.AppendFormat("WHERE {0} IS NOT NULL ", field);
            if (field == "exp_premium")
            {
                sqlBuilder.Append("AND isDaidian = 1 ");
            }
            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.Append(where);
            }

            sqlBuilder.Append("GROUP BY policyId ");

            //sqlBuilder.AppendFormat("HAVING (SUM(payAmount)<MAX({0}) or SUM(payAmount) is null) ", field);
            if (!string.IsNullOrEmpty(having))
            {
                sqlBuilder.Append(having);
            }
            return DBHelper.GetDataSet(sqlBuilder.ToString());
        }

        public DataTable GetPaymentInvoice(string where, string field)
        {
            StringBuilder sqlBuilder = new StringBuilder();

            sqlBuilder.Append("SELECT policyId,invoiceID as invoiceNum, ");
            sqlBuilder.Append("MAX(cost) as invoiceAmount, ");
            //sqlBuilder.Append("SUM(payAmount) as payAmount, ");
            sqlBuilder.AppendFormat("SUM({0}Amount) as payAmount, ", field.TrimStart("exp".ToCharArray()).TrimStart('_'));
            sqlBuilder.AppendFormat("MAX({0}) as policyAmount, ", field);
            sqlBuilder.Append("MAX(serialnum) as serialnum,MAX(policy_num) as policy_num,MAX(isDaidian) as isDaidian, ")
                .Append("MAX(customer) as customer,MAX(company) as company,MAX(payFor) as payFor ");
            sqlBuilder.Append("FROM (select distinct * from View_PaymentInvoice ) as t ");
            //sqlBuilder.Append("SELECT * FROM View_PaymentInvoice ");

            //sqlBuilder.AppendFormat("WHERE {0} IS NOT NULL AND payFor='{0}' ", field);
            sqlBuilder.AppendFormat("WHERE {0} IS NOT NULL ", field);
            if (field == "exp_premium")
            {
                sqlBuilder.Append("AND isDaidian = 1 ");
            }
            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.Append(where);
            }
            sqlBuilder.Append("GROUP BY policyId,invoiceID ");

            return DBHelper.GetDataSet(sqlBuilder.ToString());
        }

        public DataTable GetViewRegPaymentList(string where)
        {
            StringBuilder sqlBuilder = new StringBuilder();

            sqlBuilder.Append("SELECT * FROM View_PaymentList where isConfirm=1"); //已经做过付款确认的信息才显示


            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.Append(where);
            }

            sqlBuilder.Append(" ORDER BY makeTime desc ");

            return DBHelper.GetDataSet(sqlBuilder.ToString());
        }

        public DataTable GetViewPaymentList(string where)
        {
            StringBuilder sqlBuilder = new StringBuilder();

            sqlBuilder.Append("SELECT * FROM View_PaymentList ");
            sqlBuilder.Append(" where 1=1 ");

            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.Append(where);
            }

            sqlBuilder.Append(" ORDER BY makeTime desc ");

            return DBHelper.GetDataSet(sqlBuilder.ToString());
        }

        /// <summary>
        /// 更新付款申请的帐号信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateAccount(To_Payment Model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update To_Payment set ");
            strSql.Append(" bankName = @bankName ,");
            strSql.Append(" bankAccount = @bankAccount ,");
            strSql.Append(" bankAccountName = @bankAccountName ,");
            strSql.Append(" getBank = @getBank ,");
            strSql.Append(" getAccount = @getAccount ,");
            strSql.Append(" getAccountName = @getAccountName ,");
            strSql.Append(" payType = @payType ,");
            strSql.Append(" isConfirm = @isConfirm , ");
            strSql.Append(" confirmMan = @confirmMan , ");
            strSql.Append(" confirmDate = @confirmDate, ");
            strSql.Append(" bankId = @bankId ");
            strSql.Append(" where id=@id ");
            SqlParameter[] sp = 
            {
                new SqlParameter("@id", SqlDbType.VarChar,50),
                new SqlParameter("@bankName", SqlDbType.VarChar,50),
                new SqlParameter("@bankAccount", SqlDbType.VarChar,50),
                new SqlParameter("@bankAccountName", SqlDbType.VarChar,50),
                new SqlParameter("@getBank", SqlDbType.VarChar,50),
                new SqlParameter("@getAccount", SqlDbType.VarChar,50),
                new SqlParameter("@getAccountName", SqlDbType.VarChar,50),
                new SqlParameter("@payType", SqlDbType.VarChar,50),
                new SqlParameter("@isConfirm", SqlDbType.VarChar,50),
                new SqlParameter("@confirmMan",SqlDbType.VarChar,50),
                new SqlParameter("@confirmDate",SqlDbType.DateTime),
                new SqlParameter("@bankId",SqlDbType.Int,4)
            };
            sp[0].Value = Model.id;
            sp[1].Value = Model.bankName;
            sp[2].Value = Model.bankAccount;
            sp[3].Value = Model.bankAccountName;
            sp[4].Value = Model.getBank;
            sp[5].Value = Model.getAccount;
            sp[6].Value = Model.getAccountName;
            sp[7].Value = Model.payType;
            sp[8].Value = Model.isConfirm;
            sp[9].Value = Model.confirmMan;
            sp[10].Value = Model.confirmDate;
            sp[11].Value = Model.bankID;

            int result = DBHelper.ExecuteCommand(strSql.ToString(), sp);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 更新付款申请的财务支付
        /// </summary>
        /// <param name="paymentId">付款申请id</param>
        /// <param name="regtype">是否支付</param>
        /// <returns></returns>
        public bool UpdateReg(string paymentId, string regtype)
        {
            string sql = " update To_Payment set regType=" + regtype + " where id='" + paymentId + "'";
            int result = DBHelper.ExecuteCommand(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}