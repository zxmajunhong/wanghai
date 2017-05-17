using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;

namespace EtNet_DAL
{
    public class AusTypeInfoService
    {


        public AusTypeInfoService()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from AusTypeInfo");
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
        /// 增加一条数据
        /// </summary>
        public static bool Add(EtNet_Models.AusTypeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AusTypeInfo(");
            strSql.Append("typename,iscy)");
            strSql.Append(" values (");
            strSql.Append("@typename,@iscy)");

            SqlParameter[] parameters = {
					new SqlParameter("@typename", SqlDbType.VarChar,20),
                    new SqlParameter("@iscy",SqlDbType.VarChar,20)};
            parameters[0].Value = model.typename;
            parameters[1].Value = model.iscy;
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
        /// 更新一条数据
        /// </summary>

        public static bool Update(EtNet_Models.AusTypeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AusTypeInfo set ");
            strSql.Append(" typename=@typename,");
            strSql.Append(" iscy=@iscy");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@typename", SqlDbType.VarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@iscy",SqlDbType.VarChar,20)};
            parameters[0].Value = model.typename;
            parameters[1].Value = model.id;
            parameters[2].Value = model.iscy;

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
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AusTypeInfo ");
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
        public static bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AusTypeInfo ");
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
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.AusTypeInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,typename,iscy from AusTypeInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            EtNet_Models.AusTypeInfo model = null;

            SqlDataReader rad = DBHelper.ExecuteReader(strSql.ToString(), parameters);

            if (rad.Read())
            {
                model = new EtNet_Models.AusTypeInfo();
                model.id = rad.GetInt32(0);
                model.typename = rad.GetString(1);
                if (Convert.IsDBNull(rad.GetValue(2)))
                {
                    model.iscy = "";

                }
                else
                {
                    model.iscy = rad.GetString(2);
                }
                rad.Close();
                return model;
            }
            else
            {
                return model;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EtNet_Models.AusTypeInfo GetModelByTypename(string typename)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,typename,iscy from AusTypeInfo ");
            strSql.Append(" where typename=@typename");
            SqlParameter[] parameters = {
					new SqlParameter("@typename", SqlDbType.VarChar,20)};
            parameters[0].Value = typename;

            EtNet_Models.AusTypeInfo model = null;

            SqlDataReader rad = DBHelper.ExecuteReader(strSql.ToString(), parameters);

            if (rad.Read())
            {
                model = new EtNet_Models.AusTypeInfo();
                model.id = rad.GetInt32(0);
                model.typename = rad.GetString(1);
                if (Convert.IsDBNull(rad.GetValue(2)))
                {
                    model.iscy = "";
                    
                }
                else
                {
                    model.iscy = rad.GetString(2);
                }
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
            strSql.Append(" FROM AusTypeInfo ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by id desc");
            DataTable tbl = DBHelper.GetDataSet(strSql.ToString());
            return tbl;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static IList<AusTypeInfo> GetAllList()
        {
            string strSql = ("select * FROM AusTypeInfo");

            return getAusTypesBySql(strSql);
        }

        public static EtNet_Models.AusTypeInfo getAusTypesById(int id)
        {
            AusTypeInfo ausTypeInfo = new AusTypeInfo();
            string sql = "select * from AusTypeInfo where id = " + id;

            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    ausTypeInfo.id = Convert.ToInt32(dr["id"]);
                    ausTypeInfo.typename = Convert.ToString(dr["typename"]);
                    ausTypeInfo.iscy = Convert.ToString(dr["iscy"]);

                }
            }
            return ausTypeInfo;

        }

        public static IList<AusTypeInfo> getAusRottenInfo(int id)
        {
            IList<AusTypeInfo> list = new List<AusTypeInfo>();
            string sql = "select * from AusRottenInfo where reimbursedsort = " + id;
            //return getAusTypesBySql(sql);
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AusTypeInfo ausTypeInfo = new AusTypeInfo();
                    ausTypeInfo.id = Convert.ToInt32(dr["id"]);

                    list.Add(ausTypeInfo);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<AusTypeInfo> getAusTypesBySql(string sql)
        {
            IList<AusTypeInfo> list = new List<AusTypeInfo>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AusTypeInfo ausTypeInfo = new AusTypeInfo();
                    ausTypeInfo.id = Convert.ToInt32(dr["id"]);
                    ausTypeInfo.typename = Convert.ToString(dr["typename"]);
                    ausTypeInfo.iscy = Convert.ToString(dr["iscy"]);
                    list.Add(ausTypeInfo);
                }
            }
            return list;
        }
        #endregion  Method






    }
}
