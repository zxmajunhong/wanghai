using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[To_Policy]表的数据访问类
    /// </summary>
    public class To_PolicyService
    {
        /// <summary>
        ///[To_Policy]表添加的方法
        /// </summary>
        public static int addTo_Policy(To_Policy to_policy)
        {
            string sql = "insert into To_Policy([serialnum],[policy_date],[policy_maker],[policy_num],[policy_startdate],[policy_enddate],[policy_state],[assured],[customer],[company],[protype],[isVerify],[verifyUser],[verifydate],[salesman],[IsRenewal],[policy_makerId],[userCompany],[isDaidian],[txt],[orderNum],[codeFormart],[totalPremium],[totalBrokerage],[totalEcoRate],[totalEconomic],[totalRich],[shipName]) values (@serialnum,@policy_date,@policy_maker,@policy_num,@policy_startdate,@policy_enddate,@policy_state,@assured,@customer,@company,@protype,@isVerify,@verifyUser,@verifydate,@salesman,@IsRenewal,@policy_makerId,@userCompany,@isDaidian,@txt,@orderNum,@codeFormart,@totalPremium,@totalBrokerage,@totalEcoRate,@totalEconomic,@totalRich,@shipName);select @@IDENTITY";
            SqlParameter[] sp = new SqlParameter[]
            {
            new SqlParameter("@serialnum",to_policy.Serialnum),
            new SqlParameter("@policy_date",to_policy.Policy_date),
            new SqlParameter("@policy_maker",to_policy.Policy_maker),
            new SqlParameter("@policy_num",to_policy.Policy_num),
            new SqlParameter("@policy_startdate",to_policy.Policy_startdate),
            new SqlParameter("@policy_enddate",to_policy.Policy_enddate),
            new SqlParameter("@policy_state",to_policy.Policy_state),
            new SqlParameter("@assured",to_policy.Assured),
            new SqlParameter("@customer",to_policy.Customer),
            new SqlParameter("@company",to_policy.Company),
            new SqlParameter("@protype",to_policy.Protype),
            new SqlParameter("@isVerify",to_policy.IsVerify),
            new SqlParameter("@verifyUser",to_policy.VerifyUser),
            new SqlParameter("@verifydate",to_policy.Verifydate),
            new SqlParameter("@salesman",to_policy.Salesman),
            new SqlParameter("@IsRenewal",to_policy.IsRenewal),
            new SqlParameter("@policy_makerId",to_policy.Policy_makerId),
            new SqlParameter("@userCompany",to_policy.UserCompany),
            new SqlParameter("@isDaidian",to_policy.IsDaidian),
            new SqlParameter("@txt",to_policy.Txt),
            new SqlParameter("@orderNum",to_policy.OrderNum),
            new SqlParameter("@codeFormart",to_policy.CodeFormart),
            new SqlParameter("@totalPremium",to_policy.TotalPremium),
            new SqlParameter("@totalBrokerage",to_policy.TotalBrokerage),
            new SqlParameter("@totalEcoRate",to_policy.TotalEcoRate),
            new SqlParameter("@totalEconomic",to_policy.TotalEconomic),
            new SqlParameter("totalRich",to_policy.TotalRich),
            new SqlParameter("@shipName",to_policy.ShipName)
            };
            // DBHelper.ExecuteCommand(sql, sp);

            using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(sp);
                object id = command.ExecuteScalar();
                return id == DBNull.Value ? 0 : Convert.ToInt32(id);
            }
        }

        /// <summary>
        ///[To_Policy]表修改的方法
        /// </summary>
        public static int updateTo_PolicyById(To_Policy to_policy)
        {

            string sql = "update To_Policy set serialnum=@serialnum,policy_date=@policy_date,policy_maker=@policy_maker,policy_num=@policy_num,policy_startdate=@policy_startdate,policy_enddate=@policy_enddate,policy_state=@policy_state,assured=@assured,customer=@customer,company=@company,protype=@protype,isVerify=@isVerify,verifyUser=@verifyUser,verifydate=@verifydate,IsRenewal=@IsRenewal,userCompany=@userCompany,isDaidian=@isDaidian,txt=@txt,orderNum=@orderNum,codeFormart=@codeFormart,totalPremium=@totalPremium,totalBrokerage=@totalBrokerage,totalEcoRate=@totalEcoRate,totalEconomic=@totalEconomic,totalRich=@totalRich,shipName=@shipName where id=@id";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@id",to_policy.Id),
                new SqlParameter("@serialnum",to_policy.Serialnum),
                new SqlParameter("@policy_date",to_policy.Policy_date),
                new SqlParameter("@policy_maker",to_policy.Policy_maker),
                new SqlParameter("@policy_num",to_policy.Policy_num),
                new SqlParameter("@policy_startdate",to_policy.Policy_startdate),
                new SqlParameter("@policy_enddate",to_policy.Policy_enddate),
                new SqlParameter("@policy_state",to_policy.Policy_state),
                new SqlParameter("@assured",to_policy.Assured),
                new SqlParameter("@customer",to_policy.Customer),
                new SqlParameter("@company",to_policy.Company),
                new SqlParameter("@protype",to_policy.Protype),
                new SqlParameter("@isVerify",to_policy.IsVerify),
                new SqlParameter("@verifyUser",to_policy.VerifyUser),
                new SqlParameter("@verifydate",to_policy.Verifydate),

                //new SqlParameter("@salesman",to_policy.Salesman),

                new SqlParameter("@IsRenewal",to_policy.IsRenewal),
                new SqlParameter("@userCompany",to_policy.UserCompany),
                new SqlParameter("@isDaidian",to_policy.IsDaidian),
                new SqlParameter("@txt",to_policy.Txt),
                new SqlParameter("@orderNum",to_policy.OrderNum),
                new SqlParameter("@codeFormart",to_policy.CodeFormart),
                new SqlParameter("@totalPremium",to_policy.TotalPremium),
                new SqlParameter("@totalBrokerage",to_policy.TotalBrokerage),
                new SqlParameter("@totalEcoRate",to_policy.TotalEcoRate),
                new SqlParameter("@totalEconomic",to_policy.TotalEconomic),
                new SqlParameter("@totalRich",to_policy.TotalRich),
                new SqlParameter("@shipName",to_policy.ShipName)
             };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        /// To_Policy 表的业务员列Salesman修改方法
        /// </summary>
        /// <param name="salesman">业务员</param>
        /// <param name="prid">id</param>
        /// <returns></returns>
        public static int updateTo_PolicySalesman(string salesman, int prid)
        {
            string sql = "update To_Policy set persons=@persons where id=@id";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@persons",salesman),
                new SqlParameter("@id",prid)
            };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[To_Policy]表删除的方法
        /// </summary>
        public static int deleteTo_PolicyById(int id)
        {

            string sql = "delete from To_Policy where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[To_Policy]表查询实体的方法
        /// </summary>
        public static To_Policy getTo_PolicyById(int id)
        {
            To_Policy to_policy = null;

            string sql = "select * from To_Policy where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                to_policy = new To_Policy();
                foreach (DataRow dr in dt.Rows)
                {
                    to_policy.Id = Convert.ToInt32(dr["id"]);
                    to_policy.Serialnum = Convert.ToString(dr["serialnum"]);
                    to_policy.Policy_date = Convert.ToDateTime(dr["policy_date"]);
                    to_policy.Policy_maker = Convert.ToString(dr["policy_maker"]);
                    to_policy.Policy_num = Convert.ToString(dr["policy_num"]);
                    to_policy.Policy_startdate = Convert.ToString(dr["policy_startdate"]);
                    to_policy.Policy_enddate = Convert.ToString(dr["policy_enddate"]);
                    to_policy.Policy_state = Convert.ToInt32(dr["policy_state"]);
                    to_policy.Assured = Convert.ToString(dr["assured"]);
                    to_policy.Customer = Convert.ToInt32(dr["customer"]);
                    to_policy.Company = Convert.ToInt32(dr["company"]);
                    to_policy.Protype = Convert.ToString(dr["protype"]);
                    to_policy.IsVerify = int.Parse(dr["isVerify"].ToString());
                    to_policy.VerifyUser = Convert.ToString(dr["verifyUser"]);
                    to_policy.Verifydate = Convert.ToDateTime(dr["verifydate"]);
                    to_policy.Salesman = Convert.ToInt32(dr["salesman"]);
                    to_policy.IsRenewal = Convert.ToInt32(dr["IsRenewal"]);
                    to_policy.Policy_makerId = Convert.ToInt32(dr["policy_makerId"]);
                    to_policy.UserCompany = dr["userCompany"].ToString();
                    to_policy.CodeFormart = dr["codeFormart"].ToString();
                    to_policy.OrderNum = dr["orderNum"].ToString();
                    to_policy.Txt = dr["txt"].ToString();
                    to_policy.IsDaidian = Convert.ToInt32(dr["isDaidian"]);

                    to_policy.TotalPremium = Convert.IsDBNull(dr["totalPremium"]) ? 0.0 : Convert.ToDouble(dr["totalPremium"]);
                    to_policy.TotalBrokerage = Convert.IsDBNull(dr["totalBrokerage"]) ? 0.0 : Convert.ToDouble(dr["totalBrokerage"]);
                    to_policy.TotalEcoRate = Convert.IsDBNull(dr["totalEcoRate"]) ? 0.0 : Convert.ToDouble(dr["totalEcoRate"]);
                    to_policy.TotalEconomic = Convert.IsDBNull(dr["totalEconomic"]) ? 0.0 : Convert.ToDouble(dr["totalEconomic"]);
                    to_policy.TotalRich = Convert.IsDBNull(dr["totalRich"]) ? 0.0 : Convert.ToDouble(dr["totalRich"]);
                    to_policy.ShipName = Convert.ToString(dr["shipName"]);
                }
            }

            return to_policy;
        }

        /// <summary>
        ///[To_Policy]表查询所有的方法
        /// </summary>
        public static IList<To_Policy> getTo_PolicyAll()
        {
            string sql = "select * from To_Policy";
            return getTo_PolicysBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<To_Policy> getTo_PolicysBySql(string sql)
        {
            IList<To_Policy> list = new List<To_Policy>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    To_Policy to_policy = new To_Policy();
                    to_policy.Id = Convert.ToInt32(dr["id"]);
                    to_policy.Serialnum = Convert.ToString(dr["serialnum"]);
                    to_policy.Policy_date = Convert.ToDateTime(dr["policy_date"]);
                    to_policy.Policy_maker = Convert.ToString(dr["policy_maker"]);
                    to_policy.Policy_num = Convert.ToString(dr["policy_num"]);
                    to_policy.Policy_startdate = Convert.ToString(dr["policy_startdate"]);
                    to_policy.Policy_enddate = Convert.ToString(dr["policy_enddate"]);
                    to_policy.Policy_state = Convert.ToInt32(dr["policy_state"]);
                    to_policy.Assured = Convert.ToString(dr["assured"]);
                    to_policy.Customer = Convert.ToInt32(dr["customer"]);
                    to_policy.Company = Convert.ToInt32(dr["company"]);
                    to_policy.Protype = Convert.ToString(dr["protype"]);
                    to_policy.IsVerify = Convert.ToInt32(dr["isVerify"]);
                    to_policy.VerifyUser = Convert.ToString(dr["verifyUser"]);
                    to_policy.Verifydate = Convert.ToDateTime(dr["verifydate"]);
                    to_policy.Salesman = Convert.ToInt32(dr["salesman"]);
                    to_policy.IsRenewal = Convert.ToInt32(dr["IsRenewal"]);
                    to_policy.Policy_makerId = Convert.ToInt32(dr["policy_makerId"]);
                    to_policy.UserCompany = dr["userCompany"].ToString();
                    to_policy.CodeFormart = dr["codeFormart"].ToString();
                    to_policy.OrderNum = dr["orderNum"].ToString();
                    to_policy.Txt = dr["txt"].ToString();
                    to_policy.IsDaidian = Convert.ToInt32(dr["isDaidian"]);

                    to_policy.TotalPremium = Convert.IsDBNull(dr["totalPremium"]) ? 0.0 : Convert.ToDouble(dr["totalPremium"]);
                    to_policy.TotalBrokerage = Convert.IsDBNull(dr["totalBrokerage"]) ? 0.0 : Convert.ToDouble(dr["totalBrokerage"]);
                    to_policy.TotalEcoRate = Convert.IsDBNull(dr["totalEcoRate"]) ? 0.0 : Convert.ToDouble(dr["totalEcoRate"]);
                    to_policy.TotalEconomic = Convert.IsDBNull(dr["totalEconomic"]) ? 0.0 : Convert.ToDouble(dr["totalEconomic"]);
                    to_policy.TotalRich = Convert.IsDBNull(dr["totalRich"]) ? 0.0 : Convert.ToDouble(dr["totalRich"]);
                    to_policy.ShipName = Convert.ToString(dr["shipName"]);

                    list.Add(to_policy);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static To_Policy getTo_PolicyBySql(string sql)
        {
            To_Policy to_policy = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                to_policy = new To_Policy();
                foreach (DataRow dr in dt.Rows)
                {
                    to_policy.Id = Convert.ToInt32(dr["id"]);
                    to_policy.Serialnum = Convert.ToString(dr["serialnum"]);
                    to_policy.Policy_date = Convert.ToDateTime(dr["policy_date"]);
                    to_policy.Policy_maker = Convert.ToString(dr["policy_maker"]);
                    to_policy.Policy_num = Convert.ToString(dr["policy_num"]);
                    to_policy.Policy_startdate = Convert.ToString(dr["policy_startdate"]);
                    to_policy.Policy_enddate = Convert.ToString(dr["policy_enddate"]);
                    to_policy.Policy_state = Convert.ToInt32(dr["policy_state"]);
                    to_policy.Assured = Convert.ToString(dr["assured"]);
                    to_policy.Customer = Convert.ToInt32(dr["customer"]);
                    to_policy.Company = Convert.ToInt32(dr["company"]);
                    to_policy.Protype = Convert.ToString(dr["protype"]);
                    to_policy.IsVerify = Convert.ToInt32(dr["isVerify"]);
                    to_policy.VerifyUser = Convert.ToString(dr["verifyUser"]);
                    to_policy.Verifydate = Convert.ToDateTime(dr["verifydate"]);
                    to_policy.Salesman = Convert.ToInt32(dr["salesman"]);
                    to_policy.IsRenewal = Convert.ToInt32(dr["IsRenewal"]);
                    to_policy.Policy_makerId = Convert.ToInt32(dr["policy_makerId"]);
                    to_policy.CodeFormart = dr["codeFormart"].ToString();
                    to_policy.OrderNum = dr["orderNum"].ToString();
                    to_policy.Txt = dr["txt"].ToString();
                    to_policy.IsDaidian = Convert.ToInt32(dr["isDaidian"]);
                    to_policy.UserCompany = dr["userCompany"].ToString();

                    to_policy.TotalPremium = Convert.IsDBNull(dr["totalPremium"]) ? 0.0 : Convert.ToDouble(dr["totalPremium"]);
                    to_policy.TotalBrokerage = Convert.IsDBNull(dr["totalBrokerage"]) ? 0.0 : Convert.ToDouble(dr["totalBrokerage"]);
                    to_policy.TotalEcoRate = Convert.IsDBNull(dr["totalEcoRate"]) ? 0.0 : Convert.ToDouble(dr["totalEcoRate"]);
                    to_policy.TotalEconomic = Convert.IsDBNull(dr["totalEconomic"]) ? 0.0 : Convert.ToDouble(dr["totalEconomic"]);
                    to_policy.TotalRich = Convert.IsDBNull(dr["totalRich"]) ? 0.0 : Convert.ToDouble(dr["totalRich"]);
                    to_policy.ShipName = Convert.ToString(dr["shipName"]);
                }
            }
            return to_policy;
        }




        #region 无用代码

        //public static DataTable GetList(int? id)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select p.id as pid,com.id as comid,cus.id as cusid,* from To_Policy as p ");
        //    sql.Append("left join LoginInfo as l on p.salesman=l.id ");
        //    sql.Append("left join dbo.Customer as cus on p.customer=cus.id ");
        //    sql.Append("left join dbo.Company as com on p.company=com.id ");
        //    sql.Append("left join dbo.ProductType as pt on p.protype=pt.ProdTypeNo ");

        //    StringBuilder where = new StringBuilder();

        //    if (id != null)
        //    {
        //        where.AppendFormat("and p.id={0}", id);
        //    }
        //    sql.Append(where);
        //    DataTable dt = DBHelper.GetDataSet(sql.ToString());
        //    return dt;
        //}

        //public static DataTable GetListByPage(int? id, int loginId, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("SELECT * FROM ( ");
        //    sql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        sql.Append("order by p." + orderby);
        //    }
        //    else
        //    {
        //        sql.Append("order by p.policy_date desc");
        //    }
        //    sql.Append(")AS Row,");
        //    sql.Append("p.id as pid,com.id as comid,cus.id as cusid,p.*,cusCName,comCname,cname,ProdTypeName from To_Policy as p ");
        //    sql.Append("left join LoginInfo as l on p.salesman=l.id ");
        //    sql.Append("left join dbo.Customer as cus on p.customer=cus.id ");
        //    sql.Append("left join dbo.Company as com on p.company=com.id ");
        //    sql.Append("left join dbo.ProductType as pt on p.protype=pt.ProdTypeNo ");

        //    StringBuilder where = new StringBuilder();
        //    string ids = LoginDataLimitServices.GetLimit(loginId);
        //    if (string.IsNullOrEmpty(ids))
        //    {
        //        where.AppendFormat("where policy_makerId = {0} ", loginId);
        //    }
        //    else
        //    {
        //        where.AppendFormat("where policy_makerId in ({0}) ", ids + "," + loginId);
        //    }

        //    if (id != null)
        //    {
        //        where.AppendFormat("and p.id={0}", id);
        //    }
        //    sql.Append(where);
        //    sql.Append(" ) TT");
        //    sql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    DataTable dt = DBHelper.GetDataSet(sql.ToString());
        //    return dt;
        //} 
        #endregion


        public static DataTable GetList(int? id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from ViewPolicy ");

            StringBuilder where = new StringBuilder();

            if (id != null)
            {
                where.AppendFormat("where id={0}", id);
            }
            sql.Append(where);
            DataTable dt = DBHelper.GetDataSet(sql.ToString());
            return dt;
        }

        public static DataTable GetListByPage(int? id, int loginId, string orderby, string strWhere, int startIndex, int endIndex)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM ( ");
            sql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sql.Append("order by p." + orderby);
            }
            else
            {
                sql.Append("order by p.id desc");
            }
            sql.Append(")AS Row,");
            sql.Append("p.* from ViewPolicy as p ");

            StringBuilder where = new StringBuilder();
            string ids = LoginDataLimitServices.GetLimit(loginId);
            if (string.IsNullOrEmpty(ids))
            {
                where.AppendFormat("where policy_makerId = {0} ", loginId);
            }
            else
            {
                where.AppendFormat("where policy_makerId in ({0}) ", ids + "," + loginId);
            }

            if (id != null)
            {
                where.AppendFormat("and p.id={0}", id);
            }
            sql.Append(where);
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.Append(strWhere);
            }
            sql.Append(" ) TT");
            sql.AppendFormat(" WHERE TT.Row between {0} and {1} ", startIndex, endIndex);


            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sql.Append("order by " + orderby + " ");
            }
            else
            {
                sql.Append("order by id desc ");
            }
            DataTable dt = DBHelper.GetDataSet(sql.ToString());
            return dt;
        }

        public static Nullable<int> GetCount(string where, int loginId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(*) from ViewPolicy ");
            //if (where != string.Empty)
            //    sql += "where 1=1 " + where;

            string ids = LoginDataLimitServices.GetLimit(loginId);
            if (string.IsNullOrEmpty(ids))
            {
                sql.AppendFormat("where policy_makerId = {0} ", loginId);
            }
            else
            {
                sql.AppendFormat("where policy_makerId in ({0}) ", ids + "," + loginId);
            }

            if (string.IsNullOrEmpty(where))
                sql.Append(where);

            object result = DBHelper.ExecuteScalar(sql.ToString());
            if (result == null)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(result);
            }
        }

        public static Nullable<int> GetCount()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(*) from ViewPolicy ");

            object result = DBHelper.ExecuteScalar(sql.ToString());
            if (result == null)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(result);
            }
        }

        public static int getCountByCustomerID(string id)
        {
            string sql = "select count(*) from To_Policy where customer = " + id;
            return DBHelper.ExecuteScalar(sql);
        }

        public static int getCountByCompanyID(string id)
        {
            string sql = "select count(*) from To_Policy where company = " + id;
            return DBHelper.ExecuteScalar(sql);
        }
        public static DataTable GetLists(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from ViewPolicy ");
            if (strWhere != "")
            {
                sql.Append(" where " + strWhere);
            }
            DataTable dt = DBHelper.GetDataSet(sql.ToString());
            return dt;
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
            strSql.Append(" FROM To_Policy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 根据提供的字段验证是否存在相同的数据
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public static bool ExitsRecordByField(string fieldName, string fieldValue, object ID)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT COUNT(*) FROM To_Policy WHERE ");
            sqlBuilder.AppendFormat("[{0}] = @value ", fieldName);
            if (ID != null)
            {
                sqlBuilder.AppendFormat("AND id!={0}", ID);
            }

            SqlParameter sqlParam = new SqlParameter("@value", fieldValue);
            return DBHelper.ExecuteScalar(sqlBuilder.ToString(), sqlParam) > 0 ? true : false;
        }

        public static int Clear()
        {
            string sql = "truncate table To_Policy;truncate table To_PolicyBudget;truncate table To_PolicyDetail;truncate table To_PolicyTarget";
            return DBHelper.ExecuteCommand(sql);
        }
    }
}
