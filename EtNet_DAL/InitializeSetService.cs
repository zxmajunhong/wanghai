using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL 
{
	/// <summary>
	/// 数据访问类:InitializeSetService
	/// </summary>
	public partial class InitializeSetService
	{
		public InitializeSetService()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(EtNet_Models.InitializeSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into InitializeSet(");
            strSql.Append("cname,siftopen,pagecount,pageitem,infocycle,createtime,inforemind,newinforemind,panellistall,panellist,panelcount,panelcols)");
			strSql.Append(" values (");
            strSql.Append("@cname,@siftopen,@pagecount,@pageitem,@infocycle,@createtime,@inforemind,@newinforemind,@panellistall@panellist,@panelcount,@panelcols)");
            strSql.Append(";select SCOPE_IDENTITY() ");	
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,50),
					new SqlParameter("@siftopen", SqlDbType.Int,4),
					new SqlParameter("@pagecount", SqlDbType.Int,4),
					new SqlParameter("@pageitem", SqlDbType.Int,4),
					new SqlParameter("@infocycle", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
                    new SqlParameter("@inforemind",SqlDbType.Int,4),
                    new SqlParameter("@newinforemind",SqlDbType.Int,4),
                    new SqlParameter("@panellistall",SqlDbType.VarChar,100),
                    new SqlParameter("@panellist",SqlDbType.VarChar,100),
                    new SqlParameter("@panelcount",SqlDbType.VarChar,100),
                    new SqlParameter("@panelcols",SqlDbType.Int,4)
                                };
			parameters[0].Value = model.cname;
			parameters[1].Value = model.siftopen;
			parameters[2].Value = model.pagecount;
			parameters[3].Value = model.pageitem;
			parameters[4].Value = model.infocycle;
			parameters[5].Value = model.createtime;
            parameters[6].Value = model.inforemind;
            parameters[7].Value = model.newinforemind;
            parameters[8].Value = model.panellistall;
            parameters[9].Value = model.panellist;
            parameters[10].Value = model.panelcount;
            parameters[11].Value = model.panelcols;

            int result = 0;
            SqlDataReader rad = EtNet_DAL.DBHelper.ExecuteReader(strSql.ToString(), parameters);
            if (rad.Read())
            {
                result = Convert.ToInt32(rad[0]);
                rad.Close();
            }

            return result;
		}



		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(EtNet_Models.InitializeSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update InitializeSet set ");
			strSql.Append("cname=@cname,");
			strSql.Append("siftopen=@siftopen,");
			strSql.Append("pagecount=@pagecount,");
			strSql.Append("pageitem=@pageitem,");
			strSql.Append("infocycle=@infocycle,");
			strSql.Append("createtime=@createtime,");
            strSql.Append("inforemind=@inforemind,");
            strSql.Append("newinforemind=@newinforemind,");
            strSql.Append("panellistall=@panellistall,");
            strSql.Append("panellist=@panellist,");
            strSql.Append("panelcount=@panelcount,");
            strSql.Append("panelcols=@panelcols");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,50),
					new SqlParameter("@siftopen", SqlDbType.Int,4),
					new SqlParameter("@pagecount", SqlDbType.Int,4),
					new SqlParameter("@pageitem", SqlDbType.Int,4),
					new SqlParameter("@infocycle", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.DateTime),
                    new SqlParameter("@inforemind",SqlDbType.Int,4),
                    new SqlParameter("@newinforemind",SqlDbType.Int,4),
                    new SqlParameter("@panellistall",SqlDbType.VarChar,100),
                    new SqlParameter("@panellist",SqlDbType.VarChar,100),
                    new SqlParameter("@panelcount",SqlDbType.VarChar,100),
                    new SqlParameter("@panelcols",SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.siftopen;
			parameters[2].Value = model.pagecount;
			parameters[3].Value = model.pageitem;
			parameters[4].Value = model.infocycle;
			parameters[5].Value = model.createtime;
            parameters[6].Value = model.inforemind;
            parameters[7].Value = model.newinforemind;
            parameters[8].Value = model.panellistall;
            parameters[9].Value = model.panellist;
            parameters[10].Value = model.panelcount;
            parameters[11].Value = model.panelcols;
			parameters[12].Value = model.id;

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
			strSql.Append("delete from InitializeSet ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            int result =  EtNet_DAL.DBHelper.ExecuteCommand(strSql.ToString(), parameters);
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
			strSql.Append("delete from InitializeSet ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public static  EtNet_Models.InitializeSet GetModel(int id)
		{		
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from InitializeSet ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.InitializeSet model = new  EtNet_Models.InitializeSet();
            DataTable tbl =  EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(),parameters);
            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.cname = tbl.Rows[0]["cname"].ToString();
                model.siftopen = int.Parse(tbl.Rows[0]["siftopen"].ToString());
                model.pagecount = int.Parse(tbl.Rows[0]["pagecount"].ToString());
                model.pageitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
                model.infocycle = int.Parse(tbl.Rows[0]["infocycle"].ToString());
                model.createtime = DateTime.Parse(tbl.Rows[0]["createtime"].ToString());
                model.inforemind = int.Parse(tbl.Rows[0]["inforemind"].ToString());
                model.newinforemind = int.Parse(tbl.Rows[0]["newinforemind"].ToString());
                model.panellistall = tbl.Rows[0]["panellistall"].ToString();
                model.panellist = tbl.Rows[0]["panellist"].ToString();
                model.panelcount = tbl.Rows[0]["panelcount"].ToString();
                model.panelcols = int.Parse(tbl.Rows[0]["panelcols"].ToString());
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
			strSql.Append(" FROM InitializeSet ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return  EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
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
			strSql.Append(" FROM InitializeSet ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return  EtNet_DAL.DBHelper.GetDataSet(strSql.ToString());
		}

		
		#endregion  Method
	}
}

