using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
    /// <summary>
    /// 数据访问类:FirmAccountInfoService
    /// </summary>
    public class FirmAccountInfoService
    {
        public FirmAccountInfoService()
        { }
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from FirmAccountInfo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            SqlDataReader rad = EtNet_DAL.DBHelper.GetReader(strSql.ToString(), parameters);
            if (rad.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(EtNet_Models.FirmAccountInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FirmAccountInfo(");
            strSql.Append("firmid,bankname,account,amount,ystime,remark)");
            strSql.Append(" values (");
            strSql.Append("@firmid,@bankname,@account,@amount,@ystime,@remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@firmid", SqlDbType.Int,4),
					new SqlParameter("@bankname", SqlDbType.VarChar,100),
					new SqlParameter("@account", SqlDbType.VarChar,40),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
                                        new SqlParameter("@amount",SqlDbType.Decimal,18),
                                        new SqlParameter("@ystime",SqlDbType.DateTime)};
            parameters[0].Value = model.firmid;
            parameters[1].Value = model.bankname;
            parameters[2].Value = model.account;
            parameters[3].Value = model.remark;
            parameters[4].Value = model.amount;
            parameters[5].Value = model.ystime;

            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
        public static bool Update(EtNet_Models.FirmAccountInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FirmAccountInfo set ");
            strSql.Append("firmid=@firmid,");
            strSql.Append("bankname=@bankname,");
            strSql.Append("account=@account,");
            strSql.Append("remark=@remark,");
            strSql.Append("amount=@amount,");
            strSql.Append("ystime=@ystime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@firmid", SqlDbType.Int,4),
					new SqlParameter("@bankname", SqlDbType.VarChar,100),
					new SqlParameter("@account", SqlDbType.VarChar,40),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4),
                                        new SqlParameter("@amount",SqlDbType.Decimal,18),
                                        new SqlParameter("@ystime",SqlDbType.DateTime)};
            parameters[0].Value = model.firmid;
            parameters[1].Value = model.bankname;
            parameters[2].Value = model.account;
            parameters[3].Value = model.remark;
            parameters[4].Value = model.id;
            parameters[5].Value = model.amount;
            parameters[6].Value = model.ystime; 

            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
        public static bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FirmAccountInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
        public static bool Del(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FirmAccountInfo ");
            if (strwhere != "")
            {
                strSql.Append(" where " + strwhere);
            }

            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString());
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
        /// 批量删除数据
        /// </summary>
        public static bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FirmAccountInfo ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.FirmAccountInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from FirmAccountInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            EtNet_Models.FirmAccountInfo model = new EtNet_Models.FirmAccountInfo();
            DataTable ds = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                model.id = int.Parse(ds.Rows[0]["id"].ToString());
                model.firmid = int.Parse(ds.Rows[0]["firmid"].ToString());
                model.bankname = ds.Rows[0]["bankname"].ToString();
                model.account = ds.Rows[0]["account"].ToString();
                model.remark = ds.Rows[0]["remark"].ToString();
                model.amount = Convert.ToDecimal(ds.Rows[0]["amount"].ToString());
                model.ystime = Convert.ToDateTime(ds.Rows[0]["ystime"].ToString());

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
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM FirmAccountInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM FirmAccountInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }




        #endregion  Method

        public static decimal GetMoneySum(string id, string moent,string ysdate)
        {
            string sql = "";
            decimal sum = 0;
            switch (moent)
            {
                case "0":
                    sql = "select sum(payMoney) as payMoney from ViewOutcome where payBankId = " + id;
                    sql += ysdate == "" ? "" : " and payDate >= '" + ysdate + "' ";
                    break;
                case "1":
                    sql = "select sum(SKMoney) as SKMoney from ViewIncome where SKBankId = " + id;
                    sql += ysdate == "" ? "" : " and SKDate >= '" + ysdate + "' ";
                    break;
            }
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                sum = Convert.IsDBNull(dt.Rows[0][0]) ? 0 : Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblname"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetExpense(string strWhere,string orderby)
        {
            string sql = "select * from ViewExpense ";
            if (strWhere != "")
            {
                sql += " where 1=1 " + strWhere;
            }
            if (orderby != "")
            {
                sql += " order by " + orderby;
            }
            return DBHelper.GetDataSet(sql);
        }
    }
}

