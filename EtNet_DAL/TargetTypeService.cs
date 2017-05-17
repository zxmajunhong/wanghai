using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace EtNet_DAL
{
	/// <summary>
	/// 数据访问类:TargetTypeService
	/// </summary>
	public partial class TargetTypeService
	{
		public TargetTypeService()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EtNet_Models.TargetType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TargetType(");
			strSql.Append("TypeNo,TypeName)");
			strSql.Append(" values (");
			strSql.Append("@TypeNo,@TypeName)");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeNo", SqlDbType.NVarChar,10),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.TypeNo;
			parameters[1].Value = model.TypeName;

			int rows=DBHelper.ExecuteCommand(strSql.ToString(),parameters);
			if (rows > 0)
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
		public bool Update(EtNet_Models.TargetType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TargetType set ");
			strSql.Append("TypeNo=@TypeNo,");
			strSql.Append("TypeName=@TypeName");
			strSql.Append(" where TargetTypeID=@TargetTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeNo", SqlDbType.NVarChar,10),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,20),
					new SqlParameter("@TargetTypeID", SqlDbType.Int,4)};
			parameters[0].Value = model.TypeNo;
			parameters[1].Value = model.TypeName;
			parameters[2].Value = model.TargetTypeID;

			int rows=DBHelper.ExecuteCommand(strSql.ToString(),parameters);
			if (rows > 0)
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
		public bool Delete(int TargetTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TargetType ");
			strSql.Append(" where TargetTypeID=@TargetTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TargetTypeID", SqlDbType.Int,4)			};
			parameters[0].Value = TargetTypeID;

			int rows=DBHelper.ExecuteCommand(strSql.ToString(),parameters);
			if (rows > 0)
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
		public bool DeleteList(string TargetTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TargetType ");
			strSql.Append(" where TargetTypeID in ("+TargetTypeIDlist + ")  ");
			int rows=DBHelper.ExecuteCommand(strSql.ToString());
			if (rows > 0)
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
		public EtNet_Models.TargetType GetModel(int TargetTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TargetTypeID,TypeNo,TypeName from TargetType ");
			strSql.Append(" where TargetTypeID=@TargetTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TargetTypeID", SqlDbType.Int,4)			};
			parameters[0].Value = TargetTypeID;

			EtNet_Models.TargetType model=new EtNet_Models.TargetType();
			DataTable ds=DBHelper.GetDataSet(strSql.ToString(),parameters);
			if(ds.Rows.Count>0)
			{
				if(ds.Rows[0]["TargetTypeID"]!=null && ds.Rows[0]["TargetTypeID"].ToString()!="")
				{
					model.TargetTypeID=int.Parse(ds.Rows[0]["TargetTypeID"].ToString());
				}
				if(ds.Rows[0]["TypeNo"]!=null && ds.Rows[0]["TypeNo"].ToString()!="")
				{
					model.TypeNo=ds.Rows[0]["TypeNo"].ToString();
				}
				if(ds.Rows[0]["TypeName"]!=null && ds.Rows[0]["TypeName"].ToString()!="")
				{
					model.TypeName=ds.Rows[0]["TypeName"].ToString();
				}
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
		public DataTable GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TargetTypeID,TypeNo,TypeName ");
			strSql.Append(" FROM TargetType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" TargetTypeID,TypeNo,TypeName ");
			strSql.Append(" FROM TargetType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TargetType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DBHelper.ExecuteScalar(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.TargetTypeID desc");
			}
			strSql.Append(")AS Row, T.*  from TargetType T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DBHelper.GetDataSet(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "TargetType";
			parameters[1].Value = "TargetTypeID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

