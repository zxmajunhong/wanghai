using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace EtNet_DAL
{
    /// <summary>
    /// 数据访问类:ProductService
    /// </summary>
    public partial class ProductService
    {
        public ProductService()
        { }
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public object Add(EtNet_Models.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Product(");
            strSql.Append("ProdNo,ProdName,ProdTypeID,Brief,FlagMain,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ProdNo,@ProdName,@ProdTypeID,@Brief,@FlagMain,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdNo", SqlDbType.NVarChar,30),
					new SqlParameter("@ProdName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProdTypeID", SqlDbType.Char,32),
					new SqlParameter("@Brief", SqlDbType.NText),
					new SqlParameter("@FlagMain", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NText)};
            parameters[0].Value = model.ProdNo;
            parameters[1].Value = model.ProdName;
            parameters[2].Value = model.ProdTypeID;
            parameters[3].Value = model.Brief;
            parameters[4].Value = model.FlagMain;
            parameters[5].Value = model.Remark;

            object obj = DBHelper.ExecuteScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return null;
            }
            else
            {
                return obj;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EtNet_Models.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Product set ");
            strSql.Append("ProdNo=@ProdNo,");
            strSql.Append("ProdName=@ProdName,");
            strSql.Append("ProdTypeID=@ProdTypeID,");
            strSql.Append("Brief=@Brief,");
            strSql.Append("FlagMain=@FlagMain,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ProdID=@ProdID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdNo", SqlDbType.NVarChar,30),
					new SqlParameter("@ProdName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProdTypeID", SqlDbType.Char,32),
					new SqlParameter("@Brief", SqlDbType.NText),
					new SqlParameter("@FlagMain", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@ProdID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProdNo;
            parameters[1].Value = model.ProdName;
            parameters[2].Value = model.ProdTypeID;
            parameters[3].Value = model.Brief;
            parameters[4].Value = model.FlagMain;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.ProdID;

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
        public bool Delete(int ProdID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where ProdID=@ProdID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdID", SqlDbType.Int,4)
			};
            parameters[0].Value = ProdID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string ProdIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where ProdID in (" + ProdIDlist + ")  ");
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
        public EtNet_Models.Product GetModel(int ProdID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProdID,ProdNo,ProdName,ProdTypeID,Brief,PremiumRate,FlagMain,Remark,CommRate,ProcRate from Product ");
            strSql.Append(" where ProdID=@ProdID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdID", SqlDbType.Int,4)
			};
            parameters[0].Value = ProdID;

            EtNet_Models.Product model = new EtNet_Models.Product();
            DataTable ds = DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["ProdID"] != null && ds.Rows[0]["ProdID"].ToString() != "")
                {
                    model.ProdID = int.Parse(ds.Rows[0]["ProdID"].ToString());
                }
                if (ds.Rows[0]["ProdNo"] != null && ds.Rows[0]["ProdNo"].ToString() != "")
                {
                    model.ProdNo = ds.Rows[0]["ProdNo"].ToString();
                }
                if (ds.Rows[0]["ProdName"] != null && ds.Rows[0]["ProdName"].ToString() != "")
                {
                    model.ProdName = ds.Rows[0]["ProdName"].ToString();
                }
                if (ds.Rows[0]["ProdTypeID"] != null && ds.Rows[0]["ProdTypeID"].ToString() != "")
                {
                    model.ProdTypeID = ds.Rows[0]["ProdTypeID"].ToString();
                }
                if (ds.Rows[0]["Brief"] != null && ds.Rows[0]["Brief"].ToString() != "")
                {
                    model.Brief = ds.Rows[0]["Brief"].ToString();
                }
                if (ds.Rows[0]["PremiumRate"] != null && ds.Rows[0]["PremiumRate"].ToString() != "")
                {
                    model.PremiumRate = decimal.Parse(ds.Rows[0]["PremiumRate"].ToString());
                }
                if (ds.Rows[0]["FlagMain"] != null && ds.Rows[0]["FlagMain"].ToString() != "")
                {
                    if ((ds.Rows[0]["FlagMain"].ToString() == "1") || (ds.Rows[0]["FlagMain"].ToString().ToLower() == "true"))
                    {
                        model.FlagMain = true;
                    }
                    else
                    {
                        model.FlagMain = false;
                    }
                }
                if (ds.Rows[0]["Remark"] != null && ds.Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Rows[0]["Remark"].ToString();
                }
                if (ds.Rows[0]["CommRate"] != null && ds.Rows[0]["CommRate"].ToString() != "")
                {
                    model.CommRate = decimal.Parse(ds.Rows[0]["CommRate"].ToString());
                }
                if (ds.Rows[0]["ProcRate"] != null && ds.Rows[0]["ProcRate"].ToString() != "")
                {
                    model.ProcRate = decimal.Parse(ds.Rows[0]["ProcRate"].ToString());
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
            strSql.Append("select ProdID,ProdNo,ProdName,ProdTypeID,Brief,PremiumRate,FlagMain,Remark,CommRate,ProcRate ");
            strSql.Append(" FROM Product ");
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
            strSql.Append(" ProdID,ProdNo,ProdName,ProdTypeID,Brief,PremiumRate,FlagMain,Remark,CommRate,ProcRate ");
            strSql.Append(" FROM Product ");
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
            strSql.Append("select count(1) FROM Product ");
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
                strSql.Append("order by T.ProdID desc");
            }
            strSql.Append(")AS Row, T.*  from Product T ");
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
            parameters[0].Value = "Product";
            parameters[1].Value = "ProdID";
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

