using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
    /// 数据访问类:PanelMenuService
	/// </summary>
	public  class PanelMenuService
	{
        public PanelMenuService()
		{}
		#region  Method


        /// <summary>
        /// 返回最大的id值
        /// </summary>
        public static int MaxId()
        {
            string strSql = "select * from PanelMenu order by id desc";
            return EtNet_DAL.DBHelper.ExecuteScalar(strSql);

        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from PanelMenu");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            SqlDataReader rad = EtNet_DAL.DBHelper.GetReader(strSql.ToString(),parameters);
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
		public static bool Add(EtNet_Models.PanelMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PanelMenu(");
			strSql.Append("founderid,colsnum,rowsnum,title,imageload,direction)");
			strSql.Append(" values (");
			strSql.Append("@founderid,@colsnum,@rowsnum,@title,@imageload,@direction)");
			
			SqlParameter[] parameters = {
					new SqlParameter("@founderid", SqlDbType.Int,4),
					new SqlParameter("@colsnum", SqlDbType.Int,4),
					new SqlParameter("@rowsnum", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@imageload", SqlDbType.VarChar,200),
					new SqlParameter("@direction", SqlDbType.VarChar,20)};
			parameters[0].Value = model.founderid;
			parameters[1].Value = model.colsnum;
			parameters[2].Value = model.rowsnum;
			parameters[3].Value = model.title;
			parameters[4].Value = model.imageload;
			parameters[5].Value = model.direction;

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
		public static bool Update(EtNet_Models.PanelMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PanelMenu set ");
			strSql.Append("founderid=@founderid,");
			strSql.Append("colsnum=@colsnum,");
			strSql.Append("rowsnum=@rowsnum,");
			strSql.Append("title=@title,");
			strSql.Append("imageload=@imageload,");
			strSql.Append("direction=@direction");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@founderid", SqlDbType.Int,4),
					new SqlParameter("@colsnum", SqlDbType.Int,4),
					new SqlParameter("@rowsnum", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@imageload", SqlDbType.VarChar,200),
					new SqlParameter("@direction", SqlDbType.VarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.founderid;
			parameters[1].Value = model.colsnum;
			parameters[2].Value = model.rowsnum;
			parameters[3].Value = model.title;
			parameters[4].Value = model.imageload;
			parameters[5].Value = model.direction;
			parameters[6].Value = model.id;

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
			strSql.Append("delete from PanelMenu ");
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
			strSql.Append("delete from PanelMenu ");
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
        /// 批量删除数据
        /// </summary>
        public static bool Del(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PanelMenu ");
            strSql.Append(" where " + strWhere);
            int result =  EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString());
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
		public static EtNet_Models.PanelMenu GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,founderid,colsnum,rowsnum,title,imageload,direction from PanelMenu ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.PanelMenu model = new EtNet_Models.PanelMenu();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.founderid = int.Parse(tbl.Rows[0]["founderid"].ToString());
                model.colsnum = int.Parse(tbl.Rows[0]["colsnum"].ToString());
                model.rowsnum = int.Parse(tbl.Rows[0]["rowsnum"].ToString());
                model.title = tbl.Rows[0]["title"].ToString();
                model.imageload = tbl.Rows[0]["imageload"].ToString();
                model.direction = tbl.Rows[0]["direction"].ToString();
				
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
			strSql.Append("select * ");
			strSql.Append(" FROM PanelMenu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}



		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public  static DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,founderid,colsnum,rowsnum,title,imageload,direction ");
			strSql.Append(" FROM PanelMenu ");
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

