using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace EtNet_DAL
{
    //InformationService
    public class InformationService
    {

        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Information");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            SqlDataReader rad = EtNet_DAL.DBHelper.GetReader(strSql.ToString(), parameters);
            if (rad.Read())
            {
                rad.Close();
                return true;
            }
            else
            {
                return false;
            }

        }


        public static int GetMaxId(string login)
        {
            string strSql = "select * from Information ";

            if (login != "")
            {
                strSql += " where founderid =" + login;
            }

            strSql += "  order by id desc";
            int maxid = EtNet_DAL.DBHelper.ExecuteScalar(strSql);
            return maxid;

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(EtNet_Models.Information model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Information(");
            strSql.Append("contents,sortid,associationid,founderid,createtime,sendtime");
            strSql.Append(") values (");
            strSql.Append("@contents,@sortid,@associationid,@founderid,@createtime,@sendtime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@contents", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@sortid", SqlDbType.Int,4) ,            
                        new SqlParameter("@associationid", SqlDbType.Int,4) ,                    
                        new SqlParameter("@founderid", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@sendtime", SqlDbType.SmallDateTime)             
              
            };

            parameters[0].Value = model.contents;
            parameters[1].Value = model.sortid;
            parameters[2].Value = model.associationid;
            parameters[3].Value = model.founderid;
            parameters[4].Value = model.createtime;
            parameters[5].Value = model.sendtime;

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
        public static bool Update(EtNet_Models.Information model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Information set ");
            strSql.Append(" contents = @contents , ");
            strSql.Append(" sortid = @sortid , ");
            strSql.Append(" associationid = @associationid , ");
            strSql.Append(" founderid = @founderid , ");
            strSql.Append(" createtime = @createtime , ");
            strSql.Append(" sendtime = @sendtime  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@contents", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@sortid", SqlDbType.Int,4) ,            
                        new SqlParameter("@associationid", SqlDbType.Int,4) ,                    
                        new SqlParameter("@founderid", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@sendtime", SqlDbType.SmallDateTime) };

            parameters[0].Value = model.id;
            parameters[1].Value = model.contents;
            parameters[2].Value = model.sortid;
            parameters[3].Value = model.associationid;
            parameters[4].Value = model.founderid;
            parameters[5].Value = model.createtime;
            parameters[6].Value = model.sendtime;

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
            strSql.Append("delete from Information ");
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
        public static bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Information ");
            strSql.Append(" where ID in (" + idlist + ")  ");
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
        public static EtNet_Models.Information GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, contents, sortid, associationid, founderid, createtime, sendtime  ");
            strSql.Append("  from Information ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;


            EtNet_Models.Information model = new EtNet_Models.Information();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
            {
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.contents = tbl.Rows[0]["contents"].ToString();
                model.sortid = int.Parse(tbl.Rows[0]["sortid"].ToString());
                model.associationid = int.Parse(tbl.Rows[0]["associationid"].ToString());
                model.founderid = int.Parse(tbl.Rows[0]["founderid"].ToString());
                model.createtime = DateTime.Parse(tbl.Rows[0]["createtime"].ToString());
                model.sendtime = DateTime.Parse(tbl.Rows[0]["sendtime"].ToString());

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
            strSql.Append(" FROM Information ");
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
            strSql.Append(" FROM Information ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }



        public static int Clear()
        {
            string sql = "truncate table Information;truncate table InformationFile;truncate table InformationNotice;";
            return DBHelper.ExecuteCommand(sql);
        }
    }
}

