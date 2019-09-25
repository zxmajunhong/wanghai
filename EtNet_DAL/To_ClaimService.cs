using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EtNet_Models;

namespace EtNet_DAL
{
    //To_Claim
    public partial class To_ClaimService
    {

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from To_Claim");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DBHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(To_Claim model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into To_Claim(");
            strSql.Append("collectingID,collectingNum,makerman,makerID,payer,payerID,collectAmount");
            strSql.Append(") values (");
            strSql.Append("@collectingID,@collectingNum,@makerman,@makerID,@payer,@payerID,@collectAmount");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@collectingID", SqlDbType.Int,4) ,
                        new SqlParameter("@collectingNum", SqlDbType.VarChar,50),
                        new SqlParameter("@makerman", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@makerID", SqlDbType.Int,4) ,            
                        new SqlParameter("@payer", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@payerID", SqlDbType.Int,4) ,            
                        new SqlParameter("@collectAmount", SqlDbType.Decimal,18)
              
            };

            parameters[0].Value = model.collectingID;
            parameters[1].Value = model.collectingNum;
            parameters[2].Value = model.makerman;
            parameters[3].Value = model.MakerID;
            parameters[4].Value = model.payer;
            parameters[5].Value = model.payerID;
            parameters[6].Value = model.collectAmount;

            //DBHelper.ExecuteCommand(strSql.ToString(), parameters);

            object objResult = DBHelper.GetSingle(strSql.ToString(), parameters);

            return objResult == null ? 0 : Convert.ToInt32(objResult);

            //using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
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
        public bool Update(To_Claim model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update To_Claim set ");

            strSql.Append(" collectingID = @collectingID , ");
            strSql.Append(" collectingNum = @collectingNum , ");
            strSql.Append(" makerman = @makerman , ");
            strSql.Append(" makerID = @makerID , ");
            strSql.Append(" payer = @payer , ");
            strSql.Append(" payerID = @payerID , ");
            strSql.Append(" collectAmount = @collectAmount ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@collectingID", SqlDbType.Int,4) ,
                        new SqlParameter("@collectingNum", SqlDbType.VarChar,50),
                        new SqlParameter("@makerman", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@makerID", SqlDbType.Int,4) ,            
                        new SqlParameter("@payer", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@payerID", SqlDbType.Int,4) ,            
                        new SqlParameter("@collectAmount", SqlDbType.Decimal,18)
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.collectingID;
            parameters[2].Value = model.collectingNum;
            parameters[3].Value = model.makerman;
            parameters[4].Value = model.MakerID;
            parameters[5].Value = model.payer;
            parameters[6].Value = model.payerID;
            parameters[7].Value = model.collectAmount;
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
            strSql.Append("delete from To_Claim ");
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
            strSql.Append("delete from To_Claim ");
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
        public To_Claim GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from To_Claim ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            To_Claim model = new To_Claim();
            DataTable ds = DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Rows[0]["ID"].ToString());
                }
                if (ds.Rows[0]["collectingID"].ToString() != "")
                {
                    model.collectingID = int.Parse(ds.Rows[0]["collectingID"].ToString());
                }
                model.makerman = ds.Rows[0]["makerman"].ToString();
                if (ds.Rows[0]["makerID"].ToString() != "")
                {
                    model.MakerID = int.Parse(ds.Rows[0]["makerID"].ToString());
                }
                model.payer = ds.Rows[0]["payer"].ToString();
                if (ds.Rows[0]["payerID"].ToString() != "")
                {
                    model.payerID = int.Parse(ds.Rows[0]["payerID"].ToString());
                }
                if (ds.Rows[0]["collectAmount"].ToString() != "")
                {
                    model.collectAmount = Convert.ToDouble(ds.Rows[0]["collectAmount"]);
                }

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
            strSql.Append(" FROM To_Claim ");
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
            strSql.Append(" FROM To_Claim ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 检测收款记录是否已被认领
        /// </summary>
        /// <param name="collectingID"></param>
        /// <returns></returns>
        public bool ExitsCollecting(int collectingID)
        {
            string sql = "select count(*) from To_Claim where collectingID=@collectingID ";
            SqlParameter param = new SqlParameter("@collectingID", collectingID);
            return DBHelper.ExecuteScalar(sql, param) > 0;
        }

        /// <summary>
        /// 根据收款记录ID获取认领表ID
        /// </summary>
        /// <param name="collectingID"></param>
        /// <returns></returns>
        public string GetID(int collectingID)
        {
            string sql = "select ID from To_Claim where collectingID=@collectingID ";
            using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
            {
                SqlParameter param = new SqlParameter("@collectingID", collectingID);

                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(param);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "temp");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }
            }
            //StringBuilder idList = new StringBuilder();
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i][0] != null)
            //        idList.AppendFormat("{0},", ds.Tables[0].Rows[i][0].ToString().Trim());
            //}

            //return idList.Length > 0 ? idList.ToString().TrimEnd(',') : "";
        }

        /// <summary>
        /// 根据收款记录ID获取所需字段值
        /// </summary>
        /// <param name="collectingID"></param>
        /// <returns></returns>
        public string GetFiledValue(int collectingID, string filed)
        {
            string sql = string.Format("select {0} from To_Claim where collectingID=@collectingID ", filed);
            using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                SqlParameter param = new SqlParameter("@collectingID", collectingID);

                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(param);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "temp");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }
            }
            //StringBuilder idList = new StringBuilder();
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i][0] != null)
            //        idList.AppendFormat("{0},", ds.Tables[0].Rows[i][0].ToString().Trim());
            //}

            //return idList.Length > 0 ? idList.ToString().TrimEnd(',') : "";
        }

        public string GetFiledValueByClaimId(int claimId, string filed)
        {
            string sql = string.Format("select {0} from To_Collecting where ID=(select collectingID from To_Claim where ID={1} ", filed,claimId);
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            else
                return "";
        }
    }
}
