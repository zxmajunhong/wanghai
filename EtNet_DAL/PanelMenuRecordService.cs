using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace EtNet_DAL
{
	/// <summary>
    /// 数据访问类:PanelMenuRecordService
	/// </summary>
	public  class PanelMenuRecordService
	{
        public PanelMenuRecordService()
		{}
		#region  Method

	
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from PanelMenuRecord");
			strSql.Append(" where id=@id");
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
		public static bool Add(EtNet_Models.PanelMenuRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PanelMenuRecord(");
			strSql.Append("founderid,totalcols,userempty)");
			strSql.Append(" values (");
			strSql.Append("@founderid,@totalcols,@userempty)");
			
			SqlParameter[] parameters = {
					new SqlParameter("@founderid", SqlDbType.Int,4),
					new SqlParameter("@totalcols", SqlDbType.Int,4),
					new SqlParameter("@userempty", SqlDbType.VarChar,10)};
			parameters[0].Value = model.founderid;
			parameters[1].Value = model.totalcols;
			parameters[2].Value = model.userempty;

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
		public static bool Update(EtNet_Models.PanelMenuRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PanelMenuRecord set ");
			strSql.Append("founderid=@founderid,");
			strSql.Append("totalcols=@totalcols,");
			strSql.Append("userempty=@userempty");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@founderid", SqlDbType.Int,4),
					new SqlParameter("@totalcols", SqlDbType.Int,4),
					new SqlParameter("@userempty", SqlDbType.VarChar,10),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.founderid;
			parameters[1].Value = model.totalcols;
			parameters[2].Value = model.userempty;
			parameters[3].Value = model.id;

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
			strSql.Append("delete from PanelMenuRecord ");
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
		/// 批量删除数据
		/// </summary>
		public static bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PanelMenuRecord ");
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
		/// 得到一个对象实体
		/// </summary>
		public static EtNet_Models.PanelMenuRecord GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,founderid,totalcols,userempty from PanelMenuRecord ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.PanelMenuRecord model = new EtNet_Models.PanelMenuRecord();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.founderid = int.Parse(tbl.Rows[0]["founderid"].ToString());
                model.totalcols = int.Parse(tbl.Rows[0]["totalcols"].ToString());
                model.userempty = tbl.Rows[0]["userempty"].ToString();
				
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
			strSql.Append("select id,founderid,totalcols,userempty ");
			strSql.Append(" FROM PanelMenuRecord ");
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
			strSql.Append(" id,founderid,totalcols,userempty ");
			strSql.Append(" FROM PanelMenuRecord ");
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

