using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:PictureFolderInfoService
	/// </summary>
	public class PictureFolderInfoService
	{
		public PictureFolderInfoService()
		{}
		#region  Method

		
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from PictureFolderInfo");
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
		public static bool  Add(EtNet_Models.PictureFolderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PictureFolderInfo(");
            strSql.Append("upid,cname,capacity,capacityused,typecode,typetxt,creater)");
			strSql.Append(" values (");
            strSql.Append("@upid,@cname,@capacity,@capacityused,@typecode,@typetxt,@creater)");
			
			SqlParameter[] parameters = {
					new SqlParameter("@upid", SqlDbType.Int,4),
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@capacity", SqlDbType.Int,4),
					new SqlParameter("@capacityused", SqlDbType.Int,4),
					new SqlParameter("@typecode", SqlDbType.Int,4),
					new SqlParameter("@typetxt", SqlDbType.VarChar,40),
                    new SqlParameter("@creater",SqlDbType.Int,4)};
			parameters[0].Value = model.upid;
			parameters[1].Value = model.cname;
			parameters[2].Value = model.capacity;
			parameters[3].Value = model.capacityused;
			parameters[4].Value = model.typecode;
			parameters[5].Value = model.typetxt;
            parameters[6].Value = model.creater;

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
		public static bool Update( EtNet_Models.PictureFolderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PictureFolderInfo set ");
			strSql.Append("upid=@upid,");
			strSql.Append("cname=@cname,");
			strSql.Append("capacity=@capacity,");
			strSql.Append("capacityused=@capacityused,");
			strSql.Append("typecode=@typecode,");
			strSql.Append("typetxt=@typetxt,");
            strSql.Append("creater=@creater");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@upid", SqlDbType.Int,4),
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@capacity", SqlDbType.Int,4),
					new SqlParameter("@capacityused", SqlDbType.Int,4),
					new SqlParameter("@typecode", SqlDbType.Int,4),
					new SqlParameter("@typetxt", SqlDbType.VarChar,40),
                    new SqlParameter("@creater",SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.upid;
			parameters[1].Value = model.cname;
			parameters[2].Value = model.capacity;
			parameters[3].Value = model.capacityused;
			parameters[4].Value = model.typecode;
			parameters[5].Value = model.typetxt;
            parameters[6].Value = model.creater;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from PictureFolderInfo ");
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
			strSql.Append("delete from PictureFolderInfo ");
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
		public static  EtNet_Models.PictureFolderInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from PictureFolderInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.PictureFolderInfo model = new EtNet_Models.PictureFolderInfo();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.upid = int.Parse(tbl.Rows[0]["upid"].ToString());
                model.cname = tbl.Rows[0]["cname"].ToString();
                model.capacity = int.Parse(tbl.Rows[0]["capacity"].ToString());
                model.capacityused = int.Parse(tbl.Rows[0]["capacityused"].ToString());
                model.typecode = int.Parse(tbl.Rows[0]["typecode"].ToString());
                model.typetxt = tbl.Rows[0]["typetxt"].ToString();
                model.creater = int.Parse(tbl.Rows[0]["creater"].ToString());
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
		public static DataTable  GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM PictureFolderInfo ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM PictureFolderInfo ");
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

