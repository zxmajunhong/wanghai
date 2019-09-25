using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:StaffExperienceService
	/// </summary>
	public  class StaffExperienceService
	{
		public StaffExperienceService()
		{}
		#region  Method

	

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from StaffExperience");
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
		public static bool Add( EtNet_Models.StaffExperience model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StaffExperience(");
			strSql.Append("staffid,stime,etime,yearsnum,workunit,post,remark)");
			strSql.Append(" values (");
			strSql.Append("@staffid,@stime,@etime,@yearsnum,@workunit,@post,@remark)");
			SqlParameter[] parameters = {
				
					new SqlParameter("@staffid", SqlDbType.Int,4),
					new SqlParameter("@stime", SqlDbType.SmallDateTime),
					new SqlParameter("@etime", SqlDbType.SmallDateTime),
					new SqlParameter("@yearsnum", SqlDbType.Int,4),
					new SqlParameter("@workunit", SqlDbType.VarChar,100),
					new SqlParameter("@post", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,200)};
		
			parameters[0].Value = model.staffid;
			parameters[1].Value = model.stime;
			parameters[2].Value = model.etime;
			parameters[3].Value = model.yearsnum;
			parameters[4].Value = model.workunit;
			parameters[5].Value = model.post;
			parameters[6].Value = model.remark;
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
		public static bool Update(EtNet_Models.StaffExperience model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StaffExperience set ");
			strSql.Append("staffid=@staffid,");
			strSql.Append("stime=@stime,");
			strSql.Append("etime=@etime,");
			strSql.Append("yearsnum=@yearsnum,");
			strSql.Append("workunit=@workunit,");
			strSql.Append("post=@post,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@staffid", SqlDbType.Int,4),
					new SqlParameter("@stime", SqlDbType.SmallDateTime),
					new SqlParameter("@etime", SqlDbType.SmallDateTime),
					new SqlParameter("@yearsnum", SqlDbType.Int,4),
					new SqlParameter("@workunit", SqlDbType.VarChar,100),
					new SqlParameter("@post", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.staffid;
			parameters[1].Value = model.stime;
			parameters[2].Value = model.etime;
			parameters[3].Value = model.yearsnum;
			parameters[4].Value = model.workunit;
			parameters[5].Value = model.post;
			parameters[6].Value = model.remark;
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
			strSql.Append("delete from StaffExperience ");
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
			strSql.Append("delete from StaffExperience ");
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
        /// 批量删除
        /// </summary>
        /// <param name="strwhere">指定筛选条件,条件为空全部删除</param>
        public static bool DelList(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StaffExperience ");
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
		public static EtNet_Models.StaffExperience GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,staffid,stime,etime,yearsnum,workunit,post,remark from StaffExperience ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.StaffExperience model = new EtNet_Models.StaffExperience();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count > 0)
			{
               model.id = int.Parse(tbl.Rows[0]["id"].ToString());
               model.staffid = int.Parse(tbl.Rows[0]["staffid"].ToString());
               model.stime = DateTime.Parse(tbl.Rows[0]["stime"].ToString());
               model.etime = DateTime.Parse(tbl.Rows[0]["etime"].ToString());
               model.yearsnum = int.Parse(tbl.Rows[0]["yearsnum"].ToString());
               model.workunit = tbl.Rows[0]["workunit"].ToString();
               model.post = tbl.Rows[0]["post"].ToString();
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
			strSql.Append("select id,staffid,stime,etime,yearsnum,workunit,post,remark ");
			strSql.Append(" FROM StaffExperience ");
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
			strSql.Append(" id,staffid,stime,etime,yearsnum,workunit,post,remark ");
			strSql.Append(" FROM StaffExperience ");
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

