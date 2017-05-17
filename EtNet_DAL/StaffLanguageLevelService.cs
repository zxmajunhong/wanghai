using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:StaffLanguageLevelService
	/// </summary>
	public partial class StaffLanguageLevelService
	{
		public StaffLanguageLevelService()
		{}
		#region  Method

	
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from StaffLanguageLevel");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            SqlDataReader rad = EtNet_DAL.DBHelper.GetReader(strSql.ToString(), parameters);
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
		public static bool Add( EtNet_Models.StaffLanguageLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StaffLanguageLevel(");
			strSql.Append("staffid,kinds,gradetxt,remark)");
			strSql.Append(" values (");
			strSql.Append("@staffid,@kinds,@gradetxt,@remark)");
			SqlParameter[] parameters = {
				
					new SqlParameter("@staffid", SqlDbType.Int,4),
					new SqlParameter("@kinds", SqlDbType.VarChar,40),
					new SqlParameter("@gradetxt", SqlDbType.VarChar,40),
					new SqlParameter("@remark", SqlDbType.VarChar,200)};
	
			parameters[0].Value = model.staffid;
			parameters[1].Value = model.kinds;
			parameters[2].Value = model.gradetxt;
			parameters[3].Value = model.remark;
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
		public static bool Update(EtNet_Models.StaffLanguageLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StaffLanguageLevel set ");
			strSql.Append("staffid=@staffid,");
			strSql.Append("kinds=@kinds,");
			strSql.Append("gradetxt=@gradetxt,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@staffid", SqlDbType.Int,4),
					new SqlParameter("@kinds", SqlDbType.VarChar,40),
					new SqlParameter("@gradetxt", SqlDbType.VarChar,40),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.staffid;
			parameters[1].Value = model.kinds;
			parameters[2].Value = model.gradetxt;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.id;

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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StaffLanguageLevel ");
			strSql.Append(" where id=@id ");
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
		/// 批量删除数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StaffLanguageLevel ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
        /// 批量删除数据,指定筛选条件，筛选条件为空删除全部数据
        /// </summary>
        public static bool DelList(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StaffLanguageLevel ");
            if (strwhere != "")
            {
                strSql.Append(" where " + strwhere + " ");
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
		public static EtNet_Models.StaffLanguageLevel GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,staffid,kinds,gradetxt,remark from StaffLanguageLevel ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.StaffLanguageLevel model = new EtNet_Models.StaffLanguageLevel();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
            {
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.staffid = int.Parse(tbl.Rows[0]["staffid"].ToString());
                model.kinds = tbl.Rows[0]["kinds"].ToString();
                model.gradetxt = tbl.Rows[0]["gradetxt"].ToString();
                model.remark = tbl.Rows[0]["remark"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,staffid,kinds,gradetxt,remark ");
			strSql.Append(" FROM StaffLanguageLevel ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,staffid,kinds,gradetxt,remark ");
			strSql.Append(" FROM StaffLanguageLevel ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}

		

		#endregion  Method
	}
}

