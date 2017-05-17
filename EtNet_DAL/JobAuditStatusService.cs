﻿using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace EtNet_DAL
{

    public class JobAuditStatusService
    {

        public static bool Exists(string num)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from JobAuditStatus");
            strSql.Append(" where ");
            strSql.Append(" num = @num  ");
            SqlParameter[] parameters = {
					new SqlParameter("@num", SqlDbType.VarChar,4)};

            parameters[0].Value = num;

            SqlDataReader rad = EtNet_DAL.DBHelper.ExecuteReader(strSql.ToString(), parameters);
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
        public static bool Add(EtNet_Models.JobAuditStatus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into JobAuditStatus(");
            strSql.Append("num,txt");
            strSql.Append(") values (");
            strSql.Append("@num,@txt");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@num", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@txt", SqlDbType.VarChar,20)             
              
            };

            parameters[0].Value = model.num;
            parameters[1].Value = model.txt;

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
        public static bool Update(EtNet_Models.JobAuditStatus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JobAuditStatus set ");
            strSql.Append(" num = @num , ");
            strSql.Append(" txt = @txt  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@num", SqlDbType.VarChar,4) ,            
                        new SqlParameter("@txt", SqlDbType.VarChar,20)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.num;
            parameters[2].Value = model.txt;
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
            strSql.Append("delete from JobAuditStatus ");
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
            strSql.Append("delete from JobAuditStatus ");
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
        public static EtNet_Models.JobAuditStatus GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, num, txt  ");
            strSql.Append("  from JobAuditStatus ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;


            EtNet_Models.JobAuditStatus model = new EtNet_Models.JobAuditStatus();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
            {

                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.num = tbl.Rows[0]["num"].ToString();
                model.txt = tbl.Rows[0]["txt"].ToString();

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
            strSql.Append(" FROM JobAuditStatus ");
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
            strSql.Append(" FROM JobAuditStatus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }



        public static EtNet_Models.JobAuditStatus GetModelByNUM(string num)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, num, txt  ");
            strSql.Append("  from JobAuditStatus ");
            strSql.Append(" where num=@num");
            SqlParameter[] parameters = {
					new SqlParameter("@num", SqlDbType.Int,4)};
            parameters[0].Value = num;


            EtNet_Models.JobAuditStatus model = new EtNet_Models.JobAuditStatus();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
            {

                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.num = tbl.Rows[0]["num"].ToString();
                model.txt = tbl.Rows[0]["txt"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}

