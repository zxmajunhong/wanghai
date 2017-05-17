using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:ModuleCodingInfoService
	/// </summary>
	public partial class ModuleCodingInfoService
	{
		public ModuleCodingInfoService()
		{}
		#region  Method

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from ModuleCodingInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            SqlDataReader rad =  EtNet_DAL.DBHelper.GetReader(strSql.ToString());
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
		public static bool Add( EtNet_Models.ModuleCodingInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ModuleCodingInfo(");
			strSql.Append("num,cname,txtformat,orderlen,usecode,usetxt,createtime)");
			strSql.Append(" values (");
			strSql.Append("@num,@cname,@txtformat,@orderlen,@usecode,@usetxt,@createtime)");
		
			SqlParameter[] parameters = {
					new SqlParameter("@num", SqlDbType.VarChar,10),
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@txtformat", SqlDbType.VarChar,100),
					new SqlParameter("@orderlen", SqlDbType.Int,4),
					new SqlParameter("@usecode", SqlDbType.Int,4),
					new SqlParameter("@usetxt", SqlDbType.VarChar,4),
					new SqlParameter("@createtime", SqlDbType.DateTime)};
			parameters[0].Value = model.num;
			parameters[1].Value = model.cname;
			parameters[2].Value = model.txtformat;
			parameters[3].Value = model.orderlen;
			parameters[4].Value = model.usecode;
			parameters[5].Value = model.usetxt;
			parameters[6].Value = model.createtime;

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
		public static bool Update(EtNet_Models.ModuleCodingInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ModuleCodingInfo set ");
			strSql.Append("num=@num,");
			strSql.Append("cname=@cname,");
			strSql.Append("txtformat=@txtformat,");
			strSql.Append("orderlen=@orderlen,");
			strSql.Append("usecode=@usecode,");
			strSql.Append("usetxt=@usetxt,");
			strSql.Append("createtime=@createtime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@num", SqlDbType.VarChar,10),
					new SqlParameter("@cname", SqlDbType.VarChar,40),
					new SqlParameter("@txtformat", SqlDbType.VarChar,100),
					new SqlParameter("@orderlen", SqlDbType.Int,4),
					new SqlParameter("@usecode", SqlDbType.Int,4),
					new SqlParameter("@usetxt", SqlDbType.VarChar,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.num;
			parameters[1].Value = model.cname;
			parameters[2].Value = model.txtformat;
			parameters[3].Value = model.orderlen;
			parameters[4].Value = model.usecode;
			parameters[5].Value = model.usetxt;
			parameters[6].Value = model.createtime;
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
			strSql.Append("delete from ModuleCodingInfo ");
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
			strSql.Append("delete from ModuleCodingInfo ");
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
		public static  EtNet_Models.ModuleCodingInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from ModuleCodingInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.ModuleCodingInfo model = new EtNet_Models.ModuleCodingInfo();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
			if(tbl.Rows.Count>0)
			{			
			    model.id=int.Parse(tbl.Rows[0]["id"].ToString());
                model.num = tbl.Rows[0]["num"].ToString();
                model.cname = tbl.Rows[0]["cname"].ToString();
                model.txtformat = tbl.Rows[0]["txtformat"].ToString();
                model.orderlen = int.Parse(tbl.Rows[0]["orderlen"].ToString());
                model.usecode = int.Parse(tbl.Rows[0]["usecode"].ToString());
                model.usetxt = tbl.Rows[0]["usetxt"].ToString();
                model.createtime = DateTime.Parse(tbl.Rows[0]["createtime"].ToString());				
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
			strSql.Append("select id,num,cname,txtformat,orderlen,usecode,usetxt,createtime ");
			strSql.Append(" FROM ModuleCodingInfo ");
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
			strSql.Append(" id,num,cname,txtformat,orderlen,usecode,usetxt,createtime ");
			strSql.Append(" FROM ModuleCodingInfo ");
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

