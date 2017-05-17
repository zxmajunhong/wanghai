using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace EtNet_DAL
{
    /// <summary>
    /// 数据访问类:TargetPropertyService
    /// </summary>
    public partial class TargetPropertyService
    {
        public TargetPropertyService()
        { }
        #region  Method

        public int GetMaxID(int typeID)
        {
            string sql = "select MAX(PropertyId) from TargetProperty where TargetTypeId=@TargetTypeId";
            return DBHelper.ExecuteScalar(sql, new SqlParameter("@TargetTypeId", typeID));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EtNet_Models.TargetProperty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TargetProperty(");
            strSql.Append("TargetTypeId,PropertyId,PropertyNO,PropertyName,PropertyType,MainFlag,EnumTypeId,IsRequired)");
            strSql.Append(" values (");
            strSql.Append("@TargetTypeId,@PropertyId,@PropertyNO,@PropertyName,@PropertyType,@MainFlag,@EnumTypeId,@IsRequired)");
            SqlParameter[] parameters = {
					new SqlParameter("@TargetTypeId", SqlDbType.Int,4),
					new SqlParameter("@PropertyId", SqlDbType.Int,4),
					new SqlParameter("@PropertyNO", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyType", SqlDbType.Int,4),
					new SqlParameter("@MainFlag", SqlDbType.Bit,1),
                    new SqlParameter("@EnumTypeId",SqlDbType.Int,4),
                    new SqlParameter("@IsRequired",SqlDbType.Bit,1)
                                        };
            parameters[0].Value = model.TargetTypeId;
            parameters[1].Value = model.PropertyId;
            parameters[2].Value = model.PropertyNO;
            parameters[3].Value = model.PropertyName;
            parameters[4].Value = model.PropertyType;
            if (model.MainFlag == null)
                parameters[5].Value = DBNull.Value;
            else
                parameters[5].Value = model.MainFlag;
            parameters[6].Value = model.EnumTypeId;
            if (model.IsRequired == null)
            {
                parameters[7].Value = DBNull.Value;
            }
            else
            {
                parameters[7].Value = model.IsRequired;
            }

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
        public bool Update(EtNet_Models.TargetProperty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TargetProperty set ");
            strSql.Append("PropertyNO=@PropertyNO,");
            strSql.Append("PropertyName=@PropertyName,");
            strSql.Append("PropertyType=@PropertyType,");
            strSql.Append("MainFlag=@MainFlag,");
            strSql.Append("EnumTypeId=@EnumTypeId,");
            strSql.Append("IsRequired=@IsRequired");
            strSql.Append(" where TargetTypeId=@TargetTypeId and PropertyId=@PropertyId ");
            SqlParameter[] parameters = {
					new SqlParameter("@TargetTypeId", SqlDbType.Int,4),
					new SqlParameter("@PropertyId", SqlDbType.Int,4),
					new SqlParameter("@PropertyNO", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyName", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyType", SqlDbType.Int,4),
					new SqlParameter("@MainFlag", SqlDbType.Bit,1),
                    new SqlParameter("@EnumTypeId",SqlDbType.Int,4),
                    new SqlParameter("@IsRequired",SqlDbType.Bit,1)
                                        };
            parameters[0].Value = model.TargetTypeId;
            parameters[1].Value = model.PropertyId;
            parameters[2].Value = model.PropertyNO;
            parameters[3].Value = model.PropertyName;
            parameters[4].Value = model.PropertyType;
            if (model.MainFlag == null)
                parameters[5].Value = DBNull.Value;
            else
                parameters[5].Value = model.MainFlag;
            parameters[6].Value = model.EnumTypeId;
            if (model.IsRequired == null)
            {
                parameters[7].Value = DBNull.Value;
            }
            else
            {
                parameters[7].Value = model.IsRequired;
            }

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
        public bool Delete(int typeID, int targetId)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TargetProperty ");
            strSql.AppendFormat(" where TargetTypeId={0} and PropertyId={1} ", typeID, targetId);
            SqlParameter[] parameters = {
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


        public bool Delete(int typeID)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TargetProperty ");
            strSql.AppendFormat(" where TargetTypeId={0} ", typeID);
            SqlParameter[] parameters = {
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
        public EtNet_Models.TargetProperty GetModel(int typeId, int targetId)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TargetTypeId,PropertyId,PropertyNO,PropertyName,PropertyType,MainFlag,EnumTypeId,IsRequired from TargetProperty ");
            strSql.Append(string.Format(" where TargetTypeId={0} and PropertyId={1}", typeId, targetId));
            SqlParameter[] parameters = {
			};

            EtNet_Models.TargetProperty model = new EtNet_Models.TargetProperty();
            DataTable ds = DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["TargetTypeId"] != null && ds.Rows[0]["TargetTypeId"].ToString() != "")
                {
                    model.TargetTypeId = int.Parse(ds.Rows[0]["TargetTypeId"].ToString());
                }
                if (ds.Rows[0]["PropertyId"] != null && ds.Rows[0]["PropertyId"].ToString() != "")
                {
                    model.PropertyId = int.Parse(ds.Rows[0]["PropertyId"].ToString());
                }
                if (ds.Rows[0]["PropertyNO"] != null && ds.Rows[0]["PropertyNO"].ToString() != "")
                {
                    model.PropertyNO = ds.Rows[0]["PropertyNO"].ToString();
                }
                if (ds.Rows[0]["PropertyName"] != null && ds.Rows[0]["PropertyName"].ToString() != "")
                {
                    model.PropertyName = ds.Rows[0]["PropertyName"].ToString();
                }
                if (ds.Rows[0]["PropertyType"] != null && ds.Rows[0]["PropertyType"].ToString() != "")
                {
                    model.PropertyType = int.Parse(ds.Rows[0]["PropertyType"].ToString());
                }
                if (ds.Rows[0]["MainFlag"] != null && ds.Rows[0]["MainFlag"].ToString() != "")
                {
                    if ((ds.Rows[0]["MainFlag"].ToString() == "1") || (ds.Rows[0]["MainFlag"].ToString().ToLower() == "true"))
                    {
                        model.MainFlag = true;
                    }
                    else
                    {
                        model.MainFlag = false;
                    }
                }
                if (ds.Rows[0]["EnumTypeId"] != null && ds.Rows[0]["EnumTypeId"].ToString() != "")
                {
                    model.EnumTypeId = int.Parse(ds.Rows[0]["EnumTypeId"].ToString());
                }
                if (ds.Rows[0]["IsRequired"] != null && ds.Rows[0]["IsRequired"].ToString() != "")
                {
                    if ((ds.Rows[0]["IsRequired"].ToString() == "1") || (ds.Rows[0]["IsRequired"].ToString().ToLower() == "true"))
                    {
                        model.IsRequired = true;
                    }
                    else
                    {
                        model.IsRequired = false;
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
            strSql.Append("select TargetTypeId,PropertyId,PropertyNO,PropertyName,PropertyType,MainFlag,EnumTypeId,IsRequired ");
            strSql.Append(" FROM TargetProperty ");
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
            strSql.Append(" TargetTypeId,PropertyId,PropertyNO,PropertyName,PropertyType,MainFlag,IsRequired ");
            strSql.Append(" FROM TargetProperty ");
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
            strSql.Append("select count(1) FROM TargetProperty ");
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
                strSql.Append("order by T.ProdTypeNo desc");
            }
            strSql.Append(")AS Row, T.*  from TargetProperty T ");
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
            parameters[0].Value = "TargetProperty";
            parameters[1].Value = "ProdTypeNo";
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

