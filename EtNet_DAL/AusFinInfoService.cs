using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;

namespace EtNet_DAL
{
    public class AusFinInfoService
    {
        public AusFinInfoService()
        { }
        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from AusFinInfo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};

            parameters[0].Value = id;
            SqlDataReader rad = DBHelper.ExecuteReader(strSql.ToString(), parameters);

            try
            {
                if (rad.Read())
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                rad.Close();
            }
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(EtNet_Models.AusFinInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AusFinInfo(");
            strSql.Append("itemname)");
            strSql.Append(" values (");
            strSql.Append("@itemname)");

            SqlParameter[] parameters = {
					new SqlParameter("@itemname", SqlDbType.VarChar,20)};
            parameters[0].Value = model.itemname;
            int result = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(EtNet_Models.AusFinInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AusFinInfo set ");
            strSql.Append(" itemname=@itemname");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@itemname", SqlDbType.VarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.itemname;
            parameters[1].Value = model.id;

            int result = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AusFinInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            int result = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
        /// <param name="idlist"></param>
        /// <returns></returns>
        public static bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AusFinInfo ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int result = DBHelper.ExecuteCommand(strSql.ToString());
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
        /// 得到一个对象的实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EtNet_Models.AusFinInfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from AusFinInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            EtNet_Models.AusFinInfo model = null;

            SqlDataReader rad = DBHelper.ExecuteReader(strSql.ToString(), parameters);

            if (rad.Read())
            {
                model = new EtNet_Models.AusFinInfo();
                model.id = rad.GetInt32(0);
                model.itemname = rad.GetString(1);
                rad.Close();
                return model;
            }
            else
            {
                return model;
            }
        }

        /// <summary>
        /// 根据名字得到实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static EtNet_Models.AusFinInfo GetModelByName(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from AusFinInfo ");
            strSql.Append(" where itemname=@itemname");
            SqlParameter[] parameters = {
					new SqlParameter("@itemname", SqlDbType.VarChar,20)};
            parameters[0].Value = name;

            EtNet_Models.AusFinInfo model = null;

            SqlDataReader rad = DBHelper.ExecuteReader(strSql.ToString(), parameters);

            if (rad.Read())
            {
                model = new EtNet_Models.AusFinInfo();
                model.id = rad.GetInt32(0);
                model.itemname = rad.GetString(1);
                rad.Close();
                return model;
            }
            else
            {
                return model;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AusFinInfo ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable tbl = DBHelper.GetDataSet(strSql.ToString());
            return tbl;
        }
        #endregion
    }
}
