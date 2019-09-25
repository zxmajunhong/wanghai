using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace EtNet_DAL
{
    public class AusOrderInfoService
    {
        public AusOrderInfoService()
        { }

        #region Method
        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from AusOrderInfo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            SqlDataReader rad = DBHelper.ExecuteReader(strSql.ToString(), parameters);
            try
            {
                if (rad.Read())
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                rad.Close();
            }
        }

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(EtNet_Models.AusOrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AusOrderInfo(");
            strSql.Append("orderId,jobflowId,orderNum,orderType,outTime,natrue,tour)");
            strSql.Append(" values (");
            strSql.Append("@orderId,@jobflowId,@orderNum,@orderType,@outTime,@natrue,@tour)");

            SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@jobflowId", SqlDbType.Int,4),
					new SqlParameter("@orderNum", SqlDbType.VarChar,50),
                    new SqlParameter("@orderType", SqlDbType.VarChar,50),
                    new SqlParameter("@outTime",SqlDbType.DateTime),
                    new SqlParameter("@natrue",SqlDbType.VarChar,50),
                    new SqlParameter("@tour", SqlDbType.VarChar,200)
                                        };

            parameters[0].Value = model.orderId;
            parameters[1].Value = model.jobflowId;
            parameters[2].Value = model.orderNum;
            parameters[3].Value = model.orderType;
            parameters[4].Value = model.outTime;
            parameters[5].Value = model.natrue;
            parameters[6].Value = model.tour;

            int result = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
            if (result >= 1)
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
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(EtNet_Models.AusOrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AusOrderInfo set ");
            strSql.Append("orderId=@orderId,");
            strSql.Append("jobflowId=@jobflowId,");
            strSql.Append("orderNum=@orderNum,");
            strSql.Append("orderType=@orderType,");
            strSql.Append("outTime=@outTime,");
            strSql.Append("natrue=@natrue,");
            strSql.Append("tour=@tour");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = { 
                    new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@jobflowId", SqlDbType.Int,4),
					new SqlParameter("@orderNum", SqlDbType.VarChar,50),
                    new SqlParameter("@orderType", SqlDbType.VarChar,50),
                    new SqlParameter("@outTime",SqlDbType.DateTime),
                    new SqlParameter("@natrue",SqlDbType.VarChar,50),
                    new SqlParameter("@tour", SqlDbType.VarChar,200),
                    new SqlParameter("@id",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.orderId;
            parameters[1].Value = model.jobflowId;
            parameters[2].Value = model.orderNum;
            parameters[3].Value = model.orderType;
            parameters[4].Value = model.outTime;
            parameters[5].Value = model.natrue;
            parameters[6].Value = model.tour;
            parameters[7].Value = model.id;

            int result = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
            if (result >= 1)
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
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AusOrderInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int result = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EtNet_Models.AusOrderInfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from AusOrderInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = 
            {
                new SqlParameter("@id",SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            EtNet_Models.AusOrderInfo model = null;

            DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new EtNet_Models.AusOrderInfo();
                model.id = Convert.ToInt32(dt.Rows[0]["id"]);
                model.orderId = Convert.ToInt32(dt.Rows[0]["orderId"]);
                model.orderNum = dt.Rows[0]["orderNum"].ToString();
                model.orderType = dt.Rows[0]["orderType"].ToString();
                model.outTime = Convert.ToDateTime(dt.Rows[0]["outTime"]);
                model.natrue = dt.Rows[0]["natrue"].ToString();
                model.tour = dt.Rows[0]["tour"].ToString();
            }

            return model;
        }

        /// <summary>
        /// 根据工作流id得到报销订单信息表
        /// </summary>
        /// <param name="jobflowId"></param>
        /// <returns></returns>
        public static DataTable GetList(string jobflowId)
        {
            string sql = " select * from AusOrderInfo where jobflowId = " + jobflowId;
            return DBHelper.GetDataSet(sql);
        }
        #endregion

        /// <summary>
        /// 根据工作流id删除报销订单信息数据
        /// </summary>
        /// <param name="jobflowid"></param>
        /// <returns></returns>
        public static bool Del(int jobflowid)
        {
            string sql = " delete from AusOrderInfo where jobflowId = " + jobflowid;
            int result = DBHelper.ExecuteCommand(sql);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable GetListBysql(string strWhere)
        {
            string strSql = "select * from AusOrderInfo ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return EtNet_DAL.DBHelper.GetDataSet(strSql);

        }
    }
}
