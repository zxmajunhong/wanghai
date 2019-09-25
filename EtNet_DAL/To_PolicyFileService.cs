using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EtNet_Models;

namespace EtNet_DAL
{
    //To_PolicyFile
    public partial class To_PolicyFileService
    {

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from To_PolicyFile");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DBHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(To_PolicyFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into To_PolicyFile(");
            strSql.Append("policyID,filename,filepath,createTime,filesize");
            strSql.Append(") values (");
            strSql.Append("@policyID,@filename,@filepath,@createTime,@filesize");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@policyID", SqlDbType.Int,4) ,            
                        new SqlParameter("@filename", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@filepath", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@createTime", SqlDbType.DateTime),
                        new SqlParameter("@filesize",SqlDbType.Int)
              
            };

            parameters[0].Value = model.policyID;
            parameters[1].Value = model.filename;
            parameters[2].Value = model.filepath;
            parameters[3].Value = model.createTime;
            parameters[4].Value = model.Filesize;

            using (SqlConnection conn=new SqlConnection(DBHelper.connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    conn.Open();
                    sqlCmd.CommandText = strSql.ToString();
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.AddRange(parameters);

                    object objResult = sqlCmd.ExecuteScalar();

                    return objResult != null && objResult != DBNull.Value ? Convert.ToInt32(objResult) : 0;

                }
            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(To_PolicyFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update To_PolicyFile set ");

            strSql.Append(" policyID = @policyID , ");
            strSql.Append(" filename = @filename , ");
            strSql.Append(" filepath = @filepath , ");
            strSql.Append(" createTime = @createTime  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@policyID", SqlDbType.Int,4) ,            
                        new SqlParameter("@filename", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@filepath", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@createTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.policyID;
            parameters[2].Value = model.filename;
            parameters[3].Value = model.filepath;
            parameters[4].Value = model.createTime;
            int rows = DBHelper.ExecuteScalar(strSql.ToString(), parameters);
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
        /// 根据保单ID删除对应的数据
        /// </summary>
        public bool Delete(int policyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from To_PolicyFile ");
            strSql.Append(" where policyID=@policyID");
            SqlParameter[] parameters = {
					new SqlParameter("@policyID", SqlDbType.Int,4)
			};
            parameters[0].Value = policyID;


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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from To_PolicyFile ");
            strSql.Append(" where ID in (" + idlist + ")  ");
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
        public To_PolicyFile GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, policyID, filename, filepath, createTime,filesize  ");
            strSql.Append("  from To_PolicyFile ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            To_PolicyFile model = new To_PolicyFile();
            DataTable ds = DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Rows[0]["id"].ToString());
                }
                if (ds.Rows[0]["policyID"].ToString() != "")
                {
                    model.policyID = int.Parse(ds.Rows[0]["policyID"].ToString());
                }
                if (ds.Rows[0]["filesize"].ToString() != "")
                {
                    model.Filesize = int.Parse(ds.Rows[0]["filesize"].ToString());
                }
                model.filename = ds.Rows[0]["filename"].ToString();
                model.filepath = ds.Rows[0]["filepath"].ToString();
                if (ds.Rows[0]["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(ds.Rows[0]["createTime"].ToString());
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
            strSql.Append(" FROM To_PolicyFile ");
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
            strSql.Append(" FROM To_PolicyFile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.GetDataSet(strSql.ToString());
        }


    }
}