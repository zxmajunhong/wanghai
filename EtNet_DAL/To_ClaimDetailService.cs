using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EtNet_Models;
using System.Data;

namespace EtNet_DAL
{
    //To_ClaimDetail
    public partial class To_ClaimDetailService
    {

        public bool Exists(int policyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from To_ClaimDetail");
            strSql.Append(" where ");
            strSql.Append(" orderCollectId = @orderCollectId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@orderCollectId", SqlDbType.Int,4)
			};
            parameters[0].Value = policyID;

            return DBHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(To_ClaimDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into To_ClaimDetail(");
            strSql.Append("claimID,orderNum,orderCollectId,orderCusId,receiptAmount,realAmount,receiptStatusCode,mark");
            strSql.Append(") values (");
            strSql.Append("@claimID,@orderNum,@orderCollectId,@orderCusId,@receiptAmount,@realAmount,@receiptStatusCode,@mark");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@claimID", SqlDbType.Int,4) ,  
                        new SqlParameter("@orderNum", SqlDbType.VarChar,50) ,
                        new SqlParameter("@orderCollectId", SqlDbType.Int,4) ,
                        new SqlParameter("@orderCusId",SqlDbType.Int,4) ,
                        new SqlParameter("@receiptAmount", SqlDbType.Decimal,18) ,            
                        new SqlParameter("@realAmount", SqlDbType.Decimal,18) ,            
                        new SqlParameter("@receiptStatusCode", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@mark", SqlDbType.VarChar,500)             
              
            };

            parameters[0].Value = model.claimID;
            parameters[1].Value = model.orderNum;
            parameters[2].Value = model.orderCollectId;
            parameters[3].Value = model.orderCusId;
            parameters[4].Value = model.receiptAmount;
            parameters[5].Value = model.realAmount;
            parameters[6].Value = model.receiptStatusCode;
            parameters[7].Value = model.mark;

            //DBHelper.ExecuteCommand(strSql.ToString(), parameters);

            object objResult = DBHelper.GetSingle(strSql.ToString(), parameters);

            return objResult == null ? 0 : Convert.ToInt32(objResult);

            //using (SqlConnection conn= new SqlConnection(DBHelper.connectionString))
            //{
            //    conn.Open();
            //    SqlCommand command = new SqlCommand("select @@IDENTITY", conn);
            //    object id = command.ExecuteScalar();
            //    return id == null ? 0 : Convert.ToInt32(id);
            //}

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(To_ClaimDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update To_ClaimDetail set ");

            strSql.Append(" claimID = @claimID , ");
            strSql.Append(" policyID = @policyID , ");
            strSql.Append(" receiptAmount = @receiptAmount , ");
            strSql.Append(" realAmount = @realAmount , ");
            strSql.Append(" receiptStatusCode = @receiptStatusCode , ");
            strSql.Append(" mark = @mark  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@claimID", SqlDbType.Int,4) ,  
                        new SqlParameter("@orderNum", SqlDbType.VarChar,50) ,
                        new SqlParameter("@orderCollectId", SqlDbType.Int,4) ,
                        new SqlParameter("@orderCusId",SqlDbType.Int,4) ,
                        new SqlParameter("@receiptAmount", SqlDbType.Decimal,18) ,            
                        new SqlParameter("@realAmount", SqlDbType.Decimal,18) ,            
                        new SqlParameter("@receiptStatusCode", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@mark", SqlDbType.VarChar,500)           
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.claimID;
            parameters[2].Value = model.orderNum;
            parameters[3].Value = model.orderCollectId;
            parameters[4].Value = model.orderCusId;
            parameters[5].Value = model.receiptAmount;
            parameters[6].Value = model.realAmount;
            parameters[7].Value = model.receiptStatusCode;
            parameters[8].Value = model.mark;
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from To_ClaimDetail ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from To_ClaimDetail ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DBHelper.ExecuteCommand(strSql.ToString());
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
        public To_ClaimDetail GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from To_ClaimDetail ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            To_ClaimDetail model = new To_ClaimDetail();
            DataTable ds = DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Rows[0]["ID"].ToString());
                }
                if (ds.Rows[0]["claimID"].ToString() != "")
                {
                    model.claimID = int.Parse(ds.Rows[0]["claimID"].ToString());
                }
                model.orderNum = ds.Rows[0]["orderNum"].ToString();
                if (ds.Rows[0]["orderCollectId"].ToString() != "")
                {
                    model.orderCollectId = int.Parse(ds.Rows[0]["orderCollectId"].ToString());
                }
                if (ds.Rows[0]["orderCusId"].ToString() != "")
                {
                    model.orderCusId = int.Parse(ds.Rows[0]["orderCusId"].ToString());
                }
                if (ds.Rows[0]["receiptAmount"].ToString() != "")
                {
                    model.receiptAmount = decimal.Parse(ds.Rows[0]["receiptAmount"].ToString());
                }
                if (ds.Rows[0]["realAmount"].ToString() != "")
                {
                    model.realAmount = decimal.Parse(ds.Rows[0]["realAmount"].ToString());
                }
                if (ds.Rows[0]["receiptStatusCode"].ToString() != "")
                {
                    model.receiptStatusCode = int.Parse(ds.Rows[0]["receiptStatusCode"].ToString());
                }
                model.mark = ds.Rows[0]["mark"].ToString();

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
            strSql.Append(" FROM To_ClaimDetail ");
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
            strSql.Append(" FROM To_ClaimDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 根据ClaimID删除一条数据
        /// </summary>
        public bool DeleteByClaim(string claimID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from To_ClaimDetail ");
            strSql.Append(" where claimID=@claimID");
            SqlParameter[] parameters = {
					new SqlParameter("@claimID", SqlDbType.Int,4)
			};
            parameters[0].Value = claimID;


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
        /// 得到已经认领的金额
        /// </summary>
        /// <param name="ordercolid">订单收款信息明细id</param>
        /// <returns></returns>
        public double GetHasAmount(string ordercolid)
        {
            string sql = " select sum(realAmount) from To_claimDetail where orderCollectId=" + ordercolid;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                double hasAmount = 0;
                double.TryParse(dt.Rows[0][0].ToString(), out hasAmount);
                return hasAmount;
            }
            else
                return 0;
        }

        /// <summary>
        /// 得到已经认领的明细数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetHasDetail(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" from ViewClaimDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 得到收款明细统计表中所需要的已经认领的明细数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetCollectDetail(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" from ViewOrderCollectDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDataSet(strSql.ToString());

        }
    }
}
