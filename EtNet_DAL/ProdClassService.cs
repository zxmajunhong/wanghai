using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace EtNet_DAL
{
    /// <summary>
    /// 数据访问类:ProdClassService
    /// </summary>
    public partial class ProdClassService
    {
        public ProdClassService()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EtNet_Models.ProdClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProdClass(");
            strSql.Append("ProdClassNo,ProdClassName,Prior,ViewInReport)");
            strSql.Append(" values (");
            strSql.Append("@ProdClassNo,@ProdClassName,@Prior,@ViewInReport)");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdClassNo", SqlDbType.Char,4),
					new SqlParameter("@ProdClassName", SqlDbType.Char,60),
					new SqlParameter("@Prior", SqlDbType.Int,4),
					new SqlParameter("@ViewInReport", SqlDbType.Bit,1)};
            parameters[0].Value = model.ProdClassNo;
            parameters[1].Value = model.ProdClassName;
            parameters[2].Value = model.Prior;
            parameters[3].Value = model.ViewInReport;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(EtNet_Models.ProdClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProdClass set ");
            strSql.Append("ProdClassName=@ProdClassName,");
            strSql.Append("Prior=@Prior,");
            strSql.Append("ViewInReport=@ViewInReport");
            strSql.Append(" where ProdClassNo=@ProdClassNo");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdClassNo", SqlDbType.Char,4),
					new SqlParameter("@ProdClassName", SqlDbType.Char,60),
					new SqlParameter("@Prior", SqlDbType.Int,4),
					new SqlParameter("@ViewInReport", SqlDbType.Bit,1)};
            parameters[0].Value = model.ProdClassNo;
            parameters[1].Value = model.ProdClassName;
            parameters[2].Value = model.Prior;
            parameters[3].Value = model.ViewInReport;

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
        public bool Delete(string num)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProdClass ");
            strSql.Append(" where ProdClassno=@Num");
            SqlParameter[] parameters = {
                                            new SqlParameter("@Num",num)
			};

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
        public EtNet_Models.ProdClass GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProdClassNo,ProdClassName,Prior,ViewInReport from ProdClass ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            EtNet_Models.ProdClass model = new EtNet_Models.ProdClass();
            DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ProdClassNo"] != null && dt.Rows[0]["ProdClassNo"].ToString() != "")
                {
                    model.ProdClassNo = dt.Rows[0]["ProdClassNo"].ToString();
                }
                if (dt.Rows[0]["ProdClassName"] != null && dt.Rows[0]["ProdClassName"].ToString() != "")
                {
                    model.ProdClassName = dt.Rows[0]["ProdClassName"].ToString();
                }
                if (dt.Rows[0]["Prior"] != null && dt.Rows[0]["Prior"].ToString() != "")
                {
                    model.Prior = int.Parse(dt.Rows[0]["Prior"].ToString());
                }
                if (dt.Rows[0]["ViewInReport"] != null && dt.Rows[0]["ViewInReport"].ToString() != "")
                {
                    if ((dt.Rows[0]["ViewInReport"].ToString() == "1") || (dt.Rows[0]["ViewInReport"].ToString().ToLower() == "true"))
                    {
                        model.ViewInReport = true;
                    }
                    else
                    {
                        model.ViewInReport = false;
                    }
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
            strSql.Append("select ProdClassNo,ProdClassName,Prior,ViewInReport ");
            strSql.Append(" FROM ProdClass ");
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
            strSql.Append(" ProdClassNo,ProdClassName,Prior,ViewInReport ");
            strSql.Append(" FROM ProdClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ProdClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DBHelper.ExecuteScalar(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from ProdClass T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBHelper.GetDataSet(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "ProdClass";
            parameters[1].Value = "";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

