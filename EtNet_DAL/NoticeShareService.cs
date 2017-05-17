using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace EtNet_DAL
{
	/// <summary>
    /// 数据访问类:NoticeShareService
	/// </summary>
	public class NoticeShareService
	{
		public NoticeShareService()
		{}
		#region  Method

		
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from NoticeShare");
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
		public static bool Add(EtNet_Models.NoticeShare model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NoticeShare(");
			strSql.Append("noticeid,acceptid)");
			strSql.Append(" values (");
			strSql.Append("@noticeid,@acceptid)");
			
			SqlParameter[] parameters = {
					new SqlParameter("@noticeid", SqlDbType.Int,4),
					new SqlParameter("@acceptid", SqlDbType.Int,4)};
			parameters[0].Value = model.noticeid;
			parameters[1].Value = model.acceptid;

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
		public static bool Update(EtNet_Models.NoticeShare model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NoticeShare set ");
			strSql.Append("noticeid=@noticeid,");
			strSql.Append("acceptid=@acceptid");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@noticeid", SqlDbType.Int,4),
					new SqlParameter("@acceptid", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.noticeid;
			parameters[1].Value = model.acceptid;
			parameters[2].Value = model.id;

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
			strSql.Append("delete from NoticeShare ");
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
			strSql.Append("delete from NoticeShare ");
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
		public static EtNet_Models.NoticeShare GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from NoticeShare ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.NoticeShare model = new EtNet_Models.NoticeShare();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

			if(tbl.Rows.Count >= 1)
			{
			   model.id=int.Parse(tbl.Rows[0]["id"].ToString());
			   model.noticeid=int.Parse(tbl.Rows[0]["noticeid"].ToString());
		       model.acceptid=int.Parse(tbl.Rows[0]["acceptid"].ToString());	
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
			strSql.Append(" FROM NoticeShare ");
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
			strSql.Append(" id,noticeid,acceptid ");
			strSql.Append(" FROM NoticeShare ");
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

