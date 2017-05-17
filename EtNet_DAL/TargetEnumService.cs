using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
namespace EtNet_DAL
{
    //TargetEnum
    public partial class TargetEnumService
    {




        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(EtNet_Models.TargetEnum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TargetEnum(");
            strSql.Append("EnumTypeId,EnumId,EnumValue");
            strSql.Append(") values (");
            strSql.Append("@EnumTypeId,@EnumId,@EnumValue");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@EnumTypeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@EnumId", SqlDbType.Int,4) ,            
                        new SqlParameter("@EnumValue", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.EnumTypeId;
            parameters[1].Value = model.EnumId;
            parameters[2].Value = model.EnumValue;
            DBHelper.ExecuteCommand(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EtNet_Models.TargetEnum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TargetEnum set ");

            strSql.Append(" EnumTypeId = @EnumTypeId , ");
            strSql.Append(" EnumId = @EnumId , ");
            strSql.Append(" EnumValue = @EnumValue  ");
            strSql.Append(" where EnumTypeId=@EnumTypeId and EnumId=@EnumId and EnumValue=@EnumValue  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@EnumTypeId", SqlDbType.Int,4) ,            
                        new SqlParameter("@EnumId", SqlDbType.Int,4) ,            
                        new SqlParameter("@EnumValue", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.EnumTypeId;
            parameters[1].Value = model.EnumId;
            parameters[2].Value = model.EnumValue;
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
        public bool Delete(int EnumTypeId, int EnumId, string EnumValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TargetEnum ");
            strSql.Append(" where EnumTypeId=@EnumTypeId and EnumId=@EnumId and EnumValue=@EnumValue ");
            SqlParameter[] parameters = {
					new SqlParameter("@EnumTypeId", SqlDbType.Int,4),
					new SqlParameter("@EnumId", SqlDbType.Int,4),
					new SqlParameter("@EnumValue", SqlDbType.NVarChar,50)			};
            parameters[0].Value = EnumTypeId;
            parameters[1].Value = EnumId;
            parameters[2].Value = EnumValue;


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
        /// 删除一组数据
        /// </summary>
        public bool Delete(int EnumTypeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TargetEnum ");
            strSql.Append(" where EnumTypeId=@EnumTypeId");
            SqlParameter[] parameters = {
					new SqlParameter("@EnumTypeId", SqlDbType.Int,4)};
            parameters[0].Value = EnumTypeId;


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
        public EtNet_Models.TargetEnum GetModel(int EnumTypeId, int EnumId, string EnumValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EnumTypeId, EnumId, EnumValue  ");
            strSql.Append("  from TargetEnum ");
            strSql.Append(" where EnumTypeId=@EnumTypeId and EnumId=@EnumId and EnumValue=@EnumValue ");
            SqlParameter[] parameters = {
					new SqlParameter("@EnumTypeId", SqlDbType.Int,4),
					new SqlParameter("@EnumId", SqlDbType.Int,4),
					new SqlParameter("@EnumValue", SqlDbType.NVarChar,50)			};
            parameters[0].Value = EnumTypeId;
            parameters[1].Value = EnumId;
            parameters[2].Value = EnumValue;


            EtNet_Models.TargetEnum model = new EtNet_Models.TargetEnum();
            DataTable dt = DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["EnumTypeId"].ToString() != "")
                {
                    model.EnumTypeId = int.Parse(dt.Rows[0]["EnumTypeId"].ToString());
                }
                if (dt.Rows[0]["EnumId"].ToString() != "")
                {
                    model.EnumId = int.Parse(dt.Rows[0]["EnumId"].ToString());
                }
                model.EnumValue = dt.Rows[0]["EnumValue"].ToString();

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
            strSql.Append(" FROM TargetEnum ");
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
            strSql.Append(" FROM TargetEnum ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.GetDataSet(strSql.ToString());
        }

        public int GetMaxId()
        {
            string sql = string.Format("select MAX(EnumTypeId) from TargetEnum");
            return DBHelper.ExecuteScalar(sql);
        }
    }
}

