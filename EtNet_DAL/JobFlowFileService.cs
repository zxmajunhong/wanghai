using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace EtNet_DAL
{
	/// <summary>
    /// 数据访问类:JobFlowFileService
	/// </summary>
	public class JobFlowFileService
	{
		public JobFlowFileService()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
            string strSql = "select  * from JobFlowFile order by id desc";
            return EtNet_DAL.DBHelper.ExecuteScalar(strSql);
            
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int jobflowid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from JobFlowFile");
            strSql.Append(" where jobflowid=@jobflowid");
			SqlParameter[] parameters = {
					new SqlParameter("@jobflowid", SqlDbType.Int,4)};
			parameters[0].Value = jobflowid;

            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
            if (tbl.Rows.Count >= 1)
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
		public static bool Add(EtNet_Models.JobFlowFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into JobFlowFile(");
			strSql.Append("filename,fileload,jobflowid,filesize,createtime)");
			strSql.Append(" values (");
			strSql.Append("@filename,@fileload,@jobflowid,@filesize,@createtime)");
			
			SqlParameter[] parameters = {
					new SqlParameter("@filename", SqlDbType.VarChar,50),
					new SqlParameter("@fileload", SqlDbType.VarChar,200),
					new SqlParameter("@jobflowid", SqlDbType.Int,4),
					new SqlParameter("@filesize", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.VarChar,50)};
			parameters[0].Value = model.filename;
			parameters[1].Value = model.fileload;
			parameters[2].Value = model.jobflowid;
			parameters[3].Value = model.filesize;
			parameters[4].Value = model.createtime;

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
        public static bool Update(EtNet_Models.JobFlowFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update JobFlowFile set ");
			strSql.Append("filename=@filename,");
			strSql.Append("fileload=@fileload,");
			strSql.Append("jobflowid=@jobflowid,");
			strSql.Append("filesize=@filesize,");
			strSql.Append("createtime=@createtime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@filename", SqlDbType.VarChar,50),
					new SqlParameter("@fileload", SqlDbType.VarChar,200),
					new SqlParameter("@jobflowid", SqlDbType.Int,4),
					new SqlParameter("@filesize", SqlDbType.Int,4),
					new SqlParameter("@createtime", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.filename;
			parameters[1].Value = model.fileload;
			parameters[2].Value = model.jobflowid;
			parameters[3].Value = model.filesize;
			parameters[4].Value = model.createtime;
			parameters[5].Value = model.id;

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
		public static bool Delete(int jobflowid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from JobFlowFile ");
			strSql.Append(" where jobflowid=@jobflowid");
			SqlParameter[] parameters = {
					new SqlParameter("@jobflowid", SqlDbType.Int,4)};
			parameters[0].Value = jobflowid;

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
        /// 依据id删除数据
        /// </summary>
        public static bool DeleteId(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JobFlowFile ");
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
		/// 得到一个对象实体
		/// </summary>
        public static EtNet_Models.JobFlowFile GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from JobFlowFile ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

            EtNet_Models.JobFlowFile model = new EtNet_Models.JobFlowFile();
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);

            if (tbl.Rows.Count > 0)
			{
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.filename = tbl.Rows[0]["filename"].ToString();
			    model.fileload=tbl.Rows[0]["fileload"].ToString();
                model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                model.filesize = int.Parse(tbl.Rows[0]["filesize"].ToString());
                model.createtime = tbl.Rows[0]["createtime"].ToString();
				
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
		public  static DataTable GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,filename,fileload,jobflowid,filesize,createtime ");
			strSql.Append(" FROM JobFlowFile ");
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
			strSql.Append(" id,filename,fileload,jobflowid,filesize,createtime ");
			strSql.Append(" FROM JobFlowFile ");
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

