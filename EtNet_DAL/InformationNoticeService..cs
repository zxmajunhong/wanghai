using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace EtNet_DAL
{
    //InformationNoticeService.
    public class InformationNoticeService
    {

        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from InformationNotice");
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



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(EtNet_Models.InformationNotice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into InformationNotice(");
            strSql.Append("informationid,recipientid,remind");
            strSql.Append(") values (");
            strSql.Append("@informationid,@recipientid,@remind");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@informationid", SqlDbType.Int,4) ,            
                        new SqlParameter("@recipientid", SqlDbType.Int,4),
                        new SqlParameter("@remind",SqlDbType.VarChar,10)};

            parameters[0].Value = model.informationid;
            parameters[1].Value = model.recipientid;
            parameters[2].Value = model.remind;

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
        public static bool Update(EtNet_Models.InformationNotice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update InformationNotice set ");
            strSql.Append(" informationid = @informationid , ");
            strSql.Append(" recipientid = @recipientid, ");
            strSql.Append(" remind = @remind");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@informationid", SqlDbType.Int,4) ,            
                        new SqlParameter("@recipientid", SqlDbType.Int,4),
                        new SqlParameter("@remind",SqlDbType.VarChar,10)
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.informationid;
            parameters[2].Value = model.recipientid;
            parameters[3].Value = model.remind;

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
            strSql.Append("delete from InformationNotice ");
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
            strSql.Append("delete from InformationNotice ");
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
        /// 依据指定条件删除多条数据
        /// </summary>
        public static bool Del(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from InformationNotice ");
            if (strWhere != "")
            {
                strSql.Append(" where  " + strWhere);
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
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.InformationNotice GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from InformationNotice ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;


            EtNet_Models.InformationNotice model = new EtNet_Models.InformationNotice();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
            {
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.informationid = int.Parse(tbl.Rows[0]["informationid"].ToString());
                model.recipientid = int.Parse(tbl.Rows[0]["recipientid"].ToString());
                model.remind = tbl.Rows[0]["remind"].ToString();

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
            strSql.Append(" FROM InformationNotice ");
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
            strSql.Append(" FROM InformationNotice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }


    }
}

