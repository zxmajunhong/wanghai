using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:AusBillState
	/// </summary>
	public partial class AusBillStateService
	{
        public AusBillStateService()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(EtNet_Models.AusBillState model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AusBillState(");
			strSql.Append("id,txt)");
			strSql.Append(" values (");
			strSql.Append("@id,@txt)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@txt", SqlDbType.VarChar,40)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.txt;


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
		public static bool Update(EtNet_Models.AusBillState model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AusBillState set ");	
			strSql.Append("txt=@txt");
            strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@txt", SqlDbType.VarChar,40)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.txt;

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
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AusBillState ");
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
        public static EtNet_Models.AusBillState GetModel(int id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from AusBillState ");
			strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;


            EtNet_Models.AusBillState model = new EtNet_Models.AusBillState();
		    DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(strSql.ToString(), parameters);
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
			strSql.Append("select * ");
			strSql.Append(" FROM AusBillState ");
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
			strSql.Append(" FROM AusBillState ");
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

