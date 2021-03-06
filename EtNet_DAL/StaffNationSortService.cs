﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:StaffNationSortService
	/// </summary>
	public  class StaffNationSortService
	{
		public StaffNationSortService()
		{}
		#region  Method

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StaffNationSort");
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
		public static bool Add(EtNet_Models.StaffNationSort model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StaffNationSort(");
			strSql.Append("id,txt)");
			strSql.Append(" values (");
			strSql.Append("@id,@txt)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@txt", SqlDbType.VarChar,40)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.txt;

            int result = EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(),parameters);
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
		public static bool Update( EtNet_Models.StaffNationSort model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StaffNationSort set ");
			strSql.Append("txt=@txt");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@txt", SqlDbType.VarChar,40),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.txt;
			parameters[1].Value = model.id;
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
			strSql.Append("delete from StaffNationSort ");
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
			strSql.Append("delete from StaffNationSort ");
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
		public static EtNet_Models.StaffNationSort GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,txt from StaffNationSort ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.StaffNationSort model = new EtNet_Models.StaffNationSort();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
            if (tbl.Rows.Count > 0)
            {
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,txt ");
			strSql.Append(" FROM StaffNationSort ");
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
			strSql.Append(" id,txt ");
			strSql.Append(" FROM StaffNationSort ");
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

