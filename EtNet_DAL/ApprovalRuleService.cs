using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace EtNet_DAL
{

    public partial class ApprovalRuleService
    {

        public static bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ApprovalRule");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        public static bool Add(EtNet_Models.ApprovalRule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ApprovalRule(");
            strSql.Append("sort,idgourp,txt,jobflowsort,cname,rolepic,departidlist,departidtxt,hide,showpattern");
            strSql.Append(") values (");
            strSql.Append("@sort,@idgourp,@txt,@jobflowsort,@cname,@rolepic,@departidlist,@departidtxt,@hide,@showpattern");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@sort", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@idgourp", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@txt", SqlDbType.VarChar,40),
                        new SqlParameter("@jobflowsort",SqlDbType.VarChar,4),
                        new SqlParameter("@cname", SqlDbType.VarChar,20),
                        new SqlParameter("@rolepic",SqlDbType.VarChar,500),
                        new SqlParameter("@departidlist",SqlDbType.VarChar,400),
                        new SqlParameter("@departidtxt",SqlDbType.VarChar,1000),
                        new SqlParameter("@hide",SqlDbType.VarChar,400),
                        new SqlParameter("@showpattern",SqlDbType.VarChar,400)};


            parameters[0].Value = model.sort;
            parameters[1].Value = model.idgourp;
            parameters[2].Value = model.txt;
            parameters[3].Value = model.jobflowsort;
            parameters[4].Value = model.cname;
            parameters[5].Value = model.rolepic;
            parameters[6].Value = model.departidlist;
            parameters[7].Value = model.departidtxt;
            parameters[8].Value = model.hide;
            parameters[9].Value = model.showpattern;

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
        public static bool Update(EtNet_Models.ApprovalRule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApprovalRule set ");
            strSql.Append(" sort = @sort , ");
            strSql.Append(" idgourp = @idgourp , ");
            strSql.Append(" txt = @txt ,  ");
            strSql.Append(" jobflowsort = @jobflowsort,  ");
            strSql.Append(" cname = @cname, ");
            strSql.Append(" rolepic = @rolepic, ");
            strSql.Append(" departidlist= @departidlist, ");
            strSql.Append(" departidtxt = @departidtxt,");
            strSql.Append(" showpattern = @showpattern");

            strSql.Append(" where id=@id ");


            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@sort", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@idgourp", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@txt", SqlDbType.VarChar,40),
                        new SqlParameter("@jobflowsort",SqlDbType.VarChar,4),
                        new SqlParameter("@cname", SqlDbType.VarChar,20),
                        new SqlParameter("@rolepic",SqlDbType.VarChar,500),
                        new SqlParameter("@departidlist",SqlDbType.VarChar,400),
			            new SqlParameter("@departidtxt",SqlDbType.VarChar,1000),
            new SqlParameter("@showpattern",SqlDbType.VarChar,1000)};
                


            parameters[0].Value = model.id;
            parameters[1].Value = model.sort;
            parameters[2].Value = model.idgourp;
            parameters[3].Value = model.txt;
            parameters[4].Value = model.jobflowsort;
            parameters[5].Value = model.cname;
            parameters[6].Value = model.rolepic;
            parameters[7].Value = model.departidlist;
            parameters[8].Value = model.departidtxt;
            parameters[9].Value = model.showpattern;
           


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
        /// 更新一条数据(隐藏按钮专用)
        /// </summary>
        public static bool UpdateHide(EtNet_Models.ApprovalRule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApprovalRule set ");
            strSql.Append(" sort = @sort , ");
            strSql.Append(" idgourp = @idgourp , ");
            strSql.Append(" txt = @txt ,  ");
            strSql.Append(" jobflowsort = @jobflowsort,  ");
            strSql.Append(" cname = @cname, ");
            strSql.Append(" rolepic = @rolepic, ");
            strSql.Append(" departidlist= @departidlist, ");
            strSql.Append(" departidtxt = @departidtxt,");
            strSql.Append(" hide = @hide");
            strSql.Append(" where id=@id ");


            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@sort", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@idgourp", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@txt", SqlDbType.VarChar,40),
                        new SqlParameter("@jobflowsort",SqlDbType.VarChar,4),
                        new SqlParameter("@cname", SqlDbType.VarChar,20),
                        new SqlParameter("@rolepic",SqlDbType.VarChar,500),
                        new SqlParameter("@departidlist",SqlDbType.VarChar,400),
			            new SqlParameter("@departidtxt",SqlDbType.VarChar,1000),
                        new SqlParameter("@hide",SqlDbType.Int,4)};


            parameters[0].Value = model.id;
            parameters[1].Value = model.sort;
            parameters[2].Value = model.idgourp;
            parameters[3].Value = model.txt;
            parameters[4].Value = model.jobflowsort;
            parameters[5].Value = model.cname;
            parameters[6].Value = model.rolepic;
            parameters[7].Value = model.departidlist;
            parameters[8].Value = model.departidtxt;
            parameters[9].Value = model.hide;


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
            strSql.Append("delete from ApprovalRule ");
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
            strSql.Append("delete from ApprovalRule ");
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
        public static EtNet_Models.ApprovalRule GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from ApprovalRule ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            EtNet_Models.ApprovalRule model = new EtNet_Models.ApprovalRule();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
            {

                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.sort = tbl.Rows[0]["sort"].ToString();
                model.idgourp = tbl.Rows[0]["idgourp"].ToString();
                model.txt = tbl.Rows[0]["txt"].ToString();
                model.jobflowsort = tbl.Rows[0]["jobflowsort"].ToString();
                model.cname = tbl.Rows[0]["cname"].ToString();
                model.rolepic = tbl.Rows[0]["rolepic"].ToString();
                model.departidlist = tbl.Rows[0]["departidlist"].ToString();
                model.departidtxt = tbl.Rows[0]["departidtxt"].ToString();
                model.hide = Convert.ToInt32(tbl.Rows[0]["hide"].ToString());
                model.showpattern = Convert.ToInt32( tbl.Rows[0]["showpattern"].ToString());
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
            strSql.Append(" FROM ApprovalRule ");
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
            strSql.Append(" FROM ApprovalRule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
        }


    }
}

